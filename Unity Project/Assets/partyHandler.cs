using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class partyHandler : MonoBehaviour  {
	
	GameObject[] enemies;
	GameObject[] players;
	int turn =0;
	int i = 0;
	public static int Players = 12;
	int j =0;
	int Enemies = 20;

	// Use this for initialization
	void Start () {
		enemies = GameObject.FindGameObjectsWithTag("Enemies"); //Finds all GameObjects tagged "enemies"
		players = GameObject.FindGameObjectsWithTag("Heros"); //Finds all GameObjects tagged "heroes"
		turn = 1;
		i = 0;
		Players = 12;
		j = 0;
		Enemies = 0;
	}
	
	//  needs a function to receive a message when an object is destroyed to remove the object from the respective array and decrement the respective counter.

	public GameObject GetActiveCharacter()
	{
		if (turn % 2 == 0)
		{
			return enemies[j];
		}
		return players[i];
	}

	public void NextTurn() {
		if (turn % 2 == 0)
		{
			if (j < Enemies)
				j++;
			else
				j = 0;
		}
		else
		{
			if (i < Players)
				i++;
			else
				i = 0;
		}
	}

	//  update should send a message out that tells what the current Character is, and recieve back a list of command objects to be executed.
	public void updateEnemyCount(){
		Enemies--;
		if (Enemies == 0)
		  {
			//player wins, return to overworld map scene 1
			//RootMenuManager.Instance.SetActiveMenu(RootMenuManager.Instance.GetActiveMenu); pass it a story file
			Application.LoadLevel("overworld");
  		  }
		}
	public void updatePlayerCount(){
		Players--;
		if (Players == 0) 
		  {
		    // game over
			// RootMenuManager.... // pass it a game over story
			Application.LoadLevel("overworld"); // main game menu scene
		  }
		}

	public void endTurn()
	{
		turn++;
	}
}
