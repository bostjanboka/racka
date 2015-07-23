using UnityEngine;
using System.Collections;

public class SpawnGameObjectSkripta : MonoBehaviour {

	// Use this for initialization

	public float min=30;
	public float med=45;
	public float max=60;

	//public float zamik=45;
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
		//transform.position += transform.forward * Random.Range (-zamik/2, zamik/2);
		terminator = transform.FindChild ("terminator").GetComponent<Collider> ();
		GameObject zacasna;
		prvi = Instantiate(mapCreator.vrniRandomVozilo()) as GameObject;
		zacasna = prvi;
		Physics.IgnoreCollision(zacasna.GetComponent<Collider>(), terminator);
		zacasna.transform.rotation = transform.rotation;
		zacasna.transform.position = transform.position;
		zacasna.transform.SetParent(transform.parent);
		zacasna.GetComponent<SkriptaPotujNaprej>().speed = speed;
		zacasna.GetComponent<SkriptaPotujNaprej>().pozicija = zacasna.transform.localPosition;
		zacasna.SetActive(false);
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
		cas = vrniZamik() / speed;
		transform.parent.gameObject.SetActive (false);
		Debug.Log ("set active");
	}
	
	// Update is called once per frame
	void Update () {
		cas -= Time.deltaTime;
		if (cas <= 0) {
			GameObject zac = prvi;

			zac.transform.localPosition = zac.GetComponent<SkriptaPotujNaprej>().pozicija;
			prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;
			zac.SetActive(true);
			Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
			zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;
			cas = vrniZamik() / speed;
		}


	}

	public void postaviVozila(){
		float vsota = 0;
		for (int i=0; i < 3; i++) {
			vsota = i * vrniZamik();
			GameObject zac = prvi;

			zac.transform.localPosition = zac.GetComponent<SkriptaPotujNaprej>().pozicija;
			zac.transform.position += transform.forward*vsota;

			prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;
			zac.SetActive(true);
			Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
			zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;


		}
	}

	public float vrniZamik(){
		if (Random.Range (0, 100) <= 60) {
			return med;
		} else if (Random.Range (0, 2) == 0) {
			return min;
		} else {
			return max;
		}

	}
}
