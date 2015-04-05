using UnityEngine;
using System.Collections;

public class OverworldActionList : MonoBehaviour
{

	public static GameObject ShopButton;

	public static GameObject EnterButton;


	void Awake()
	{
		ShopButton = GameObject.Find("Action Button - Shop");
		EnterButton = GameObject.Find("Action Button - Enter");
	}
	
}
