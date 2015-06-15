﻿using UnityEngine;
using System.Collections;

public class RackaSkripta : MonoBehaviour {

	// Use this for initialization
	public float speed;
	Vector3 smer;
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

		/*premik = 0;
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
		transform.position += transform.forward * speed * premik * Time.deltaTime;*/
		InputKey.tocka.y = transform.position.y;
		smer = InputKey.tocka - transform.position;
		float step = speed*Time.deltaTime;
		
		Vector3 newDir = Vector3.RotateTowards(transform.forward,smer,step,0.0f);
		transform.rotation = Quaternion.LookRotation(newDir);
		if(Vector3.Distance(transform.position,InputKey.tocka) > 0.1f){
			transform.position = Vector3.MoveTowards(transform.position, InputKey.tocka, step);
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
