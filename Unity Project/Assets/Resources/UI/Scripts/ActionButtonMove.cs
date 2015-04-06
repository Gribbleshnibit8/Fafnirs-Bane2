using UnityEngine;
using System.Collections;

public class ActionButtonMove : ActionButtonActive
{
	public int MoveCost { get; set; }

	public int MoveDistance { get; set; }

	void Awake()
	{

	}

	public void CreateMoveButton(int cost, int distance, string sprite)
	{
		MoveCost = cost;
		LabelLeft = cost.ToString();
		LabelLeftColor = new Color(0, 130, 188);

		MoveDistance = distance;
		LabelRight = distance.ToString();
		LabelRightColor = Color.red;
	}

}
