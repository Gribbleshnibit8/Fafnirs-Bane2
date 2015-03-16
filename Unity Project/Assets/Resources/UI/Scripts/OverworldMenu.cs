using System;
using UnityEngine;

public class OverworldMenu : MonoBehaviour
{

	public static OverworldNode.NodeData OverworldNode;

		#region Unity Functions

		void Awake()
		{

		}

		// Use this for initialization
		void Start () 
		{

		}
	
		// Update is called once per frame
		void Update () 
		{

		}

	#endregion


	/// <summary>
	/// Updates the interface and other data when the player enters a node
	/// </summary>
	/// <param name="node"></param>
	public static void NodeEntered(OverworldNode.NodeData node)
	{
		OverworldNode = node;
		InfoMessage.ShowMessage(InfoMessage.Location.Top, node.Name, 5, true);
		if (!String.IsNullOrEmpty(node.Dungeon)) OverworldActionList.EnterButton.SetActive(true);
		if (node.IsTown) OverworldActionList.ShopButton.SetActive(true);
	}


	public static void NodeExited()
	{
		OverworldActionList.EnterButton.SetActive(false);
		OverworldActionList.ShopButton.SetActive(false);
	}




	#region Menu Buttons

		public void EnterButton()
		{
			Application.LoadLevel(OverworldNode.Dungeon);
		}

	#endregion



}
