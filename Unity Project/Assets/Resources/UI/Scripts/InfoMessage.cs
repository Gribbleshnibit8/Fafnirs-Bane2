using System;
using UnityEngine;
using System.Collections;

public class InfoMessage : MonoBehaviour
{

	public enum Location
	{
		Top,
		Left,
		Right,
		Conversation
	}

	private static InfoWindow _top;
	private static InfoWindow _left;
	private static InfoWindow _right;
	private static InfoWindow _conversationLabel;

	private static float _topTimer = 0;
	private static float _leftTimer = 0;
	private static float _rightTimer = 0;
	private static float _conversationTimer = 0;

	void Awake()
	{
		_top = GetComponentsInChildren<InfoWindow>()[0];
		_left = GetComponentsInChildren<InfoWindow>()[1];
		_right = GetComponentsInChildren<InfoWindow>()[2];
		//_conversationLabel = GetComponentInChildren<InfoWindow>()[3];
	}

	void Start()
	{
		
	}

	private bool doonce = true;
	void Update()
	{
		if (doonce)
		{
			ShowMessage(Location.Top, "Some Text");
			doonce = false;
		}
	}
	
	// Update is called once per frame
	//void Update () {

	//	if (_topTimer > 0) _topTimer -= Time.deltaTime;
	//	else
	//	{
	//		_topTimer = 0;
	//		_top.Label = "";
	//	}

	//	if (_leftTimer > 0) _leftTimer -= Time.deltaTime;
	//	else
	//	{
	//		_leftTimer = 0;
	//		_left.Label = "";
	//	}

	//	if (_rightTimer > 0) _rightTimer -= Time.deltaTime;
	//	else
	//	{
	//		_rightTimer = 0;
	//		_right.Label = "";
	//	}

	//	if (_conversationTimer > 0) _conversationTimer -= Time.deltaTime;
	//	else
	//	{
	//		_conversationTimer = 0;
	//	}


	//}


	const float defaultDuration = 5f;
 
	// Simple creation: can't be stopped even if lopping
	////--------------------------------------------
	//StartCoroutine(GenericTimer.Start(defaultDuration, true, () =>
	//{
	//  // Do something at the end of the 3 seconds (duration)
	//  //...
	//}));
 
 
	//// Advanced creation: you can launch it later and stop it
	////--------------------------------------------
	//Timer t = new GenericTimer(duration, false, () =>
	//{
	//  //...
	//});
 
	//// Launch the timer
	//StartCoroutine(t.Start());
 
	//// Ask to stop it next frame
	//t.Stop();





	public static void ShowMessage(Location loc, string content, int time, bool background)
	{
		if (loc == Location.Top)
		{
			_top.Label = content;
			_topTimer = time;
			GenericTimer.Start(5, ClearLabel(_top));
		}
		else if (loc == Location.Left)
		{
			_left.Label = content;
			GenericTimer.Start(5, ClearLabel(_left));
		}
		else if (loc == Location.Right)
		{
			_right.Label = content;
			GenericTimer.Start(5, ClearLabel(_right));
		}
		else if (loc == Location.Conversation)
		{
			_conversationLabel.Label = content;
			_conversationTimer = time;
		}
	}

	public static void ShowMessage(Location loc, string content)
	{
		ShowMessage(loc, content, 5, false);
	}


	private static Action ClearLabel(InfoWindow window)
	{
		window.Label = "";
		//window.Background = false;
		return null;
	}


}
