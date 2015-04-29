using UnityEngine;
using System.Collections.Generic;

public class AIScript : AIPath2D
{
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



	public override void Update()
	{
		if (target != null && _isLerping == false)
		{
			StartLerping();
		}
	}
	

	//We do the actual interpolation in FixedUpdate(), since we're dealing with a rigidbody
	void FixedUpdate()
	{
		// While lerping do not allow for a repath to occur
		if (_isLerping)
		{
			canSearch = false;
			vPath = path.vectorPath;
			PerformLerp(GetFeetPosition(), vPath);
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


	void PerformLerp(Vector3 currentPosition, List<Vector3> currentPath)
	{
		// List of all nodes in the current path
		//List<Vector3> vPath = path.vectorPath;

		if (currentPath.Count == 1)
		{
			currentPath.Insert(0, currentPosition);
			if (!targetReached) { targetReached = true; OnTargetReached(); Debug.Log("TargetReached"); }
		}

		//if (currentWaypointIndex >= currentPath.Count)
		//	currentWaypointIndex = currentPath.Count - 1;

		//if (currentWaypointIndex <= 1) 
			currentWaypointIndex = 1;

		Vector3 nextPosition = currentPath[currentWaypointIndex];


		 //distance 


		// Find the next turn in the path, and set it as the lerp point
		//for (int i = 1; i < currentPath.Count; i++)
		//{
			



		//	var temp = Vector3.Angle(currentPath[i - 1], currentPath[i]);
		//	Debug.Log("Angle between current position" + currentPath[i - 1] + " and next position " + currentPath[i] + " is " + temp);
		//	Debug.Log(currentPath[i-1]-currentPath[i]);
		//}


		// We want percentage = 0.0 when Time.time = _timeStartedLerping
		// and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
		// In other words, we want to know what percentage of "timeTakenDuringLerp" the value
		// "Time.time - _timeStartedLerping" is.
		float timeSinceStarted = Time.time - _timeStartedLerping;
		float percentageComplete = timeSinceStarted / speed;

		// Perform the actual lerping.  Notice that the first two parameters will always be the same
		// throughout a single lerp-processs (ie. they won't change until we hit the space-bar again
		// to start another lerp)
		transform.position = Vector3.Lerp(currentPosition, nextPosition, percentageComplete);

		//When we've completed the lerp, we set _isLerping to false
		if (percentageComplete >= 1.0f)
		{
			_isLerping = false;
			canSearch = true;
		}
	}








}
