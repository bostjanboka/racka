using UnityEngine;
using System.Collections;

public class SlediRaciSkripta : MonoBehaviour {

	// Use this for initialization
	public static Camera kamera;
	public GameObject raca;

	Vector3 stalni;


	void Start () {
		kamera = gameObject.GetComponent<Camera> ();
		stalni = raca.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = raca.transform.position - stalni;
	}
}
