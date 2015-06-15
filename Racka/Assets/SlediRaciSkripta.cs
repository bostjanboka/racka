using UnityEngine;
using System.Collections;

public class SlediRaciSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject raca;
	public float oddaljenost=6;

	public static Camera kamera;
	void Start () {
		kamera = gameObject.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = raca.transform.position;
		transform.position += Vector3.up * oddaljenost;
		transform.position += Vector3.forward * -20;
	}
}
