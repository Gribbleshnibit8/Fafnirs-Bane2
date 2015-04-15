using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ConfirmMenu : MonoBehaviour
{

	public ActionMessage Callback;


	private static ConfirmMenu _confirmMenu;
	public static ConfirmMenu Instance
	{
		get { return _confirmMenu ?? (_confirmMenu = new ConfirmMenu()); }
	}

	void Awake()
	{
		_confirmMenu = this;
	}

	public void ConfirmAction()
	{
		Debug.Log("Confirm menu: Confirm clicked");

		Callback.Send(1);
		gameObject.SetActive(false);
	}

	public void CancelAction()
	{
		Callback.Send(-1);
		gameObject.SetActive(false);
	}
}
