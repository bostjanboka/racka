using UnityEngine;
using System.Collections;

public class RackaSkripta : MonoBehaviour {

	// Use this for initialization
	public float speed;
	float smer;
	Vector3 rotacija;
	Vector3 premik;
	public GameObject kamera;
	void Start () {

		rotacija = Vector3.zero;

	}
	
	// Update is called once per frame
	void Update () {
		smer = 0;

		rotacija = Vector3.zero;
		premik = Vector3.zero;

		if (InputKey.w) {
			smer =  -speed;
		}
		if (InputKey.a) {
			rotacija.y-=20*Time.deltaTime;
		}
		if (InputKey.s) {
			smer = speed;
		}
		if (InputKey.d) {
			rotacija.y+=20*Time.deltaTime;
		}

		premik.z = rotacija.y+1;
		premik.Normalize ();
		gameObject.transform.Translate(premik * smer*Time.deltaTime);
		gameObject.transform.Rotate(rotacija);
		kamera.transform.Translate (premik * smer*Time.deltaTime);


	}
}
