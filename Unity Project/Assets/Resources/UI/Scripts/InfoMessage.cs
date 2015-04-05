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

	public static InfoMessage Instance;

	private static InfoWindow _top;
	private static InfoWindow _left;
	private static InfoWindow _right;
	private static InfoWindow _conversationLabel;

	void Awake()
	{
		Instance = this;

		_top = GetComponentsInChildren<InfoWindow>()[0];
		_left = GetComponentsInChildren<InfoWindow>()[1];
		_right = GetComponentsInChildren<InfoWindow>()[2];
		//_conversationLabel = GetComponentInChildren<InfoWindow>()[3];
	}


	public static void ShowMessage(Location loc, string content, int time, bool background)
	{
		switch (loc)
		{
			case Location.Top:
				_top.Label = content;
				Instance.StartCoroutine(ClearLabel(5, _top));
				break;
			case Location.Left:
				_left.Label = content;
				Instance.StartCoroutine(ClearLabel(5, _left));
				break;
			case Location.Right:
				_right.Label = content;
				Instance.StartCoroutine(ClearLabel(5, _right));
				break;
			case Location.Conversation:
				_conversationLabel.Label = content;
				Instance.StartCoroutine(ClearLabel(5, _conversationLabel));
				break;
		}
	}

	public static void ShowMessage(Location loc, string content)
	{
		ShowMessage(loc, content, 5, false);
	}

	static IEnumerator ClearLabel(int duration, InfoWindow window)
	{
		Debug.Log("Coroutine started");
		yield return new WaitForSeconds(duration);
		window.Label = "";
		window.Background = false;
		Debug.Log("Coroutine finished");
	}


}
