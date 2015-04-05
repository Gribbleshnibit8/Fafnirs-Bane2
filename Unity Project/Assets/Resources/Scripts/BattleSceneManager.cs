using UnityEngine;
using System.Collections;

public class BattleSceneManager : MonoBehaviour
{

	public MovementGrid _grid;
	public static MovementGrid Grid;

	public AIScript _character;
	public static AIScript Character;

	void Awake()
	{
		// TODO: Remove after demo
		Grid = GetComponentInChildren<MovementGrid>();
		_grid = Grid;
		Character = GetComponentInChildren<AIScript>();
		_character = Character;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{

	}

	public static void MoveTo(Transform t)
	{
		Character.target = t;
	}
}
