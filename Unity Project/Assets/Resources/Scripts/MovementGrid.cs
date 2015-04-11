using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementGrid : MonoBehaviour {

	public enum GridType
	{
		Movement,
		Range
	}

	private static Transform _movePoint = null;
	/// <summary>
	/// 
	/// </summary>
	public static Transform MovePoint
	{
		get
		{
			if (_movePoint == null) return null;
			Transform t = _movePoint;
			_movePoint = null;
			return t;
		}
	}
	
	List<GameObject> _grid = null;

	private InputHandler input;

	void Awake()
	{
		input = GetComponent<InputHandler>();
		input.ComponentType = "MovementGridSquare";
		input.FunctionName = "SetMovePoint";
	}

	public void SetMovePoint(Transform t)
	{
		_movePoint = t;
	}
	
	

	public void SetGridType(GridType gt)
	{
		Sprite sp = null;
		switch (gt)
		{
			case GridType.Movement:
				sp = Resources.Load<Sprite>("Sprites/box-highres");
				break;
			case GridType.Range:
				sp = Resources.Load<Sprite>("Sprites/box-highres-red");
				break;
			default:
				sp = Resources.Load<Sprite>("Sprites/box-highres");
				break;
		}

		foreach (var o in _grid)
		{
			o.GetComponent<SpriteRenderer>().sprite = sp;
		}
	}


	public void ClearGrid()
	{
		foreach (var o in _grid)
		{
			DestroyImmediate(o);
		}
		_grid.Clear();
	}

	/// <summary>
	///	
	/// </summary>
	/// <param name="center"></param>
	/// <param name="height"></param>
	/// <param name="width"></param>
	public void CreateGrid(Vector3 center, int height, int width)
	{ 
		Debug.Log("Creating grid at center: " + center);
		DrawGrid(center, height, width);
		BattleSceneManager.ZoomCameraToScale(height+0.5f);
	}

	public void CreateGrid(Vector3 center)
	{
		CreateGrid(center, 5, 5);
	}

	public void CreateGrid(Vector3 center, int radius)
	{
		CreateGrid(center, radius, radius);
	}


	private void DrawGrid(Vector2 center, int height, int width)
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

		Debug.Log("Grid final center is " + gameObject.transform.position);
	}

	private Vector2 FindOffset(int h, int w)
	{
		var offset = gameObject.transform.position;

		offset.x = offset.x - (w);
		offset.y = offset.y + (h);
		
		return offset;
	}
}
