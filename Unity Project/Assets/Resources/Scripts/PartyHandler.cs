using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartyHandler : MonoBehaviour  {
	
	GameObject[] _enemies;
	GameObject[] _players;
	int _turn =0;
	int _playerIndex = 0;
	public static int Players = 12;
	int _enemyIndex =0;
	public static int Enemies = 20;

	// Use this for initialization
	void Start () {
		_enemies = GameObject.FindGameObjectsWithTag("Enemies"); //Finds all GameObjects tagged "enemies"
		_players = GameObject.FindGameObjectsWithTag("Heros"); //Finds all GameObjects tagged "heroes"
		_turn = 1;
		_playerIndex = 0;
		Players = 12;
		_enemyIndex = 0;
		Enemies = 0;
	}
	
	//  needs a function to receive a message when an object is destroyed to remove the object from the respective array and decrement the respective counter.

	public GameObject GetActiveCharacter()
	{
		if (_turn % 2 == 0)
		{
			return _enemies[_enemyIndex];
		}
		return _players[_playerIndex];
	}

	public void NextTurn()
	{
		switch (_turn % 2)
		{
			case 0:
				if (_enemyIndex < Enemies)
					_enemyIndex++;
				else
					_enemyIndex = 0;
				break;
			default:
				if (_playerIndex < Players)
					_playerIndex++;
				else
					_playerIndex = 0;
				break;
		}
	}

	//  update should send a message out that tells what the current Character is, and recieve back a list of command objects to be executed.
	public void UpdateEnemyCount(){
		Enemies--;
		if (Enemies == 0)
		  {
			//player wins, return to overworld map scene 1
			//RootMenuManager.Instance.SetActiveMenu(RootMenuManager.Instance.GetActiveMenu); pass it a story file
			Application.LoadLevel("overworld");
  		  }
		}
	public void UpdatePlayerCount(){
		Players--;
		if (Players == 0) 
		  {
		    // game over
			// RootMenuManager.... // pass it a game over story
			Application.LoadLevel("overworld"); // main game menu scene
		  }
		}

	public void EndTurn()
	{
		_turn++;
	}
}
