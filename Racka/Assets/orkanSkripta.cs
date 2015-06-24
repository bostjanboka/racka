using UnityEngine;
using System.Collections;

public class orkanSkripta : MonoBehaviour {

	// Use this for initialization
	public float histrostVrtenja;
	public float speed = 3;
	public GameObject rackaVOrkanu;
	public GameObject glavnaRacaVOrkanu;
	Vector3 premakni;
	void Start () {
		premakni = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (premakni, transform.position) < 0.1) {
			premakni.x += Random.Range (-5, 6);
			premakni.z += Random.Range (-5, 6);
		} else {
			transform.position = Vector3.MoveTowards(transform.position,premakni,speed*Time.deltaTime);
		}
		transform.Rotate (0,histrostVrtenja*Time.deltaTime,0);

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("raca")) {
			GameObject game = Instantiate(glavnaRacaVOrkanu,Vector3.zero,Quaternion.Euler(0,0,0)) as GameObject;
			game.transform.parent = transform;
			game.transform.position = other.transform.position - game.transform.position;
			Destroy(other.gameObject);

		}
		else if (other.tag.Equals ("otrok")) {
			GameObject game = Instantiate(rackaVOrkanu,Vector3.zero,Quaternion.Euler(0,0,0)) as GameObject;
			game.transform.parent = transform;
			game.transform.position = other.transform.position - game.transform.position;
			Destroy(other.gameObject);
		}
	}
}
