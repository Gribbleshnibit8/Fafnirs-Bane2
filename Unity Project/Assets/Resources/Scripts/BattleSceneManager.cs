using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{

	public static MovementGrid Grid;

	public static AIScript Character;

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

}
