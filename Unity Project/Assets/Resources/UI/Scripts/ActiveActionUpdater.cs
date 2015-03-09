using UnityEngine;
using System.Collections;

/* Static class used for updating values on action buttons */

public class ActiveActionUpdater : MonoBehaviour {

	private static Color health = new Color(188, 0, 0);
	private static Color energy = new Color(0, 130, 188);

	private static Color valueUp = new Color(138, 197, 66);
	private static Color valueDown = new Color(227, 73, 30);



	public static void ChangeActionName(GameObject action, string name)
	{
		var settings = action.GetComponent<ActionButtonActive>();
		settings.LabelName = name;
	}

	public static void ChangeActionCostValue(GameObject action, int cost)
	{
		var settings = action.GetComponent<ActionButtonActive>();
		settings.LabelCost = cost.ToString();
	}

	public static void ChangeActionCostColor(GameObject action, Color color)
	{
		var settings = action.GetComponent<ActionButtonActive>();
		settings.LabelCostColor = color;
	}

	public static void ChangeActionGainValue(GameObject action, int cost)
	{
		var settings = action.GetComponent<ActionButtonActive>();
		settings.LabelCost = cost.ToString();
	}

	public static void ChangeActionGainColor(GameObject action, Color color)
	{
		var settings = action.GetComponent<ActionButtonActive>();
		settings.LabelCostColor = color;
	}

}
