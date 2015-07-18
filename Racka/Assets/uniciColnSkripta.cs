using UnityEngine;
using System.Collections;

public class uniciColnSkripta : MonoBehaviour {

	// Use this for initialization
	spawnColnSkripta spawn;
	
	void Awake(){
		spawn = transform.parent.GetComponent<spawnColnSkripta> ();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("vozilo")) {
			Debug.Log("unici");
			spawn.zadnji.GetComponent<SkriptaPotujNaprej>().nazaj = other.gameObject;
			other.gameObject.SetActive(false);
			spawn.zadnji = other.gameObject;
		}
	}
}
