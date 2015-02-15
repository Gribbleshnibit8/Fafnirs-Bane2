using UnityEngine;
using System.Collections;

public class TransitionScript : MonoBehaviour
{
    public string LinkedScene;

    [SerializeField]
    public string
        LinkedSpawn = "Spawn";

    void OnTriggerEnter2D(Collider2D other)
    {
    	Debug.Log("Entered by " + other.name);
		Transition();
    }
    
    void OnTriggerEnter(Collider other)
    {
		Debug.Log("Entered by " + other.name);
    	Transition();
    }
    
    void Transition()
    {
		GameInstance.NextSpawn = LinkedSpawn;
		Application.LoadLevel(LinkedScene);
    }
}
