using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{

	public static MovementGrid Grid;

	public static List<CharacterAction> CharActionList;

	public static List<Vector2> MovePoint;

	public static partyHandler PartyHandler;

	public static Camera MainCamera;
	private static float CameraOriginalSize;

	void Awake()
	{
		MovePoint = new List<Vector2>();
		Grid = GetComponentInChildren<MovementGrid>();
		MainCamera = GetComponentInChildren<Camera>();
			CameraOriginalSize = MainCamera.orthographicSize;
		PartyHandler = GameObject.FindGameObjectWithTag("PartyHandler").GetComponent<partyHandler>();

		CharActionList = new List<CharacterAction>();
	}

	/// <summary>
	/// Adds a transform position to the list of movement positions
	/// </summary>
	/// <param name="t">Transform to move to</param>
	public static void AddMovePoint(Transform t)
	{
		MovePoint.Add(t.position);
		Grid.ClearGrid();
	}


	public static void RemoveMovePoint(Transform t)
	{
		foreach (var trans in MovePoint)
		{
			if (trans.Equals(t))
				MovePoint.Remove(trans);
		}
	}


	public static void ClearMovePoint()
	{
		MovePoint.Clear();
	}


	public static void ZoomCameraToScale(float size)
	{
		// Used in MovementGrid to set the camera size to .5 more than the height of the grid
		if (size > CameraOriginalSize)
			MainCamera.orthographicSize = size;
	}


	public static void ResetCameraScale()
	{
		MainCamera.orthographicSize = CameraOriginalSize;
	}

	public static Vector2 GetLastPosition()
	{
		var character = PartyHandler.getActiveCharacter();

		if (MovePoint.Count == 0)
			return character.transform.position;
		
		return MovePoint.Last();
	}


	public static void ExecuteQueue()
	{
		// TODO: Send queue to character, wait for character to finish action. Switch to next character, bring menus back up

		var character = PartyHandler.getActiveCharacter();

		// execute the queue
	}

}
