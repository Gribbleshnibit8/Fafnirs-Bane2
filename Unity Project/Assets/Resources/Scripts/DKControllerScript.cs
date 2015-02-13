using UnityEngine;
using System.Collections;

public class DKControllerScript : MonoBehaviour 
{
	bool moving = false;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Debug.Log (Input.GetAxis("Vertical"));
		if (Mathf.Abs (Input.GetAxis("Horizontal")) > 0 && moving == false)
		{
			moving = true;
			Debug.Log("You are going sideways!!");
			StartCoroutine(characterController.gridMove(gameObject, Input.GetAxis ("Horizontal"), 0.0f, this));
		}
	
		else if (Mathf.Abs (Input.GetAxis("Vertical")) > 0 && moving == false)
		{
			moving = true;
			Debug.Log("You are going up and down!!");
			StartCoroutine(characterController.gridMove(gameObject, 0.0f, Input.GetAxis ("Vertical"), this));
		}
		
	}

	public void setMoving(bool settingMove)
	{
		moving = settingMove;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log ("hit the collision box");
		if(col.gameObject.CompareTag("walls"))
		{
			Debug.Log ("hit the collision box again");
			rigidbody2D.velocity = new Vector2 (0, 0);
			//rigidbody2D.position = new Vector2 (Mathf.rigidbody2D.position.x;
		}
		if(col.gameObject.CompareTag("newGame"))
		{
			Debug.Log ("hit the newGame box");
			Application.LoadLevel("Test Scene");
		}
		if(col.gameObject.CompareTag("ExitPoint"))
		{
			Debug.Log ("hit the newGame box");
			Application.LoadLevel("graveyard");
		}
		if(col.gameObject.CompareTag("graveyardExit"))
		{
			Debug.Log ("hit the newGame box");
			Application.LoadLevel("crypt");
		}
	}
}
