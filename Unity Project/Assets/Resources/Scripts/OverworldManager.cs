using UnityEngine;
using System.Collections;

public class OverworldManager : MonoBehaviour
{

	public static GameObject Character;

	private InputHandler _input;

	void Awake()
	{
		Character = GameObject.Find("Character");

		_input = GetComponent<InputHandler>();
		_input.ComponentType = "OverworldNode";
		_input.FunctionName = "NodeTouched";
	}

	private void NodeTouched(Transform t)
	{
		Character.GetComponent<AIScript>().target = t;
	}




}
