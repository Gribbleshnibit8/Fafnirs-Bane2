using UnityEngine;
using System.Collections;

public class ClosedListNode
{
	Vector2 position;
	double cost;
	
	public ClosedListNode(Vector2 positionInput, double costInput)
	{
		position = new Vector2 (positionInput.x, positionInput.y);
		cost = costInput;
	}
	
	public double getCost()
	{
		return cost;
	}
	
	public Vector2 getPosition()
	{
		return position;
	}
}
