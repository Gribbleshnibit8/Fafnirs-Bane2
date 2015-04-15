using System.Collections.Generic;
using UnityEngine;

public class ActionMessage
{

	public GameObject Caller;

	public string Function;

	public ActionMessage(GameObject o, string s)
	{
		Caller = o;
		Function = s;
	}


	public void Send()
	{
		Caller.SendMessage(Function);
	}

	public void Send(List<Object> args)
	{
		Caller.SendMessage(Function, args);
	}

	public void Send<T>(params T[] args)
	{
		Caller.SendMessage(Function, args);
	}

}