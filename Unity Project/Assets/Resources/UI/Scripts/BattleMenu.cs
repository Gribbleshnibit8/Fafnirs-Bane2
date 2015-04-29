using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AnimationOrTween;
using UnityEngine;

/* Battle Menu
 * 
 * Handles major input and control during battle scenes.
 * Creates and handles actions generated for each Character,
 * then passes them off for actual execution.
 */

public class BattleMenu : MonoBehaviour
{
	public GameObject ActionQueue { get; private set; }

	public List<GameObject> ActionQueueList = new List<GameObject>();

	public VitalBarBasic HealthBar { get; private set; }

	public VitalBarBasic EnergyBar { get; private set; }

	public List<UIAnchor> Anchors { get; private set; }

	public ActionType CurrentAction { get; private set; }

	public static BattleMenu Instance;


	#region Unity Functions

		void Awake()
		{
			Instance = this;

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
	private GameObject AddActionToQueue(string bName)
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
	/// Creates an Attack Range grid based on the current Character's stats.
	/// If last command is a move, then the Attack will take place at the NEW move position, otherwise current position.
	/// </summary>
	public void ActionAttack()
	{
		Debug.Log("Action Attack Clicked");
		CurrentAction = ActionType.Attack;

		var menu = GetComponentInChildren<AttackDirectionWindow>();
		menu.gameObject.SetActive(true);
	}

	/// <summary>
	/// Opens the skillz menu, allowing the active Character to select from their skillz
	/// </summary>
	public void ActionSpell()
	{
		Debug.Log("Action Spell Clicked");
		CurrentAction = ActionType.Skillz;
		var action = AddActionToQueue("Skillz");
		if (action == null) return;

	}

	/// <summary>
	/// Creates a new movement grid based on active Character stats
	/// </summary>
	public void ActionMove()
	{
		Debug.Log("Action Move Clicked");
		CurrentAction = ActionType.Move;

		var character = BattleSceneManager.PartyHandler.GetActiveCharacter().GetComponent<Character>();

		Debug.Log("Character is " + character.name + "\n" + character.ToString());

		var position = BattleSceneManager.GetLastPosition();
		var range = BattleSceneManager.PartyHandler.GetActiveCharacter().GetComponent<Character>().Movement;

		BattleSceneManager.Grid.CreateGrid(position, range);

		BattleSceneManager.Grid.Callback = new ActionMessage(gameObject, "ConfirmMove");
	}

	/// <summary>
	/// Shows the inventory for the party, with the focus of the active Character
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
	/// Finalizes the action queue and sends it off to the Character to execute
	/// </summary>
	public void ActionFinalize()
	{
		BattleSceneManager.ExecuteQueue();
	}

	#endregion


	#region Attack Button Events

	public void AttackUp()
	{
		var action = AddActionToQueue("Attack");
		if (action == null) return;
		action.GetComponent<ActionButtonActive>().LabelName = "Attack\nUp";

		var newAction = new CharacterActionAttack(ActionType.Attack, 1, AttackDirection.Up);
		BattleSceneManager.CharActionList.Add(newAction);
	}

	public void AttackDown()
	{
		var action = AddActionToQueue("Attack");
		if (action == null) return;
		action.GetComponent<ActionButtonActive>().LabelName = "Attack\nDown";

		var newAction = new CharacterActionAttack(ActionType.Attack, 1, AttackDirection.Down);
		BattleSceneManager.CharActionList.Add(newAction);
	}

	public void AttackLeft()
	{
		var action = AddActionToQueue("Attack");
		if (action == null) return;
		action.GetComponent<ActionButtonActive>().LabelName = "Attack\nLeft";

		var newAction = new CharacterActionAttack(ActionType.Attack, 1, AttackDirection.Left);
		BattleSceneManager.CharActionList.Add(newAction);
	}

	public void AttackRight()
	{
		var action = AddActionToQueue("Attack");
		if (action == null) return;
		action.GetComponent<ActionButtonActive>().LabelName = "Attack\nRight";

		var newAction = new CharacterActionAttack(ActionType.Attack, 1, AttackDirection.Right);
		BattleSceneManager.CharActionList.Add(newAction);
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
				BattleSceneManager.AddMovePoint(BattleSceneManager.Grid.MovePoint.position);

				BattleSceneManager.CharActionList.Add(newAction);


				BattleSceneManager.ResetCameraScale();

				break;
			case -1:
				// This doesn't really do anything, since we want to ignore a cancel message
				break;
		}
	}

	#endregion Action Finish


	public void ChangeCharacter(Character c)
	{
		EnergyBar.SetValues(c.MaxEnergy);
		EnergyBar.UpdateDisplay(c.Energy);

		HealthBar.SetValues(c.MaxHealth);
		HealthBar.UpdateDisplay(c.Health);
	}



	public void AnimateWindowPanels(bool forward = true)
	{
		foreach (var anchor in Anchors)
		{
			var anim = anchor.GetComponentInChildren<Animation>();

			foreach (AnimationState state in anim)
			{
				var animName = state.name;
				ActiveAnimation.Play(anim, forward ? Direction.Forward : Direction.Reverse);
			}
		}
	}



}
