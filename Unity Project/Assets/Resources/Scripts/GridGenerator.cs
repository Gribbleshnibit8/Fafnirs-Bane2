using UnityEngine;
using System.Collections.Generic;

public class GridGenerator : MonoBehaviour
{

	/// <summary>
	/// A prefab from Resources/Prefabs that represents an object of GridSquare
	/// </summary>
	public string GridObject = null;
	
	protected List<GameObject> _grid = null;

	protected InputHandler _input;

	public void Awake()
	{
		_input = GetComponent<InputHandler>();
		_input.ComponentType = "MovementGridSquare";
		_input.FunctionName = "SetPoint";
	}


	public virtual void SetPoint(Transform t) { }
	

	/// <summary>
	/// Deletes all game objects from the grid, then clears and resets the list and move point
	/// </summary>
	public virtual void ClearGrid()
	{
		foreach (var o in _grid)
		{
			DestroyImmediate(o);
		}
		_grid.Clear();
	}

	#region Create Grid

	/// <summary>
	///	Creates a grid of GridSquares
	/// </summary>
	/// <param name="center">The point at which the grid should be centered</param>
	/// <param name="height">Height from the center for one side</param>
	/// <param name="width">Width from the center for one side</param>
	public void CreateGrid(Vector3 center, int height, int width)
	{ 
		Debug.Log("Creating grid at center: " + center);
		DrawGrid(center, height, width);
		BattleSceneManager.ZoomCameraToScale(height+0.5f);
	}

	/// <summary>
	///	Creates a grid of GridSquares with default size of 5 from the center
	/// </summary>
	/// <param name="center">The point at which the grid should be centered</param>
	public void CreateGrid(Vector3 center)
	{
		CreateGrid(center, 5, 5);
	}

	/// <summary>
	/// Creates a grid of GridSquares with a defined radius
	/// </summary>
	/// <param name="center">The point at which the grid should be centered</param>
	/// <param name="radius">The radius of the grid</param>
	public void CreateGrid(Vector3 center, int radius)
		{
			CreateGrid(center, radius, radius);
		}

	#endregion Create Grid


	protected void DrawGrid(Vector2 center, int height, int width)
	{
		_grid = new List<GameObject>();

		//center.x = (float)Math.Floor(center.x);
		//center.y = (float)Math.Ceiling(center.y);

		var offset = FindOffset(height, width);
		Debug.Log("Initial point is: " + offset);

		var originalx = offset.x;

		height *= 2;
		width *= 2;

		for (int i = 0; i <= height; i++)
		{
			for (int j = 0; j <= width; j++)
			{
				var square = Instantiate(Resources.Load("Prefabs/GridSquare", typeof(GameObject))) as GameObject;
				if (square != null)
				{
					square.transform.position = offset;
					square.transform.parent = gameObject.transform;
					_grid.Add(square);
				}
				offset.x++;
			}
			offset.y--;
			offset.x = originalx;
		}

		gameObject.transform.position = new Vector3(center.x, center.y, gameObject.transform.position.z);

		Debug.Log("Grid final center is " + gameObject.transform.position);
	}

	protected Vector2 FindOffset(int h, int w)
	{
		var offset = gameObject.transform.position;

		offset.x = offset.x - (w);
		offset.y = offset.y + (h);
		
		return offset;
	}
}
