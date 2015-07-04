using UnityEngine;
using System.Collections;

public class spawnColnSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject objekt;
	
	public float zamik=70;
	
	
	float cas;
	
	void Start () {
		transform.position += transform.forward * Random.Range (0, zamik);
		postaviVozila ();
		cas = 70f / 4f;
	}
	
	// Update is called once per frame
	void Update () {
		cas -= Time.deltaTime;
		if (cas <= 0) {
			GameObject zac = Instantiate(objekt,transform.position,transform.rotation) as GameObject;
			zac.transform.SetParent(transform.parent);
			cas = 70f / 4f;
		}
		
		
	}
	
	public void postaviVozila(){
		float vsota = 0;
		for (int i=0; i < 6; i++) {
			vsota = i * zamik;
			GameObject zac = Instantiate(objekt,transform.position + transform.forward*vsota,transform.rotation) as GameObject;
			zac.transform.SetParent(transform.parent);
			
		}
	}
}
