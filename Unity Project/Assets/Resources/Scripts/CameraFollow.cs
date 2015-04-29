using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	/// <summary>
	/// Distance in the x axis the Character can move before the camera follows.
	/// </summary>
	public float xMargin = 1f;

	/// <summary>
	/// Distance in the y axis the Character can move before the camera follows.
	/// </summary>
	public float yMargin = 1f;

	/// <summary>
	/// Reference to the Character's transform.
	/// </summary>
	public Transform character;

	/// <summary>
	/// Reference to Tiled Map Camera is viewing.
	/// </summary>
	public GameObject map;

	/// <summary>
	/// The maximum x and y coordinates the camera can have.
	/// </summary>
	private Vector2 maxXAndY;

	/// <summary>
	/// The minimum x and y coordinates the camera can have.
	/// </summary>
	private Vector2 minXAndY;

	/// <summary>
	/// How smoothly the camera catches up with it's target movement in the x axis.
	/// </summary>
	private float xSmooth = 2f;

	/// <summary>
	/// How smoothly the camera catches up with it's target movement in the y axis
	/// </summary>
	private float ySmooth = 2f;
	

	void Awake ()
	{
		// Setting up the map object coordinates.
		maxXAndY = new Vector2((map.GetComponentInChildren<MeshRenderer>().bounds.max.x), 
							   (map.GetComponentInChildren<MeshRenderer>().bounds.max.y));

		minXAndY = new Vector2((map.GetComponentInChildren<MeshRenderer>().bounds.min.x), 
							   (map.GetComponentInChildren<MeshRenderer>().bounds.min.y));
	}


	/// <summary>
	/// Returns true if the distance between the camera and the Character in the x axis is greater than the x margin.
	/// </summary>
	bool CheckXMargin()
	{
		return Mathf.Abs(transform.position.x - character.position.x) > xMargin;
	}

	/// <summary>
	/// Returns true if the distance between the camera and the Character in the y axis is greater than the y margin.
	/// </summary>
	bool CheckYMargin()
	{
		return Mathf.Abs(transform.position.y - character.position.y) > yMargin;
	}


	void FixedUpdate ()
	{
		TrackCharacter();
		checkCameraSize();
	}
	
	/// <summary>
	/// Camera follows Character object based on the x and y margins for the dead zone and locks the viewport to the map's boundries
	/// </summary>
	void TrackCharacter ()
	{
		if (character == null) return;
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		// If the Character has moved beyond the x margin...
		if(CheckXMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the Character's current x position.
			targetX = Mathf.Lerp(transform.position.x, character.position.x, xSmooth * Time.deltaTime);

		// If the Character has moved beyond the y margin...
		if(CheckYMargin())
			// ... the target y coordinate should be a Lerp between the camera's current y position and the Character's current y position.
			targetY = Mathf.Lerp(transform.position.y, character.position.y, ySmooth * Time.deltaTime);

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, (minXAndY.x + (camera.aspect * camera.orthographicSize)), (maxXAndY.x - (camera.aspect * camera.orthographicSize)));
		targetY = Mathf.Clamp(targetY, (minXAndY.y + camera.orthographicSize), (maxXAndY.y - camera.orthographicSize));

		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}

	/// <summary>
	/// Checks the viewport size to see if the viewport size is larger than the map's dimentions.  If larger, the viewport is resized.
	/// </summary>
	void checkCameraSize ()
	{
		/// <summary>
		/// Height of map = Distance of lowest y coordinate to highest y coordinate
		/// </summary>
		float mapHeight = Vector2.Distance (new Vector2 (0.0f, maxXAndY.y), new Vector2(0.0f, minXAndY.y));

		/// <summary>
		/// Width of map = Distance of lowest x coordinate to highest x coordinate
		/// </summary>
		float mapWidth = Vector2.Distance (new Vector2(maxXAndY.x, 0.0f), new Vector2(minXAndY.x, 0.0f));

		/// <summary>
		/// If the Camera viewport is taller than the height of the map, resize to map height
		/// </summary>
		if (camera.orthographicSize * 2 > mapHeight)
		{
			camera.orthographicSize = (mapHeight / 2);
		}

		/// <summary>
		/// If the Camera viewport is wider than the width of the map, resize to map width
		/// </summary>
		if (((camera.aspect * camera.orthographicSize) * 2) > mapWidth)
		{
			camera.orthographicSize = (mapWidth / camera.aspect) / 2;
		}
	}
}
