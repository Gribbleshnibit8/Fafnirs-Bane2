using System.Collections.Generic;
using UnityEngine;

/* Battle Menu
 * 
 * Handles major input and control during battle scenes.
 * Creates and handles actions generated for each character,
 * then passes them off for actual execution.
 */

public class BattleMenu : MonoBehaviour
{
	public GameObject ActionQueue;

	private List<GameObject> ActionList = new List<GameObject>();

	public  VitalBarBasic HealthBar;

	public VitalBarBasic EnergyBar;


	#region Unity Functions

		void Awake()
		{
			Debug.Log("Action Handler Start");
			ActionQueue = GameObject.Find("Action Queue");

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
	private GameObject AddActionToQueue()
	{
		GameObject action = null;
		if (ActionList.Count < 5)
		{
			action = Instantiate(Resources.Load("UI/Elements/Action Button Active", typeof(GameObject))) as GameObject;
			action.transform.parent = ActionQueue.transform.GetChild(0);
			action.transform.position = new Vector3(0, 0, 0);
			action.transform.localScale = new Vector3(1, 1, 1);
			ActionList.Add(action);
			ActionQueue.GetComponentInChildren<UIGrid>().Reposition();
		}

		// Temporary code that subtracts 1 energy point per each button added
		// Update the energy display as a percentage of max value
		var f = 1.0f - ((float)ActionList.Count/(float)EnergyBar.MaxValue);
		EnergyBar.UpdateDisplay(f);

		return action;
	}


	#region Action Button Events

	public void ActionAttack()
	{
		Debug.Log("Action Attack Clicked");
		var action = AddActionToQueue();
		if (action == null) return;

		ActiveActionUpdater.ChangeActionName(action, "Attack");

	}

	public void ActionSpell()
	{
		Debug.Log("Action Spell Clicked");
		var action = AddActionToQueue();
		if (action == null) return;

		ActiveActionUpdater.ChangeActionName(action, "Spell");
		ActiveActionUpdater.ChangeActionCostValue(action, 1);
		ActiveActionUpdater.ChangeActionCostColor(action, new Color(0, 130, 188));
	}

	public void ActionMove()
	{
		Debug.Log("Action Move Clicked");
		var action = AddActionToQueue();
		if (action == null) return;

		ActiveActionUpdater.ChangeActionName(action, "Move");

		BattleSceneManager.Grid.CreateGrid(BattleSceneManager.Character.transform.position);
	}

	public void ActionInventory()
	{
		Debug.Log("Action Inventory Clicked");
		var action = AddActionToQueue();
		if (action == null) return;

		ActiveActionUpdater.ChangeActionName(action, "Inventory");
		ActiveActionUpdater.ChangeActionCostValue(action, 1);
		ActiveActionUpdater.ChangeActionCostColor(action, new Color(188, 0, 0));
	}

	public void ActionOther()
	{
		Debug.Log("Action Menu Clicked");
		var action = AddActionToQueue();
		if (action == null) return;

		//ActiveActionUpdater.ChangeActionName(action, "Other");
	}
	#endregion

}
