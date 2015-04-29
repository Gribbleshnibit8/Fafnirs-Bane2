/* ---------------------------------------------------------------------------
 * Name: SimpleEnemyAI.cs
 * 
 * Purpose: To provide a very basic AI script for the enemy characters.
 * 
 * Method: Calls the Enemy's actions in a set order for each enemy Character.
 * 			1: Find closest Hero
 * 			2: Move as close as possible to the closest Hero
 * 			3: Attempt to Attack closest Hero if within Range
 * 			4: End Turn
 *
 * Author: William Witten
 * Date: 4/22/2015
 ---------------------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class SimpleEnemyAI : MonoBehaviour {

	GameObject[] players;
	int i = 12;
	
	void start(){
		players = GameObject.FindGameObjectsWithTag("Heros");
		
	}	

	/* ---------------------------------------------------------------------------
	 * Name: getClosestHero()
	 * 
	 * Purpose: To determine the closest enemy to a particular AI controlled
	 * 			Character and returns the Vector2 position of that closest
	 * 			target.
	 * 
	 * Author: William Witten
	 * 
	 * -------------------------------------------------------------------------*/
	public Vector2 getClosestHero()
	{
		int heros = PartyHandler.Players; //gets the number of heros still in the scene
		float closest = 0;
		Vector2 targetVector = new Vector2();
		closest = Vector2.Distance (this.transform.position, players [i].transform.position);
		while (heros != 0)
		{
			
			if(Vector2.Distance(this.transform.position, players[i].transform.position) < closest)
			{
				closest = Vector2.Distance(this.transform.position, players[i].transform.position);
				targetVector = players[i].transform.position;
			}
			heros--;
		}
		return targetVector;
	}

	/*
	public void executeTurn()
	{
		//pass targetVector to chris's movement script
		addMovementToQueue(getClosestEnemy()); //call the add move funtion from ui
			if(vector2.distance(this.transform.position, targetvector) < 2)
				addAttackToQueue(beginAttack()); //call the add Attack function from ui // possibly a bool
			addExecute(); //call the execute queue function from ui/wes
	}
	*/
}
