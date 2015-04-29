using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{

	public static MovementGrid Grid;

	public static List<CharacterAction> CharActionList;

	public static List<Vector2> MovePoint;

	public static PartyHandler PartyHandler;

	public static Camera MainCamera;
	private static float CameraOriginalSize;

	void Awake()
	{
		MovePoint = new List<Vector2>();
		Grid = GetComponentInChildren<MovementGrid>();
		MainCamera = GetComponentInChildren<Camera>();
			CameraOriginalSize = MainCamera.orthographicSize;
		PartyHandler = GameObject.FindGameObjectWithTag("PartyHandler").GetComponent<PartyHandler>();

		CharActionList = new List<CharacterAction>();

		//BattleMenu.Instance.ChangeCharacter(PartyHandler.GetActiveCharacter().GetComponent<Character>());
	}

	void Update()
	{
		if(MainCamera.GetComponent<CameraFollow>().character == null)
			MainCamera.GetComponent<CameraFollow>().character = PartyHandler.GetActiveCharacter().transform;
	}

	/// <summary>
	/// Adds a transform position to the list of movement positions
	/// </summary>
	/// <param name="t">Transform to move to</param>
	public static void AddMovePoint(Vector2 v)
	{
		MovePoint.Add(v);
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
		var character = PartyHandler.GetActiveCharacter();

		if (MovePoint.Count == 0)
			return character.transform.position;
		
		return MovePoint.Last();
	}


	public static void ExecuteQueue()
	{
		// TODO: Send queue to Character, wait for Character to finish action. Switch to next Character, bring menus back up

		PartyHandler.GetActiveCharacter().GetComponent<Character>().DoActions(CharActionList);
		if(CharActionList.Count > 0)
			BattleMenu.Instance.AnimateWindowPanels();


		//BattleMenu.Instance.ChangeCharacter(character.GetComponent<Character>());
	}


	public static void NextTurn()
	{
		ClearMovePoint();
		if (CharActionList.Count > 0)
			BattleMenu.Instance.AnimateWindowPanels(false);
		PartyHandler.NextTurn();
		MainCamera.GetComponent<CameraFollow>().character = PartyHandler.GetActiveCharacter().transform;
		BattleMenu.Instance.ActionQueueList.Clear();
		CharActionList.Clear();
	}

}
