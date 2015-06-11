using UnityEngine;
using System.Collections;

public class SpawnGameObjectSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject objekt;
	public float casRespawna=5;

	float cas;
	void Start () {
		cas = casRespawna;
	}
	
	// Update is called once per frame
	void Update () {
		cas -= Time.deltaTime;
		if (cas <= 0) {
			Instantiate(objekt, transform.position, transform.rotation);

			cas=casRespawna;
		}
	}
}
