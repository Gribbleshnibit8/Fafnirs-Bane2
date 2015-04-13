using UnityEngine;
using System.Collections.Generic;

public class MovementGrid : GridGenerator
{

	public Transform MovePoint;

	public GameObject CallingMenu;

	private static MovementGrid _movementGrid;
	public static MovementGrid Instance
	{
		get { return _movementGrid ?? (_movementGrid = new MovementGrid()); }
	}

	new void Awake()
	{
		base.Awake();

		_movementGrid = this;

		GridObject = "GridSquare";
	}


	public override void SetPoint(Transform t)
	{
		MovePoint = t;
		RootMenuManager.Instance.SetActiveMenu(RootMenuManager.ActiveMenu.ConfirmMenu, false);

		var confirm = ((ConfirmMenu) RootMenuManager.Instance.GetActiveMenuComponent(RootMenuManager.ActiveMenu.ConfirmMenu));

		confirm.CallingMenu = gameObject;
		confirm.CallbackFunction = "Confirm";

	}

	/// <summary>
	/// Deletes all game objects from the grid, then clears and resets the list and move point
	/// </summary>
	new public void ClearGrid()
	{
		base.ClearGrid();
		MovePoint = null;
	}

	public void Confirm(int confirmation)
	{
		Debug.Log("IT WORKED!!");
	}

}
