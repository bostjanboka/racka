using UnityEngine;
using System.Collections;

public class InputKey : MonoBehaviour {

	// Use this for initialization
	static public bool w;
	static public bool a;
	static public bool s;
	static public bool d;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		w = Input.GetKey("w");

		a = Input.GetKey("a");

		s = Input.GetKey("s");

		d = Input.GetKey("d");

		
	}
}
