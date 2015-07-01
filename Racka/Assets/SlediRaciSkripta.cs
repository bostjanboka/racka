using UnityEngine;
using System.Collections;

public class SlediRaciSkripta : MonoBehaviour {

	// Use this for initialization
	public static Camera kamera;
	public GameObject raca;
	public float gorDol;

	Vector3 stalni;
	Vector3 poX;
	Vector3 kameraPoz;


	void Start () {
		kamera = gameObject.GetComponent<Camera> ();
		stalni = raca.transform.position - transform.position;
		poX = transform.position;
		kameraPoz = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (raca) {
			Vector3 pozicija = raca.transform.position - stalni;
			if(pozicija.x > poX.x-gorDol && pozicija.x < poX.x + gorDol){
				kameraPoz.x = pozicija.x;
			}
			if(pozicija.z > poX.z-gorDol){
				kameraPoz.z = pozicija.z;
			}
			transform.position=kameraPoz;

		}
	}
}
