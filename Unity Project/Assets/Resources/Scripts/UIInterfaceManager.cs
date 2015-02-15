using UnityEngine;
using System.Collections;

public class UIInterfaceManager : MonoBehaviour
{
    private static UIInterfaceManager _instance;

    /// <summary>
    /// Creates an instance of UIInterfaceManager as a gameobject if an instance does not exist
    /// </summary>
    public static UIInterfaceManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameObject("UIInterfaceManager").AddComponent<UIInterfaceManager>();
            
            return _instance;
        }
    }

    private static GameObject _controlsOverlay;
    public static GameObject Overlay
    {
        get {
	        return _controlsOverlay ?? (_controlsOverlay = (GameObject) Instantiate(Resources.Load("UI/Interface")));
        }
    }


    void Start()
    {
        DontDestroyOnLoad(Overlay);
    }


	public void ActionsButtonPress()
	{
		Debug.Log("Pressed the actions button");
	}

	public void MenuButtonPressed()
	{
		Debug.Log("Pressed the menu button");
	}





}
