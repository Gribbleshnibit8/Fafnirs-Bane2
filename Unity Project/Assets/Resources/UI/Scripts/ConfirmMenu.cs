using UnityEngine;
using System.Collections;

public class ConfirmMenu : MonoBehaviour
{

	public GameObject CallingMenu;
	public string CallbackFunction;


	private static ConfirmMenu _confirmMenu;
	public static ConfirmMenu Instance
	{
		get { return _confirmMenu ?? (_confirmMenu = new ConfirmMenu()); }
	}

	void Awake()
	{
		_confirmMenu = this;
	}

	void FixedUpdate()
	{
		//Debug.LogWarning("Confirm Menu: confirm state value is: " + _confirmState);
	}

	public void ConfirmAction()
	{
		Debug.Log("Confirm menu: Confirm clicked");

		CallingMenu.SendMessage(CallbackFunction, 1);
		gameObject.SetActive(false);
	}

	public void CancelAction()
	{
		CallingMenu.SendMessage(CallbackFunction, 1);
		gameObject.SetActive(false);
	}
}
