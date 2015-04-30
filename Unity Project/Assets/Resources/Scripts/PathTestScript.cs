using UnityEngine;
using System.Collections;

public class PathTestScript : MonoBehaviour 
{
	MovePath testPath;
	int range;

	// Use this for initialization
	void Start () 
	{
	
		// Test data
		Vector2 startPosition = new Vector2(1.0f, 1.0f);
		Vector2 endPosition = new Vector2(8.0f, 0.0f);
		range = 6;
		
		// Find my path!!!
		testPath = PathFinder.findPath(startPosition, endPosition, range);	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
