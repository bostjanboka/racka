using UnityEngine;
using System.Collections;

public class SkriptaPotujNaprej : MonoBehaviour {

	// Use this for initialization
	public float speed=4;
	public float zbrisiPoCasu = 40;

	float casNastanka;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position+= (transform.forward * speed * Time.deltaTime);

		zbrisiPoCasu -= Time.deltaTime;
		if (zbrisiPoCasu <= 0) {
			//Destroy(gameObject);
		}
	}
}
