using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/* Root Menu Manager
 * 
 * Keeps track of all submenus, their active status, 
 * and gives access to their menu controller components 
 */

public enum ActiveMenu
{
	TitleMenu = 0,
	OverworldMenu = 1,
	BattleMenu = 2,
	StoryMenu = 3,
	ConfirmMenu = 4,
	None = 5
}

public class RootMenuManager : MonoBehaviour
{

	

	private static RootMenuManager _rootMenu;
	public static RootMenuManager Instance
	{
		get { return _rootMenu ?? (_rootMenu = new RootMenuManager()); }
	}

	public TitleMenu TitleMenu;
	public OverworldMenu OverworldMenu;
	public BattleMenu BattleMenu;
	public StoryMenu StoryMenu;
	public ConfirmMenu ConfirmMenu;
	public InfoMessage InfoMenu;

	private readonly List<Component> _menusList = new List<Component>();
	private readonly List<Component> _blockingList = new List<Component>();


	void Awake()
	{
		_rootMenu = this;

		// Add menus to a list for easier use
		_menusList.Add(TitleMenu);
		_menusList.Add(OverworldMenu);
		_menusList.Add(BattleMenu);
		_menusList.Add(StoryMenu);
		_menusList.Add(ConfirmMenu);

		_blockingList.Add(ConfirmMenu);

		CorrectActiveMenu();
	}

	/// <summary>
	/// Returns the ActiveMenu enum of the currently active menu
	/// </summary>
	/// <returns>Active menu</returns>
	public ActiveMenu GetActiveMenu()
	{
		foreach (var m in _menusList)
			if (m.gameObject.activeSelf)
				return (ActiveMenu) _menusList.IndexOf(m);

		return ActiveMenu.None;
	}

	/// <summary>
	/// Sets the specified menu as active, optionally you can leave the other active menu or menues enabled
	/// </summary>
	/// <param name="menu">The ActiveMenu enum value to set as active</param>
	/// <param name="disableAll">Optional: Disable other menus, false to leave them active</param>
	public void SetActiveMenu(ActiveMenu menu, bool disableAll = true)
	{

		if (disableAll)
			foreach (var m in _menusList)
				m.gameObject.SetActive(false);

		_menusList[(int)menu].gameObject.SetActive(true);
	}


	/// <summary>
	/// Gives the script component of the specified menu
	/// </summary>
	/// <param name="menu">ActiveMenu enum value</param>
	/// <returns>Script component of active menu</returns>
	public Component GetActiveMenuComponent(ActiveMenu menu)
	{
		return _menusList[(int) menu];
	}

	/// <summary>
	/// Returns if a blocking menu is active
	/// </summary>
	/// <returns>A menu is blocking</returns>
	public bool GetIsBlocking()
	{
		foreach (var m in _blockingList)
			if (m.gameObject.activeSelf)
				return true;

		return false;
	}

	/// <summary>
	/// Corrects the active menu to the current scene
	/// </summary>
	/// <returns></returns>
	private void CorrectActiveMenu()
	{
		// Count all menus that are currently active
		var count = _menusList.Count(m => m.gameObject.activeSelf);

		if (count > 1)
		{
			foreach (var m in _menusList)
				m.gameObject.SetActive(false);

			if (Application.loadedLevelName.ToLower().Equals("overworld"))
				OverworldMenu.gameObject.SetActive(true);
			else
				BattleMenu.gameObject.SetActive(true);
		}
	}
}
