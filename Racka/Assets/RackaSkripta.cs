using UnityEngine;
using System.Collections;

public class RackaSkripta : MonoBehaviour {

	// Use this for initialization
	public float speed;
	float smer;
	Vector3 rotacija;
	float premik;
	//public GameObject kamera;
	GameObject valovi;
	void Start () {

		rotacija = Vector3.zero;
		valovi = transform.FindChild ("valovi").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		premik = 0;
		float rot = 0;

		if (InputKey.w) {

			premik=1;
		}
		if (InputKey.a) {
			rot -= 40*Time.deltaTime;
		}
		if (InputKey.s) {
			premik = -1;
		}
		if (InputKey.d) {
			rot += 40*Time.deltaTime;
		}

		gameObject.transform.Rotate (0,rot,0);
		transform.position += transform.forward * speed * premik * Time.deltaTime;

	}

	void OnTriggerStay(Collider other) {

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("voda")) {
			valovi.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag.Equals ("voda")) {
			valovi.SetActive (false);
		}
	}

}
