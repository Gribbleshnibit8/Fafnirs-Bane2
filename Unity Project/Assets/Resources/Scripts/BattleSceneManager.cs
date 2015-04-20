using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{

	public static MovementGrid Grid;

	// TODO: Change type of class to character sheet, or gameobject of character
	// NOTE: Parent gameobject can be gotten from any component
	/// <summary>
	/// The currently active character
	/// </summary>
	public static AIScript Character;

	public static List<CharacterAction> CharActionList;

	public static List<Transform> MovePoint;

	public static Camera MainCamera;
	private static float CameraOriginalSize;

	void Awake()
	{
		MovePoint = new List<Transform>();
		Grid = GetComponentInChildren<MovementGrid>();
		Character = GetComponentInChildren<AIScript>();
		MainCamera = GetComponentInChildren<Camera>();
			CameraOriginalSize = MainCamera.orthographicSize;

		CharActionList = new List<CharacterAction>();
	}


	public static void AddMovePoint(Transform t)
	{
		MovePoint.Add(t);
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


	public static void ExecuteQueue()
	{
		// TODO: Send queue to character, wait for character to finish action. Switch to next character, bring menus back up
	}

}
