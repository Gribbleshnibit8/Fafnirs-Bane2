using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

public class LerpExample : MonoBehaviour
{
	/// <summary>
	/// The time taken to move from the start to finish positions
	/// </summary>
	public float Speed = 0.5f;

	#region A* script set variables

	/// <summary>
	/// Determines how often it will search for new paths.
	/// If you have fast moving targets or AIs, you might want to set it to a lower value.
	/// The value is in seconds between path requests.
	/// </summary>
	public float RepathRate = 0.5F;

	/// <summary>
	/// Target to move towards.
	/// The AI will try to follow/move towards this target.
	/// It can be a point on the ground where the player has clicked in an RTS for example, or it can be the player object in a zombie game.
	/// </summary>
	public Transform Target;

	/// <summary>
	/// Enables or disables searching for paths.
	/// Setting this to false does not stop any active path requests from being calculated or stop it from continuing to follow the current path.
	/// see #canMove
	/// </summary>
	public bool CanSearch = true;

	/// <summary>
	/// Enables or disables movement.
	/// see #canSearch
	/// </summary>
	public bool CanMove = true;

	/// <summary>
	/// Do a closest point on path check when receiving path callback.
	/// Usually the AI has moved a bit between requesting the path, and getting it back, and there is usually a small gap between the AI and the closest node.
	/// If this option is enabled, it will simulate, when the path callback is received, movement between the closest node and the current AI position. This helps to reduce the moments when the AI just get a new path back, and thinks it ought to move backwards to the start of the new path even though it really should just proceed forward.
	/// </summary>
	public bool ClosestOnPathCheck = true;

	/// <summary>
	/// Determines within what range it will switch to target the next waypoint in the path
	/// </summary>
	public float PickNextWaypointDist = 2;

	/// <summary>
	/// Cached Seeker component
	/// </summary>
	protected Seeker MySeeker;

	/// <summary>
	/// Cached Transform component
	/// </summary>
	protected Transform MyTransform;

	/// <summary>
	/// Time when the last path request was sent
	/// </summary>
	protected float LastRepath = -9999;

	/// <summary>
	/// Current path which is followed
	/// </summary>
	protected Path Path;

	/// <summary>
	/// Cached NavmeshController component
	/// </summary>
	protected NavmeshController NavController;

	/// <summary>
	/// Current index in the path which is current target
	/// </summary>
	protected int CurrentWaypointIndex = 0;

	/// <summary>
	/// Only when the previous path has been returned should be search for a new path
	/// </summary>
	protected bool CanSearchAgain = true;

	protected Vector3 LastFoundWaypointPosition;
	protected float LastFoundWaypointTime = -9999;

	/** Holds if the end-of-path is reached
	 * \see TargetReached */
	protected bool targetReached = false;

	/// <summary>
	/// Returns if the end-of-path has been reached
	/// see targetReached
	/// </summary>
	public bool TargetReached
	{
		get
		{
			return targetReached;
		}
	}

	/// <summary>
	/// Holds if the Start function has been run.
	/// used to test if coroutines should be started in OnEnable to prevent calculating paths
	/// in the awake stage (or rather before start on frame 0).
	/// </summary>
	private bool startHasRun = false;








	#endregion

	#region A* pathing functions
	/// <summary>
	/// Initializes reference variables.
	/// If you override this function you should in most cases call base.Awake () at the start of it.
	/// </summary>
	protected virtual void Awake()
	{
		MySeeker = GetComponent<Seeker>();

		//This is a simple optimization, cache the transform component lookup
		MyTransform = transform;

		//Cache some other components (not all are necessarily there)
		NavController = GetComponent<NavmeshController>();
	}

	/// <summary>
	/// Starts searching for paths.
	/// If you override this function you should in most cases call base.Start () at the start of it.
	/// see OnEnable
	/// see RepeatTrySearchPath
	/// </summary>
	protected virtual void Start()
	{
		startHasRun = true;
		OnEnable();
	}

	/// <summary>
	/// Run at start and when reenabled.
	/// Starts RepeatTrySearchPath.
	/// see Start
	/// </summary>
	protected virtual void OnEnable()
	{
		LastRepath = -9999;
		CanSearchAgain = true;

		LastFoundWaypointPosition = GetFeetPosition();

		if (!startHasRun) return;

		//Make sure we receive callbacks when paths complete
		MySeeker.pathCallback += OnPathComplete;

		StartCoroutine(RepeatTrySearchPath());
	}

	public void OnDisable()
	{
		// Abort calculation of path
		if (MySeeker != null && !MySeeker.IsDone()) MySeeker.GetCurrentPath().Error();

		// Release current path
		if (Path != null) Path.Release(this);
		Path = null;

		//Make sure we receive callbacks when paths complete
		MySeeker.pathCallback -= OnPathComplete;
	}

	/// <summary>
	/// Tries to search for a path every #repathRate seconds.
	/// see TrySearchPath
	/// </summary>
	protected IEnumerator RepeatTrySearchPath()
	{
		while (true)
		{
			float v = TrySearchPath();
			yield return new WaitForSeconds(v);
		}
	}

	/// <summary>
	/// Tries to search for a path.
	/// Will search for a new path if there was a sufficient time since the last repath and both
	/// #canSearchAgain and #canSearch are true and there is a target.
	/// </summary>
	/// <returns>Returns The time to wait until calling this function again (based on #repathRate) </returns>
	public float TrySearchPath()
	{
		if (Time.time - LastRepath >= RepathRate && CanSearchAgain && CanSearch && Target != null)
		{
			SearchPath();
			return RepathRate;
		}
		else
		{
			//StartCoroutine (WaitForRepath ());
			float v = RepathRate - (Time.time - LastRepath);
			return v < 0 ? 0 : v;
		}
	}

	/// <summary>
	/// Requests a path to the target
	/// </summary>
	public virtual void SearchPath()
	{

		if (Target == null) throw new System.InvalidOperationException("Target is null");

		LastRepath = Time.time;
		//This is where we should search to
		Vector3 targetPosition = Target.position;

		CanSearchAgain = false;

		//We should search from the current position
		MySeeker.StartPath(GetFeetPosition(), targetPosition);
	}

	public virtual void OnTargetReached()
	{
		//End of path has been reached
		//If you want custom logic for when the AI has reached it's destination
		//add it here
		//You can also create a new script which inherits from this one
		//and override the function in that script
	}

	/// <summary>
	/// Gets the current position of the object
	/// </summary>
	/// <returns>Returns the current position in Vector3</returns>
	public virtual Vector3 GetFeetPosition()
	{
		return MyTransform.position;
	}

	/// <summary>
	/// Called when a requested path has finished calculation.
	/// A path is first requested by #SearchPath, it is then calculated, probably in the same or the next frame.
	/// Finally it is returned to the seeker which forwards it to this function.
	/// </summary>
	/// <param name="_p"></param>
	public virtual void OnPathComplete(Path _p)
	{
		ABPath p = _p as ABPath;
		if (p == null) throw new System.Exception("This function only handles ABPaths, do not use special path types");

		CanSearchAgain = true;

		//Claim the new path
		p.Claim(this);

		// Path couldn't be calculated of some reason.
		// More info in p.errorLog (debug string)
		if (p.error)
		{
			p.Release(this);
			return;
		}

		//Release the previous path
		if (Path != null) Path.Release(this);

		//Replace the old path
		Path = p;

		//Reset some variables
		CurrentWaypointIndex = 0;
		targetReached = false;

		//The next row can be used to find out if the path could be found or not
		//If it couldn't (error == true), then a message has probably been logged to the console
		//however it can also be got using p.errorLog
		//if (p.error)

		if (ClosestOnPathCheck)
		{
			Vector3 p1 = Time.time - LastFoundWaypointTime < 0.3f ? LastFoundWaypointPosition : p.originalStartPoint;
			Vector3 p2 = GetFeetPosition();
			Vector3 dir = p2 - p1;
			float magn = dir.magnitude;
			dir /= magn;
			int steps = (int)(magn / PickNextWaypointDist);


			for (int i = 0; i <= steps; i++)
			{
				p1.z = 0;					// Wesley Added this to null out the Z axis each step
				//CalculateVelocity(p1);
				p1 += dir;
			}

		}
	}

	#endregion

	#region Lerp Variables

	/// <summary>
	/// The time taken to move from the start to finish positions
	/// </summary>
	private const float DistanceToMove = 1f;

	/// <summary>
	/// Whether we are currently interpolating or not
	/// </summary>
	private bool _isLerping;

	//The Time.time value when we started the interpolation
	private float _timeStartedLerping;

	#endregion


	private List<Vector3> vPath;

	void Update()
	{
		if (Target != null && _isLerping == false)
		{
			StartLerping();
			vPath = Path.vectorPath;
		}
	}
	

	/// <summary>
	/// Called to begin the linear interpolation
	/// </summary>
	void StartLerping()
	{
		_isLerping = true;
		_timeStartedLerping = Time.time;
	}

	

	//We do the actual interpolation in FixedUpdate(), since we're dealing with a rigidbody
	void FixedUpdate()
	{
		// While lerping do not allow for a repath to occur
		if (_isLerping)
		{
			CanSearch = false;
			PerformLerp(GetFeetPosition());
		}	
	}


	void PerformLerp(Vector3 currentPosition)
	{
		// List of all nodes in the current path
		List<Vector3> vPath = Path.vectorPath;

		Vector3 nextPosition = vPath[CurrentWaypointIndex + 1];


		//We want percentage = 0.0 when Time.time = _timeStartedLerping
		//and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
		//In other words, we want to know what percentage of "timeTakenDuringLerp" the value
		//"Time.time - _timeStartedLerping" is.
		float timeSinceStarted = Time.time - _timeStartedLerping;
		float percentageComplete = timeSinceStarted / Speed;

		//Perform the actual lerping.  Notice that the first two parameters will always be the same
		//throughout a single lerp-processs (ie. they won't change until we hit the space-bar again
		//to start another lerp)
		transform.position = Vector3.Lerp(currentPosition, nextPosition, percentageComplete);

		//When we've completed the lerp, we set _isLerping to false
		if (percentageComplete >= 1.0f)
		{
			_isLerping = false;
			CanSearch = true;
		}
	}



}
