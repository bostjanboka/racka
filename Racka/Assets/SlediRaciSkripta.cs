using UnityEngine;
using System.Collections;

public class SlediRaciSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject raca;
	public float oddaljenost=6;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = raca.transform.position;
		transform.position += Vector3.up * oddaljenost;
		transform.position += Vector3.forward * -20;
	}
}
