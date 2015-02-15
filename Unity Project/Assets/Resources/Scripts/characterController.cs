using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour 
{
	static public float moveSpeed = 2.2f;
	static public float moveDistance = 1.0f;
	static Vector2 startPosition = new Vector2(0, 0);
	static Vector2 endPosition = new Vector2(0, 0);

	static public IEnumerator gridMove(GameObject character, float xChange, float yChange, DKControllerScript test)
	{
		// Determine if we are moving in a positive or negative direction
		xChange = signReader (xChange);
		yChange = signReader (yChange);
		
		// The character will move to a set end position.  First, the character will have to appear
		// to be moving towards the position.
		startPosition = character.rigidbody2D.position;
		endPosition = new Vector2(startPosition.x + (moveDistance * xChange), startPosition.y + (moveDistance * yChange));
		character.rigidbody2D.velocity = new Vector2 (moveSpeed * xChange, moveSpeed * yChange);
		
		// The script waits while the character apporaches the position
		while (Vector2.Distance(character.rigidbody2D.position, startPosition) < moveDistance)
		{
			yield return null;
		} 

		// Once the endPosition has been reached, we stop moving and translate over to the new position
		character.rigidbody2D.velocity = new Vector2 (0, 0);
		character.rigidbody2D.position = endPosition;
		test.setMoving(false);

	}

	static private float signReader(float signedValue)
	{
		if (signedValue < 0)
		{
			return -1;
		}

		else if (signedValue > 0)
		{
			return 1;
		}

		else if (signedValue == 0)
		{
			return 0;
		}

		else
		{
			Debug.Log ("An invalid value was entered.  Returning 0");
			return 0;
		}
	}

}
