using UnityEngine;

public class Food : InventoryItem
{

	[SerializeField] 
	public int HealthRestored = 2;

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