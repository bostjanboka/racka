using UnityEngine;
using System.Collections;

public class spawnColnSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject objekt;
	
	public float zamik=70;
	public float speed=5;
	Collider terminator;
	
	float cas;
	
	void Start () {
		//transform.position += transform.forward * Random.Range (0, zamik);
		terminator = transform.FindChild ("terminator").GetComponent<Collider> ();
		postaviVozila ();
		cas = zamik / speed;
	}
	
	// Update is called once per frame
	void Update () {
		cas -= Time.deltaTime;
		if (cas <= 0) {
			GameObject zac = Instantiate(objekt,transform.position,transform.rotation) as GameObject;
			Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
			zac.transform.SetParent(transform.parent);
			cas = zamik / speed;
			zac.GetComponent<SkriptaPotujNaprej>().speed = speed;
			zac.GetComponent<SkriptaPotujNaprej>().zbrisiPoCasu = 180f/speed;
		}
		
		
	}
	
	public void postaviVozila(){
		float vsota = 0;
		for (int i=0; i < 3; i++) {
			vsota = i * zamik;
			GameObject zac = Instantiate(objekt,transform.position + transform.forward*vsota,transform.rotation) as GameObject;
			Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
			zac.transform.SetParent(transform.parent);
			zac.GetComponent<SkriptaPotujNaprej>().speed = speed;
			zac.GetComponent<SkriptaPotujNaprej>().zbrisiPoCasu = 180f/speed;
		}
	}
}
