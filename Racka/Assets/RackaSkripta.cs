using UnityEngine;
using System.Collections;

public class RackaSkripta : MonoBehaviour {

	// Use this for initialization
	public float speed;
	Vector3 smer;
	void Start () {
		smer = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (InputKey.w) {
			smer.z = 1;
		}
		if (InputKey.a) {
			smer.x = -1;
		}
		if (InputKey.s) {
			smer.z = -1;
		}
		if (InputKey.d) {
			smer.x = 1;
		}

		smer.Normalize ();
		smer *= speed;

		gameObject.GetComponent<Rigidbody> ().velocity = smer;
		smer = Vector3.zero;
	}
}
