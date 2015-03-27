using UnityEngine;
using System.Collections;

public class OverworldManager : MonoBehaviour
{

	public static GameObject Character;


	void Awake()
	{
		Character = GameObject.Find("Character");
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (var i = 0; i < Input.touchCount; ++i)
		{
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
				// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
				if (hitInfo)
				{
					Debug.Log(hitInfo.transform.gameObject.name);
					// Here you can check hitInfo to see which collider has been hit, and act appropriately.
					if (hitInfo.transform.gameObject.GetComponent<OverworldNode>())
						NodeTouched(hitInfo);
				}
			}
		}

		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Clicked");
			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
			// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
			if (hitInfo)
			{
				Debug.Log(hitInfo.transform.gameObject.name);
				// Here you can check hitInfo to see which collider has been hit, and act appropriately.
				if (hitInfo.transform.gameObject.GetComponent<OverworldNode>())
					NodeTouched(hitInfo);
			}
		}

	}

	private void NodeTouched(RaycastHit2D hitObject)
	{
		Character.GetComponent<AIScript>().target = hitObject.transform;
	}




}
