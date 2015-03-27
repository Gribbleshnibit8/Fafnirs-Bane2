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

	public static void SetActiveMenu(ActiveMenu menu)
	{
		_titleMenu.SetActive(false);
		_overworldMenu.SetActive(false);
		_battleMenu.SetActive(false);
		_storyMenu.SetActive(false);

		switch (menu)
		{
			case ActiveMenu.TitleMenu:
				_titleMenu.SetActive(true);
				break;
			case ActiveMenu.OverworldMenu:
				_overworldMenu.SetActive(true);
				break;
			case ActiveMenu.BattleMenu:
				_battleMenu.SetActive(true);
				break;
			case ActiveMenu.StoryMenu:
				_storyMenu.SetActive(true);
				break;
		}
	}

	public static Component GetActiveMenuComponent(ActiveMenu menu)
	{
		switch (menu)
		{
			case ActiveMenu.TitleMenu:
				return _titleMenu.GetComponent<TitleMenu>();
			case ActiveMenu.OverworldMenu:
				return _overworldMenu.GetComponent<OverworldMenu>();
			case ActiveMenu.BattleMenu:
				return _battleMenu.GetComponent<BattleMenu>();
			case ActiveMenu.StoryMenu:
				return _storyMenu.GetComponent<StoryMenu>();
			default:
				return null;
		}
	}

}
