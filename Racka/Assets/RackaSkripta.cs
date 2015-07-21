using UnityEngine;
using System.Collections;

public class RackaSkripta : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public GameObject zasledujeMe;

	public static int stRack=10;
	Vector3 smer;
	Vector3 rotacija;
	float premik;
	GameObject valovi;
	public GameObject[] tocke;

	void Awake(){
		tocke = new GameObject[10];
		Transform tocket = transform.FindChild("tocke");

		tocke[0] = tocket.FindChild ("t0").gameObject;
		tocke[1] = tocket.FindChild ("t1").gameObject;
		tocke[2] = tocket.FindChild ("t2").gameObject;
		tocke[3] = tocket.FindChild ("t3").gameObject;
		tocke[4] = tocket.FindChild ("t4").gameObject;
		tocke[5] = tocket.FindChild ("t5").gameObject;
		tocke[6] = tocket.FindChild ("t6").gameObject;
		tocke[7] = tocket.FindChild ("t7").gameObject;
		tocke[8] = tocket.FindChild ("t8").gameObject;
		tocke[9] = tocket.FindChild ("t9").gameObject;
	}

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
		
			Vector3 newDir = Vector3.RotateTowards (transform.forward, smer, step*3, 0.0f);
			transform.rotation = Quaternion.LookRotation (newDir);
			if (Vector3.Distance (transform.position, zac) > 0.6f) {
				transform.position+= transform.forward * step;
				//Debug.Log("cudno"+transform.position);
			}else{
				Destroy(InputKey.tocka);
			}
		}

		if (stRack < 1) {
			Application.LoadLevel(Application.loadedLevel);
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
