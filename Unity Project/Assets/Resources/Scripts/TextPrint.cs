using System;
using UnityEngine;
using System.Collections;

public class TextPrint : MonoBehaviour
{

	public float typingSpeed = 0.2f;

	private string contents;

	private UILabel label;

	private float lastTypedTime;

	private int letterIndex = 0;

	private float storedSpeed = 0.2f;

	private bool done = false;

	// Use this for initialization
	void Start ()
	{
		label = GetComponent<UILabel>();
		if (label != null)
		{
			contents = label.text;
			label.text = "";
		}

	}
	

	// Update is called once per frame
	void Update ()
	{
		lastTypedTime += Time.deltaTime;

		if (Input.anyKeyDown)
		{
			storedSpeed = typingSpeed;
			typingSpeed = 0.01f;
		}
	}


	void FixedUpdate()
	{
		if (lastTypedTime >= typingSpeed && done == false)
		{
			label.text = label.text + GetNextLetter();
			lastTypedTime = 0;
		}
	}


	private string GetNextLetter()
	{
		if (letterIndex < contents.Length)
		{
			var output = contents[letterIndex].ToString();
			if (output == "\n")
				typingSpeed = storedSpeed;
			letterIndex++;
			return output;
		}

		done = true;
		return "";
	}


	private string FinishCurrentLine()
	{
		var next = contents.IndexOf("\n", letterIndex + 1);

		string s = "";
		for (int i = letterIndex; i < next; i++)
		{
			s = contents[i].ToString();
		}
		return s;
	}
}
