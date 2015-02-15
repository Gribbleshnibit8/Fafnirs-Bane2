using UnityEngine;
using System.Collections;


[SerializeField]
public class InventoryItem : MonoBehaviour
{
	[SerializeField]
	public string Name = "Item";

	[SerializeField]
	public int Value = 0;

	[SerializeField]
	public bool IsEnchanted = false;

	[SerializeField]
	public int EnchantmentLevel = 0;

	// TODO make an effect class and types
	[SerializeField]
	public Effect[] Enchantments;

	protected SpriteRenderer Sprite;


	// Use this for initialization
	protected virtual void Start ()
	{
		// set various values for this object
		Sprite = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	protected virtual void Update()
	{
	
	}









}
