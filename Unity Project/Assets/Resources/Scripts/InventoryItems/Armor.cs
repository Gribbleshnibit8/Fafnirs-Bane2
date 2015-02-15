using UnityEngine;
using System.Collections;

public class Armor : InventoryItem
{
	
	[SerializeField]
	public int ArmorRating = 2;
	
	[SerializeField]
	public string ArmorType = "Light";


	// Use this for initialization
	protected override void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
	}
}
