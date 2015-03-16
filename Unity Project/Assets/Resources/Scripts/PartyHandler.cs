
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartyHandler : MonoBehaviour
{

	private static PartyHandler _instance;

	/// <summary>
	/// Holds the current party memebers
	/// </summary>
	[SerializeField]
	private List<GameObject> PartyList;




	/// <summary>
	/// Creates an instance of UIInterfaceManager as a gameobject if an instance does not exist
	/// </summary>
	public static PartyHandler Instance
	{
		get { return _instance ?? (_instance = new GameObject("PartyHandler").AddComponent<PartyHandler>()); }
	}


	// TODO possibly add remove via string name instead of gameobject
	public void AddPartyMember(GameObject member)
	{
		// Logic code to ensure that this member is allowed to be in the party
		PartyList.Add(member);
	}

	public void RemovePartyMember(GameObject member)
	{
		// Logic code to ensure that this member is allowed to be in the party
		PartyList.Remove(member);
	}







}
