using UnityEngine;
using System.Collections;

public class uniciVlakSkripta : MonoBehaviour {

	// Use this for initialization
	spawnVlakSkripta spawn;
	
	void Awake(){
		spawn = transform.parent.GetComponent<spawnVlakSkripta> ();
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
