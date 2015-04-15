using UnityEngine;
using System.Collections;

public enum AttackDirection
{
	Left, Right, Down, Up
}

public class CharacterAction
{

	public ActionType Action = ActionType.None;

	public int Cost = 1;

	public Vector2 Position;

	//public InventoryItem Item = 

	public AttackDirection Direction = AttackDirection.Up;

	public CharacterAction(ActionType action, int cost)
	{
		
	}

	public CharacterAction(ActionType action, int cost, Vector2 position)
	{

	}

	public CharacterAction(ActionType action, int cost, AttackDirection direction)
	{

	}

	public CharacterAction(ActionType action, int cost)
	{

	}
	public CharacterAction(ActionType action)
	{
		
	}

}
