using UnityEngine;
using System.Collections;

public class spawnVlakSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject objekt;

	public float zamik=250;
	public float speed=5;
	
	float cas;

	void Start () {
		transform.position += transform.forward * Random.Range (-zamik/2, zamik/2);
		postaviVozila ();
		cas = zamik / speed;
	}
	
	// Update is called once per frame
	void Update () {
		cas -= Time.deltaTime;
		if (cas <= 0) {
			GameObject zac = Instantiate(objekt,transform.position,transform.rotation) as GameObject;
			zac.transform.SetParent(transform.parent);
			cas = zamik / speed;
			zac.GetComponent<SkriptaPotujNaprej>().speed = speed;
			zac.GetComponent<SkriptaPotujNaprej>().zbrisiPoCasu = 280f/speed;
		}
		
		
	}
	
	public void postaviVozila(){
		float vsota = 0;
		for (int i=0; i < 1; i++) {
			vsota = i * zamik;
			GameObject zac = Instantiate(objekt,transform.position + transform.forward*vsota,transform.rotation) as GameObject;
			zac.transform.SetParent(transform.parent);
			zac.GetComponent<SkriptaPotujNaprej>().speed = speed;
			zac.GetComponent<SkriptaPotujNaprej>().zbrisiPoCasu = 280f/speed;
		}
	}
}
