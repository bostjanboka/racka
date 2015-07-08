using UnityEngine;
using System.Collections;

public class uniciSpawnSkripta : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("vozilo")) {
			Debug.Log("unici");
			Destroy(other.gameObject);
		}
	}
}
