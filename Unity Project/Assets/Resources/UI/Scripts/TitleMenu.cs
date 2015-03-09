using UnityEngine;

/* Title Menu
 * 
 * Title menu handles all actions of the main menu and main menu settings menu.
 * Holds all button functions for the main menu.
 */

public class TitleMenu : MonoBehaviour
{

	public enum ActiveMenu
	{
		Main,
		Settings
	}

	public GameObject _mainMenu;
	public GameObject _settingsMenu;


	void Awake()
	{
		_mainMenu = transform.Find("Main Menu").gameObject;
		_settingsMenu = transform.Find("Settings Menu").gameObject;
	}


	public ActiveMenu GetActiveMenu()
	{
		if (_settingsMenu.activeSelf)
			return ActiveMenu.Settings;

		return ActiveMenu.Main;
	}

	#region Button Events

	public void StartButton()
    {
		Debug.Log("Start button clicked");

		// Callback for some message ensuring player wants to start new game before actually starting
		// should check if no saves exist first, requires save manager to be set up.

		// if above is true, start game
        StartGame();
    }


	public void LoadButton()
	{
		Debug.Log("Load Game clicked");
	}

	#endregion Button Events


	private void StartGame()
    {
        Debug.Log("Starting game");
	    _mainMenu.SetActive(false);
        GameInstance.Instance.StartState();
    }

}
