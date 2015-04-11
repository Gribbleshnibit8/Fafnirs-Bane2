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

public class BattleMenu : MonoBehaviour
{

	public enum ActionType
	{
		Move,
		Attack,
		Inventory,
		Skillz,
		Menu,
		None
	}

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
			ActionQueue.GetComponentInChildren<UIGrid>().Reposition();
		}

	#endregion

	/// <summary>
	/// Instantiates a new action button, and sets it's position in the action queue,
	/// refreshes the action queue grid, then returns the newly instantiated action.
	/// If the queue is full, it returns a null value.
	/// </summary>
	/// <returns>New action</returns>
	private static GameObject AddActionToQueue()
	{
		GameObject action = null;
		if (ActionQueueList.Count < 5)
		{
			action = Instantiate(Resources.Load("UI/Elements/Action Button Active", typeof(GameObject))) as GameObject;
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
		var action = AddActionToQueue();
		if (action == null) return;

		ActiveActionUpdater.ChangeActionName(action, "Attack");
	}

	public static void ActionSpell()
	{
		Debug.Log("Action Spell Clicked");
		CurrentAction = ActionType.Skillz;
		var action = AddActionToQueue();
		if (action == null) return;

		ActiveActionUpdater.ChangeActionName(action, "Spell");
		ActiveActionUpdater.ChangeActionCostValue(action, 1);
		ActiveActionUpdater.ChangeActionCostColor(action, new Color(0, 130, 188));
	}

	public void ActionMove()
	{
		Debug.Log("Action Move Clicked");
		CurrentAction = ActionType.Move;

		BattleSceneManager.Grid.CreateGrid(BattleSceneManager.Character.transform.position);

		StartCoroutine("WaitForConfirm");

		//var action = AddActionToQueue();
		//if (action == null) return;

		//ActiveActionUpdater.ChangeActionName(action, "Move");

		// TODO: Take into account character's movement range here



	}

	public static void ActionInventory()
	{
		Debug.Log("Action Inventory Clicked");
		CurrentAction = ActionType.Inventory;
		var action = AddActionToQueue();
		if (action == null) return;

		ActiveActionUpdater.ChangeActionName(action, "Inventory");
		ActiveActionUpdater.ChangeActionCostValue(action, 1);
		ActiveActionUpdater.ChangeActionCostColor(action, new Color(188, 0, 0));
	}

	public static void ActionOther()
	{
		Debug.Log("Action Menu Clicked");
		CurrentAction = ActionType.Menu;
		var action = AddActionToQueue();
		if (action == null) return;

		//ActiveActionUpdater.ChangeActionName(action, "Other");
	}
	#endregion

	
	
	IEnumerator WaitForConfirm()
	{
		int i = ConfirmMenu.ConfirmMenuState;
		while (i == 0)
		{
			//Debug.Log("WaitForConfirm Running");
			yield return null;
		}
		if (i == 1) Confirm();
		else Cancel();
	}


	public static void Confirm()
	{
		switch (CurrentAction)
		{
			case ActionType.Attack:
				break;
			case ActionType.Move:
				Debug.Log("Move action was confirmed to location " + MovementGrid.MovePoint);
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
