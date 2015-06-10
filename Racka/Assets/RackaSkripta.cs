using UnityEngine;
using System.Collections;

public class RackaSkripta : MonoBehaviour {

	// Use this for initialization
	public float speed;
	float smer;
	Vector3 rotacija;
	Vector3 premik;
	//public GameObject kamera;
	void Start () {

		rotacija = Vector3.zero;

	}
	
	// Update is called once per frame
	void Update () {


		//rotacija = Vector3.zero;
		premik = Vector3.zero;
		float rot = 0;

		if (InputKey.w) {

			premik.z += -1*speed;
		}
		if (InputKey.a) {
			rot -= 40*Time.deltaTime;
		}
		if (InputKey.s) {
			premik.z += 1*speed;
		}
		if (InputKey.d) {
			rot += 40*Time.deltaTime;
		}





		premik.Normalize ();

		gameObject.transform.Rotate (0,rot,0);
		gameObject.transform.Translate(premik * speed*Time.deltaTime);
		//gameObject.transform.Rotate(rotacija);
		//kamera.transform.Translate (premik * smer*Time.deltaTime);


	}
}
