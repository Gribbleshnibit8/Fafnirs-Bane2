using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

	public bool InputReceived { get; private set; }

	public string ComponentType { get; set; }

	public string FunctionName { get; set; }
	
	// Update is called once per frame
	void Update()
	{
		if (RootMenuManager.Instance.GetIsBlocking())
			return;
		// Handles touching of the movement grid.
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
					if (hitInfo.transform.gameObject.GetComponent(ComponentType))
						SendMessage(FunctionName, hitInfo.transform);
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
				if (hitInfo.transform.gameObject.GetComponent(ComponentType))
					SendMessage(FunctionName, hitInfo.transform);
			}
		}
	}
}
