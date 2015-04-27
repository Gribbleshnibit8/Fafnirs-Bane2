using UnityEngine;
using System.Collections;

public class OverworldNode : MonoBehaviour
{

	public struct NodeData
	{
		public string Name;
		public bool IsTown;
		public string Dungeon;

	}

	/// <summary>
	/// The name of this location as will appear on the map
	/// </summary>
	public string Name;

	/// <summary>
	/// Sets whether this node is a town or a dungeon
	/// </summary>
	public bool Town = false;

	/// <summary>
	/// The linked dungeon, if any, for this node
	/// </summary>
	public string Dungeon = "";

	#region Unity Functions


		void OnTriggerEnter2D(Collider2D other)
		{
			Debug.Log("NODE: Collision entered");
			var node = new NodeData {Dungeon = Dungeon, IsTown = Town, Name = Name};
			OverworldMenu.NodeEntered(node);
		}

		void OnTriggerExit2D(Collider2D other)
		{
			OverworldMenu.NodeExited();
		}

	#endregion

	/// <summary>
	/// Sends this node as target to the Character seeker
	/// </summary>
	public void TravelToNode()
	{
		
	}

	/// <summary>
	/// Creates the 
	/// </summary>
	public void EnterNode()
	{
		
	}

}
