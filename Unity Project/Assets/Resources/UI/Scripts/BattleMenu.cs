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

	public static void ActionAttack()
	{
		Debug.Log("Action Attack Clicked");
		CurrentAction = ActionType.Attack;
		var action = AddActionToQueue("Attack");
		if (action == null) return;

	}

	public static void ActionSpell()
	{
		Debug.Log("Action Spell Clicked");
		CurrentAction = ActionType.Skillz;
		var action = AddActionToQueue("Skillz");
		if (action == null) return;

	}

	public void ActionMove()
	{
		Debug.Log("Action Move Clicked");
		CurrentAction = ActionType.Move;

		BattleSceneManager.Grid.CreateGrid(BattleSceneManager.Character.transform.position);

		BattleSceneManager.Grid.Callback = new ActionMessage(gameObject, "ConfirmMove");
	}

	public static void ActionInventory()
	{
		Debug.Log("Action Inventory Clicked");
		CurrentAction = ActionType.Inventory;
		var action = AddActionToQueue("Inventory");
		if (action == null) return;

	}

	public static void ActionOther()
	{
		Debug.Log("Action Menu Clicked");
		CurrentAction = ActionType.Menu;
		var action = AddActionToQueue("Other");
		if (action == null) return;

	}
	#endregion



	#region Action Finish

	public void ConfirmMove(int[] value)
	{
		switch (value[0])
		{
			case 1:
				var action = AddActionToQueue("Move");
				if (action == null) return;
				
				

				break;
			case -1:
				break;
		}
	}

	#endregion Action Finish





	public static void Confirm()
	{
		Debug.Log("Action was confirmed ");
		switch (CurrentAction)
		{
			case ActionType.Attack:
				break;
			case ActionType.Move:
				Debug.Log("Move action was confirmed to location " + MovementGrid.Instance.MovePoint);
				break;
			case ActionType.Inventory:
				break;
			case ActionType.Skillz:
				break;
			case ActionType.Menu:
				break;
			case ActionType.None:
				break;
			default:
				break;
		}
	}

	public static void Cancel()
	{
		switch (CurrentAction)
		{
			case ActionType.Attack:
				break;
			case ActionType.Move:
				break;
			case ActionType.Inventory:
				break;
			case ActionType.Skillz:
				break;
			case ActionType.Menu:
				break;
			case ActionType.None:
				break;
			default:
				break;
		}
	}
}
