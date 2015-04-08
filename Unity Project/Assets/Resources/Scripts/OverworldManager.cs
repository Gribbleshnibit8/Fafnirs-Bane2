using UnityEngine;
using System.Collections;

public class OverworldManager : MonoBehaviour
{

	public static GameObject Character;

	private InputHandler input;

	void Awake()
	{
		Character = GameObject.Find("Character");

		input = GetComponent<InputHandler>();
		input.ComponentType = "OverworldNode";
		input.FunctionName = "NodeTouched";
	}

	private void NodeTouched(Transform t)
	{
		Character.GetComponent<AIScript>().target = t;
	}




}
