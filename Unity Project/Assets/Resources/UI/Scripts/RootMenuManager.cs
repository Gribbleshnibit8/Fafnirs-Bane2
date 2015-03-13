using UnityEngine;

/* Root Menu Manager
 * 
 * Keeps track of all submenus, their active status, 
 * and gives access to their menu controller components 
 */

public class RootMenuManager : MonoBehaviour
{

	public enum ActiveMenu
	{
		TitleMenu,
		OverworldMenu,
		BattleMenu,
		StoryMenu,
		None
	}

	private static GameObject _titleMenu;
	private static GameObject _overworldMenu;
	private static GameObject _battleMenu;
	private static GameObject _storyMenu;
	private static GameObject _infoMenu;


	void Awake()
	{
		_titleMenu = transform.Find("TitleMenu").gameObject;
		_overworldMenu = transform.Find("OverworldMenu").gameObject;
		_battleMenu = transform.Find("BattleMenu").gameObject;
		_storyMenu = transform.Find("StoryMenu").gameObject;
		_infoMenu = transform.Find("InfoMenu").gameObject;
	}


	public static ActiveMenu GetActiveMenu()
	{
		if (_titleMenu.activeSelf)
			return ActiveMenu.TitleMenu;
		if (_overworldMenu.activeSelf)
			return ActiveMenu.OverworldMenu;
		if (_battleMenu.activeSelf)
			return ActiveMenu.BattleMenu;
		if (_storyMenu.activeSelf)
			return ActiveMenu.StoryMenu;

		return ActiveMenu.None;
	}

	public static Component GetActiveMenuComponent(ActiveMenu menu)
	{
		if (menu == ActiveMenu.TitleMenu)
			return _titleMenu.GetComponent<TitleMenu>();

		if (menu == ActiveMenu.OverworldMenu)
			return _overworldMenu.GetComponent<OverworldMenu>();

		if (menu == ActiveMenu.BattleMenu)
			return _battleMenu.GetComponent<BattleMenu>();

		if (menu == ActiveMenu.StoryMenu)
			return _storyMenu.GetComponent<StoryMenu>();

		return null;
	}

}
