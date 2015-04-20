using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/* Battle Menu
 * 
 * Handles major input and control during battle scenes.
 * Creates and handles actions generated for each character,
 * then passes them off for actual execution.
 */

public enum ActionType
{
	Move,
	Attack,
	Inventory,
	Skillz,
	Menu,
	None
}

public class BattleMenu : MonoBehaviour
{

	

	public static GameObject ActionQueue { get; private set; }

	private static List<GameObject> ActionQueueList = new List<GameObject>();

	public static VitalBarBasic HealthBar { get; private set; }

	public static VitalBarBasic EnergyBar { get; private set; }

	public static List<UIAnchor> Anchors { get; private set; }

	public static ActionType CurrentAction { get; private set; }


	#region Unity Functions

		void Awake()
		{
			Debug.Log("Action Handler Start");
			CurrentAction = ActionType.None;

			ActionQueue = GameObject.Find("Action Queue");
			Anchors = GetComponentsInChildren<UIAnchor>().ToList();

			foreach (var child in GetComponentsInChildren<VitalBarBasic>())
			{
				if (child.name.Equals("Health Bar"))
					HealthBar = child;
				else if (child.name.Equals("Energy Bar"))
					EnergyBar = child;
			}

		}

		// Use this for initialization
		void Start ()
		{
			HealthBar.MaxValue = 10;
			EnergyBar.MaxValue = 5;
			HealthBar.UpdateDisplay();
			EnergyBar.UpdateDisplay();
		}
	
		// Update is called once per frame
		void Update () 
		{
			//ActionQueue.GetComponentInChildren<UIGrid>().Reposition();
		}

	#endregion

	/// <summary>
	/// Instantiates a new action button, and sets it's position in the action queue,
	/// refreshes the action queue grid, then returns the newly instantiated action.
	/// If the queue is full, it returns a null value.
	/// </summary>
	/// <returns>New action</returns>
	private static GameObject AddActionToQueue(string bName)
	{
		GameObject action = null;
		if (ActionQueueList.Count < 5)
		{
			action = Instantiate(Resources.Load("UI/Elements/Action Button " + bName, typeof(GameObject))) as GameObject;
			action.transform.parent = ActionQueue.transform.GetChild(0);
			action.transform.position = new Vector3(0, 0, 0);
			action.transform.localScale = new Vector3(1, 1, 1);
			ActionQueueList.Add(action);
			ActionQueue.GetComponentInChildren<UIGrid>().Reposition();
		}

		// Temporary code that subtracts 1 energy point per each button added
		// Update the energy display as a percentage of max value
		var f = 1.0f - ((float)ActionQueueList.Count/(float)EnergyBar.MaxValue);
		EnergyBar.UpdateDisplay(f);

		return action;
	}


	#region Action Button Events

	/// <summary>
	/// Creates an attack range grid based on the current character's stats.
	/// If last command is a move, then the attack will take place at the NEW move position, otherwise current position.
	/// </summary>
	public static void ActionAttack()
	{
		Debug.Log("Action Attack Clicked");
		CurrentAction = ActionType.Attack;
		var action = AddActionToQueue("Attack");
		if (action == null) return;

	}

	/// <summary>
	/// Opens the skillz menu, allowing the active character to select from their skillz
	/// </summary>
	public static void ActionSpell()
	{
		Debug.Log("Action Spell Clicked");
		CurrentAction = ActionType.Skillz;
		var action = AddActionToQueue("Skillz");
		if (action == null) return;

	}

	/// <summary>
	/// Creates a new movement grid based on active character stats
	/// </summary>
	public void ActionMove()
	{
		Debug.Log("Action Move Clicked");
		CurrentAction = ActionType.Move;

		BattleSceneManager.Grid.CreateGrid(BattleSceneManager.Character.transform.position);

		BattleSceneManager.Grid.Callback = new ActionMessage(gameObject, "ConfirmMove");
	}

	/// <summary>
	/// Shows the inventory for the party, with the focus of the active character
	/// </summary>
	public void ActionInventory()
	{
		Debug.Log("Action Inventory Clicked");
		CurrentAction = ActionType.Inventory;
		var action = AddActionToQueue("Inventory");
		if (action == null) return;

	}


	public void ActionOther()
	{
		Debug.Log("Action Menu Clicked");
		CurrentAction = ActionType.Menu;
		var action = AddActionToQueue("Other");
		if (action == null) return;

	}

	/// <summary>
	/// Finalizes the action queue and sends it off to the character to execute
	/// </summary>
	public void ActionFinalize()
	{
		BattleSceneManager.ExecuteQueue();
	}

	#endregion


	#region Attack Button Events

	public void AttackUp()
	{
		// TODO: Create action button for queue
		// TODO: Create new action object and add to list
	}

	public void AttackDown()
	{
		
	}

	public void AttackLeft()
	{
		
	}

	public void AttackRight()
	{
		
	}

	#endregion Attack Button Events


	#region Action Finish

	public void ConfirmMove(int[] value)
	{
		switch (value[0])
		{
			case 1:
				var action = AddActionToQueue("Move");
				if (action == null) return;

				var newAction = new CharacterActionMove(ActionType.Move, 1, BattleSceneManager.Grid.MovePoint.position);
				BattleSceneManager.Grid.ClearGrid();

				BattleSceneManager.CharActionList.Add(newAction);

				break;
			case -1:
				// This doesn't really do anything, since we want to ignore a cancel message
				break;
		}
	}

	#endregion Action Finish

}
