using UnityEngine;
using System.Collections;

public enum AttackDirection
{
	Up = 1,
	Down = 2,
	Left = 3,
	Right = 4
}

public enum ActionType
{
	Move,
	Attack,
	Inventory,
	Skillz,
	Menu,
	None
}

public class CharacterAction
{

	public ActionType Action = ActionType.None;
	public int Cost = 1;

	public CharacterAction() { }

	public CharacterAction(ActionType action, int cost)
	{
		Action = action;
		Cost = cost;
	}

	protected virtual void PerformAction(){}

}

public class CharacterActionMove : CharacterAction
{

	public Vector2 Position;

	public CharacterActionMove(ActionType action, int cost, Vector2 position)
	{
		Action = action;
		Cost = cost;
		Position = position;
	}

	protected override void PerformAction()
	{
		
	}
	
}

public class CharacterActionAttack : CharacterAction
{
	
	public AttackDirection Direction = AttackDirection.Up;

	public CharacterActionAttack(ActionType action, int cost, AttackDirection direction)
	{
		Action = action;
		Cost = cost;
		Direction = direction;
	}

	protected override void PerformAction()
	{
		
	}
}