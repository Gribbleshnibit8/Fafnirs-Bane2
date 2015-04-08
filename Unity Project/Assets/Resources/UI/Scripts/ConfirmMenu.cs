using UnityEngine;
using System.Collections;

public class ConfirmMenu : MonoBehaviour {

	public void ConfirmAction()
	{
		if (RootMenuManager.GetActiveMenu() == RootMenuManager.ActiveMenu.BattleMenu)
		{
			BattleMenu.Confirm();
		}
	}

	public void CancelAction()
	{
		if (RootMenuManager.GetActiveMenu() == RootMenuManager.ActiveMenu.BattleMenu)
		{
			BattleMenu.Cancel();
		}
		
	}
}
