using UnityEngine;
using System.Collections;


public class PathNode
{
	Vector2 position;
	double cost;
	PathNode parent;
	PathNode[] children;
	
	public PathNode()
	{
		position = new Vector2(-99999999f, -99999999f);
		setCost(0.0);
		setParent(null);
	}
	
	public PathNode(Vector2 positionInput, double costInput)
	{
		setPosition(positionInput);
		Debug.Log ("Creating position: " + position);
		setCost(costInput);
		setParent(null);
		children = new PathNode[4];
	}
	
		
	public PathNode(Vector2 positionInput, double costInput, PathNode parentInput)
	{
		setPosition(positionInput);
		Debug.Log ("Creating position: " + position);
		setCost(costInput);
		setParent(parentInput);
		children = new PathNode[4];
	}
	
	bool checkGoal()
	{
		if (position == PathFinder.getGoalPosition())
		{
			Debug.Log ("Found Goal!!");
			return true;
		}
		
		else
		{
			return false;
		}
	}
	
	public void findChildren()
	{
		PathFinder.addClosedList(position, cost);
		Vector2 potentialChild;
		
		if (position == PathFinder.getGoalPosition())
		{
			PathFinder.setFoundPath(true);
			returnPath(this);
			Debug.Log ("Found Path");
		}
		
		else
		{
		
			for (int i = 0; i < 4; i++)
			{
				switch(i)
				{
					case 0:
						potentialChild = new Vector2 (position.x, position.y + 1.0f);
						break;
						
					case 1:
						potentialChild = new Vector2 (position.x, position.y - 1.0f);
						break;
						
					case 2:
						potentialChild = new Vector2 (position.x + 1.0f, position.y);
						break;
						
					case 3:
						potentialChild = new Vector2 (position.x - 1.0f, position.y);
						break;
						
					default:
						Debug.Log ("Default Child Created. AHHH!!!");
						potentialChild = new Vector2 (position.x, position.y + 1.0f);
						break;
				}
				
				if ((PathFinder.replaceClosedListEntry(potentialChild, cost + 1) == true || 
			    	 PathFinder.searchClosedList(potentialChild) == false)
				     && cost < PathFinder.getRange() && PathFinder.getFoundPath() == false)
				{
					Debug.Log (position + " making: " + potentialChild);
					children[i] = new PathNode (potentialChild, cost + 1, this);
				}
			}
			
			for (int j = 0; j < 4; j++)
			{
				if (children[j] != null && PathFinder.getFoundPath() == false)
				{
					children[j].findChildren();     
				}
			}
		}
	}
	
	
	public void setPosition(Vector2 positionInput)
	{
		position = positionInput;
	}
	
	public void setCost(double costInput)
	{
		cost = costInput;
	}
	
	public void setParent(PathNode parentInput)
	{
		parent = parentInput;
	}
	
	public Vector2 getPosition()
	{
		return position;
	}
	
	public double getCost()
	{
		return cost;
	}
	
	public PathNode getParent()
	{
		return parent;
	}
	
	public void returnPath(PathNode node)
	{		
		if (node.getPosition() != PathFinder.getStartPos())
		{
			node.returnPath (node.getParent());
		}

		PathFinder.addToPath (node.getPosition());
	}
	
	
}
