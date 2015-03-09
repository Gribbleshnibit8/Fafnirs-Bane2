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

	private static UILabel TopLabel;
	private static UILabel LeftLabel;
	private static UILabel RightLabel;
	private static UILabel ConversationLabel;

	private static float topTimer = 0;
	private static float leftTimer = 0;
	private static float rightTimer = 0;

	void Awake()
	{
		TopLabel = GetComponentsInChildren<UILabel>()[0];
	}

	// Use this for initialization
	void Start ()
	{
		TopLabel.text = "";
		ShowMessage(Location.Top, "Here is a message");
	}
	
	// Update is called once per frame
	void Update () {

		if (topTimer > 0) topTimer -= Time.deltaTime;
		else
		{
			topTimer = 0;
			TopLabel.text = "";
		}

		if (leftTimer > 0) leftTimer -= Time.deltaTime;
		else
		{
			leftTimer = 0;
			LeftLabel.text = "";
		}

		if (rightTimer > 0) rightTimer -= Time.deltaTime;
		else
		{
			rightTimer = 0;
			RightLabel.text = "";
		}


	}

	public static void ShowMessage(Location loc, string content)
	{
		if (loc == Location.Top)
			ShowMessageTop(content);
		else if (loc == Location.Left)
			ShowMessageLeft(content);
		else if (loc == Location.Right)
			ShowMessageRight(content);
		else if (loc == Location.Conversation)
			ShowMessageConversation(content);

	}

	private static void ShowMessageTop(string content)
	{
		TopLabel.text = content;
		topTimer = 5;
	}

	private static void ShowMessageLeft(string content)
	{

	}

	private static void ShowMessageRight(string content)
	{

	}

	private static void ShowMessageConversation(string content)
	{

	}





}
