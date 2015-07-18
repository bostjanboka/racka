using UnityEngine;
using System.Collections;

public class spawnVlakSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject objekt;

	public float zamik=250;
	public float speed=5;
	Collider terminator;
	float cas;


	RandomCreatorSkripta mapCreator;
	GameObject prvi;
	public GameObject zadnji;
	
	void Awake(){
		Transform mc = transform.parent;
		while (mc.parent != null) {
			mc = mc.parent;
		}


		terminator = transform.FindChild ("terminator").GetComponent<Collider> ();
		GameObject zacasna;
		prvi = Instantiate(objekt) as GameObject;
		zacasna = prvi;
		for (int i=0; i < 2; i++) {
			GameObject vozilo = Instantiate(objekt) as GameObject;
			Physics.IgnoreCollision(vozilo.GetComponent<Collider>(), terminator);
			vozilo.transform.SetParent(transform.parent);
			vozilo.GetComponent<SkriptaPotujNaprej>().speed = speed;
			zacasna.GetComponent<SkriptaPotujNaprej>().nazaj = vozilo;
			zacasna = vozilo;
			zacasna.SetActive(false);
		}
		zadnji = zacasna;
	}

	void Start () {

		postaviVozila ();
		cas = zamik / speed;
	}
	
	// Update is called once per frame
	void Update () {
		cas -= Time.deltaTime;
		if (cas <= 0) {
			GameObject zac = prvi;
			zac.transform.position = transform.position;
			zac.transform.rotation = transform.rotation;
			prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;
			zac.SetActive(false);
			zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;
			cas = zamik / speed;
		}
	}
	
	public void postaviVozila(){
		float vsota = 0;
		for (int i=0; i < 1; i++) {
			vsota = i * zamik;
			GameObject zac = prvi;
			zac.transform.position = transform.position + transform.forward*vsota;
			zac.transform.rotation = transform.rotation;
			prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;
			zac.SetActive(true);
			zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;
			
			
		}
	}
}
