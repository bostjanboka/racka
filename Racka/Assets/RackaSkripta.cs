using UnityEngine;
using System.Collections;

public class RackaSkripta : MonoBehaviour {

	// Use this for initialization
	public float speed;
	Vector3 smer;
	Vector3 rotacija;
	float premik;
	GameObject valovi;


	void Start () {

		rotacija = Vector3.zero;
		valovi = transform.FindChild ("valovi").gameObject;

	}
	
	// Update is called once per frame
	void Update () {

		if (InputKey.tocka) {
			Vector3 zac = InputKey.tocka.transform.position;
			zac.y = transform.position.y;
			//InputKey.tocka.transform.position = zac;

			smer = zac - transform.position;
			float step = speed * Time.deltaTime;
		
			Vector3 newDir = Vector3.RotateTowards (transform.forward, smer, step, 0.0f);
			transform.rotation = Quaternion.LookRotation (newDir);
			if (Vector3.Distance (transform.position, zac) > 0.1f) {
				transform.position+= transform.forward * step;
				//Debug.Log("cudno"+transform.position);
			}else{
				Destroy(InputKey.tocka);
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
