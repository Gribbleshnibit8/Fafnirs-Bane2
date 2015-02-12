using UnityEngine;
using System.Collections;

public class ForceZZero : MonoBehaviour
{

		private Transform tr;

		// Use this for initialization
		void Awake ()
		{
				tr = transform;
		}
	
		// Update is called once per frame
		void Update ()
		{
				Vector3 v = tr.position;
				v.z = 0;
				tr.position = v;
		}
}
