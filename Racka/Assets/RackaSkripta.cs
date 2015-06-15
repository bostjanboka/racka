using UnityEngine;
using System.Collections;

public class RackaSkripta : MonoBehaviour {

	// Use this for initialization
	public float speed;
	Vector3 smer;
	Vector3 rotacija;
	float premik;
	GameObject valovi;

	bool tockaPotovanja=false;
	Vector3 staraTocka;
	void Start () {

		rotacija = Vector3.zero;
		valovi = transform.FindChild ("valovi").gameObject;
		staraTocka=InputKey.tocka;
	}
	
	// Update is called once per frame
	void Update () {
		if (!staraTocka.Equals (InputKey.tocka)) {
			tockaPotovanja=true;
			staraTocka=InputKey.tocka;
		}
		if (tockaPotovanja) {
			InputKey.tocka.y = transform.position.y;
			smer = InputKey.tocka - transform.position;
			float step = speed * Time.deltaTime;
		
			Vector3 newDir = Vector3.RotateTowards (transform.forward, smer, step, 0.0f);
			transform.rotation = Quaternion.LookRotation (newDir);
			if (Vector3.Distance (transform.position, InputKey.tocka) > 0.1f) {
				transform.position = Vector3.MoveTowards (transform.position, InputKey.tocka, step);
			}else{
				tockaPotovanja=false;
			}
		}

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
