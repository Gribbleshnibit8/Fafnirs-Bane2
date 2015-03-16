using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour
{

	[SerializeField]
	public string Name;

	[SerializeField]
	public bool Detrimental;

	[SerializeField]
	public bool SingleShot;

	[SerializeField, Range(0,20)]
	public int Magnitude;

	/// <summary>
	/// Duration of the effect in seconds
	/// </summary>
	[SerializeField, Range(1, 300)]
	public int Duration;



	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
