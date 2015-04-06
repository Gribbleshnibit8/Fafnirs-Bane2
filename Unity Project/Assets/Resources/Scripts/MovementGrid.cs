using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using X_UniTMX;

public class MovementGrid : MonoBehaviour {

	public enum GridType
	{
		Movement,
		Range
	}
	
	List<GameObject> _grid = null;

	void Awake()
	{
		//CreateGrid(gameObject.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		// Handles touching of the movement grid.
		for (var i = 0; i < Input.touchCount; ++i)
		{
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
				// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
				if (hitInfo)
				{
					Debug.Log(hitInfo.transform.gameObject.name);
					// Here you can check hitInfo to see which collider has been hit, and act appropriately.
					if (hitInfo.transform.gameObject.GetComponent<MovementGridSquare>())
						BattleSceneManager.AddMovePoint(hitInfo.transform);
				}
			}
		}

		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Clicked");
			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
			// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
			if (hitInfo)
			{
				Debug.Log(hitInfo.transform.gameObject.name);
				// Here you can check hitInfo to see which collider has been hit, and act appropriately.
				if (hitInfo.transform.gameObject.GetComponent<MovementGridSquare>())
					BattleSceneManager.AddMovePoint(hitInfo.transform);
			}
		}
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
