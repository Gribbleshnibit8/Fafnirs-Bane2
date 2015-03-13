using UnityEngine;
using System.Collections;

public class GenericKeepAlive : MonoBehaviour 
{
	void Awake()
	{
		DontDestroyOnLoad(transform);
	}
}
