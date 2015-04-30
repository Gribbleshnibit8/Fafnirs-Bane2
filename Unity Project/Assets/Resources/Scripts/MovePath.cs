using UnityEngine;
using System.Collections;

public class MovePath 
{
	int range;
	Vector2[] movePath;
	int pathPos;
	
	public MovePath(int rangeInput)
	{
		range = rangeInput;
		movePath = new Vector2[range];
		pathPos = 0;
	}
	public void setRange(int rangeInput) 
	{
		range = rangeInput;
	}
	
	public void addEntry(Vector2 position)
	{
		Debug.Log ("Adding " + position + " to location " + pathPos);
		if (pathPos < range)
		{
			movePath[pathPos] = position;
			pathPos++;
		} 
	}
	
	public Vector2 getPosition(int pos)
	{
		return movePath[pos];
	}
	
	public void printPath()
	{
		for (int i = 0; i < range; i++)
		{
			Debug.Log(movePath[i]);
		}
	}
}
