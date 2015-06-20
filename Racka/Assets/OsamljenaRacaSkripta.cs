using UnityEngine;
using System.Collections;

public class OsamljenaRacaSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject NavadnaRacka;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 180 * Time.deltaTime, 0);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("raca")) {
			GameObject game = Instantiate(NavadnaRacka,transform.position,transform.rotation) as GameObject;
			game.GetComponent<OtrokSkripta>().zasleduj = other.gameObject;
			Destroy(gameObject);
		}
	}
}
