using UnityEngine;
using System.Collections;

public class ClosedList
{
	int closedListSize;
	ClosedListNode[] closedList;
	
	public ClosedList(int closedListSizeInput)
	{
		closedListSize = closedListSizeInput;
		closedList = new ClosedListNode[closedListSize];
		
		for (int i = 0; i < closedListSize; i++)
		{
			closedList[i] = new ClosedListNode(new Vector2(-99999999f, -99999999f), 999);
		}
	}
	
	public void setSize(int numOfNodes)
	{
		closedListSize = numOfNodes;
	}
	
	public Vector2 getChild (int key)
	{
		return closedList[key].getPosition();
	}
	
	public void addEntry(Vector2 potentialChild, double cost)
	{
		int key = ((int)(potentialChild.x * potentialChild.y)) % closedListSize;
		int counter = 0;
		bool addedChild = false;
		
		if (key < 0)
		{
			key = key * -1;
		}
		
		while (counter < closedListSize && addedChild == false)
		{			
			if (closedList[key] == new ClosedListNode(new Vector2(-99999999f, -99999999f), 999))
			{	
				closedList[key] = new ClosedListNode(potentialChild, cost);
				addedChild = true;
			}
			
			else 
			{
				if (key == (closedListSize - 1))
				{
					key = 0;
				}
				
				else
				{
					key++;
				}
				
				counter++;
			}
		}
	}
	
	public bool searchList(Vector2 potentialChild)
	{
		int key = ((int)(potentialChild.x * potentialChild.y)) % closedListSize;
		int counter = 0;
		bool foundEntry = false;
		
		if (key < 0)
		{
			key = key * -1;
		}
		
		while (counter < closedListSize && foundEntry == false)
		{			
			if (closedList[key].getPosition() == potentialChild)
			{	
				foundEntry = true;
			}
			
			else 
			{
				if (key == (closedListSize - 1))
				{
					key = 0;
				}
				
				else
				{
					key++;
				}
				
				counter++;
			}
		}
		
		return foundEntry;
	}
	
	public bool replaceEntry(Vector2 potentialChild, double cost)
	{
		int key = ((int)(potentialChild.x * potentialChild.y)) % closedListSize;
		int counter = 0;
		bool replacedChild = false;
		
		if (key < 0)
		{
			key = key * -1;
		}
		
		while (counter < closedListSize && replacedChild == false)
		{			
			if (closedList[key].getPosition() == potentialChild && closedList[key].getCost() > cost)
			{	
				closedList[key] = new ClosedListNode(potentialChild, cost);
				replacedChild = true;
			}
				
			else 
			{
				if (key == (closedListSize - 1))
				{
					key = 0;
				}
				
				else
				{
					key++;
				}
				
				counter++;
			}
		}
			
		return replacedChild;
	}
}
