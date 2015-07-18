using UnityEngine;
using System.Collections;

public class SpawnGameObjectSkripta : MonoBehaviour {

	// Use this for initialization


	public float zamik=45;
	public float speed=5;

	Collider terminator;
	float cas;
	RandomCreatorSkripta mapCreator;
	GameObject prvi;
	public GameObject zadnji;

	void Awake(){

	}


	void Start () {
		Transform mc = transform.parent;
		while (mc.parent != null) {
			mc = mc.parent;
		}
		mapCreator = mc.gameObject.GetComponent<RandomCreatorSkripta>();
		transform.position += transform.forward * Random.Range (-zamik/2, zamik/2);
		terminator = transform.FindChild ("terminator").GetComponent<Collider> ();
		GameObject zacasna;
		prvi = Instantiate(mapCreator.vrniRandomVozilo()) as GameObject;
		zacasna = prvi;
		for (int i=0; i < 6; i++) {
			GameObject vozilo = Instantiate(mapCreator.vrniRandomVozilo()) as GameObject;
			Physics.IgnoreCollision(vozilo.GetComponent<Collider>(), terminator);
			vozilo.transform.rotation = transform.rotation;
			vozilo.transform.position = transform.position;
			vozilo.transform.SetParent(transform.parent);
			vozilo.GetComponent<SkriptaPotujNaprej>().speed = speed;
			vozilo.GetComponent<SkriptaPotujNaprej>().pozicija = vozilo.transform.localPosition;
			zacasna.GetComponent<SkriptaPotujNaprej>().nazaj = vozilo;
			zacasna = vozilo;
			zadnji = zacasna;
			zacasna.SetActive(false);
		}

		postaviVozila ();
		cas = zamik / speed;

	}
	
	// Update is called once per frame
	void Update () {
		cas -= Time.deltaTime;
		if (cas <= 0) {
			GameObject zac = prvi;
			zac.SetActive(true);
			Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
			zac.transform.localPosition = zac.GetComponent<SkriptaPotujNaprej>().pozicija;
			prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;

			zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;
			cas = zamik / speed;
		}


	}

	public void postaviVozila(){
		float vsota = 0;
		for (int i=0; i < 3; i++) {
			vsota = i * zamik;
			GameObject zac = prvi;
			zac.SetActive(true);
			Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
			zac.transform.localPosition = zac.GetComponent<SkriptaPotujNaprej>().pozicija;
			zac.transform.position += transform.forward*vsota;

			prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;

			zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;


		}
	}
}
