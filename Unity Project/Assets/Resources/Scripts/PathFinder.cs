using UnityEngine;
using System.Collections;


static public class PathFinder
{
	static int range;
	static Vector2 goalPosition;
	static Vector2 startPosition;
	static int closedListSize;
	static ClosedList closedList;
	static MovePath movePath;
	static PathNode pathNode;
	static bool foundPath;

	
	static int findNumOfNodes(int rangeInput)
	{
		if (rangeInput == 0)
		{
			return 1;
		}
		
		else
		{
			return ((4 * rangeInput) + findNumOfNodes(rangeInput - 1));
		}
	}
	
	static public MovePath findPath(Vector2 startPos, Vector2 endPos, int rangeInput)
	{
		foundPath = false;
		range = rangeInput;
		closedListSize = findNumOfNodes(range);
		closedList = new ClosedList(closedListSize);
		goalPosition = endPos;
		startPosition = startPos;
		movePath = new MovePath(range);
		pathNode = new PathNode(startPos, 0);
		pathNode.findChildren();
		
		if (foundPath == false)
		{
			Debug.Log ("There is no path...");
		}
		
		else
		{
			printPath();
		}
		
		return movePath; 
	}
	
	static public Vector2 getStartPos()
	{
		return startPosition;
	}

	static public bool getFoundPath()
	{
		return foundPath;
	}
	
	static public void setFoundPath(bool foundPathInput)
	{
		foundPath = foundPathInput;
	}
	
	static public Vector2 getGoalPosition()
	{
		return goalPosition;
	}
	
	static public int getRange()
	{
		return range;
	}

	static public bool searchClosedList(Vector2 potentialChild)
	{
		return closedList.searchList(potentialChild);
	}
	
	static public bool replaceClosedListEntry(Vector2 potentialChild, double cost)
	{
		return closedList.replaceEntry(potentialChild, cost);
	}
	
	static public void addClosedList(Vector2 potentialChild, double cost)
	{
		closedList.addEntry(potentialChild, cost);
	}
	
	static public void addToPath(Vector2 position)
	{
		movePath.addEntry(position);
	}
	
	static public void printPath()
	{
		movePath.printPath();
	}
}
