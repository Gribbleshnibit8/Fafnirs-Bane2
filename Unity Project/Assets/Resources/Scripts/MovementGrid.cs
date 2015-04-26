using UnityEngine;
using System.Collections.Generic;

public class MovementGrid : GridGenerator
{

	public Transform MovePoint;

	public ActionMessage Callback;

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

	/// <summary>
	/// Saves the movement point from the grid and shows confirmation dialog
	/// </summary>
	/// <param name="t">Location passed from grid</param>
	public override void SetPoint(Transform t)
	{
		MovePoint = t;
		RootMenuManager.Instance.SetActiveMenu(ActiveMenu.ConfirmMenu, false);

		var confirm = ((ConfirmMenu) RootMenuManager.Instance.GetActiveMenuComponent(ActiveMenu.ConfirmMenu));

		confirm.Callback = Callback;

	}

	/// <summary>
	/// Deletes all game objects from the grid, then clears and resets the list and move point
	/// </summary>
	new public void ClearGrid()
	{
		base.ClearGrid();
		MovePoint = null;
	}
}
