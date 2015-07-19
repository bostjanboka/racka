using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomCreatorSkripta : MonoBehaviour {

	// Use this for initialization
	GameObject raca;

	public GameObject kmetija;

	public GameObject crte;
	public int verCesta=0;
	public GameObject cesta;
	public int verVoda=0;
	public GameObject voda;
	public int verZeleznica=0;
	public GameObject zeleznica;
	public int vertrava=0;
	public GameObject travaSiroka;

	public GameObject trava;
	public GameObject leviBreg;
	public GameObject desniBreg;

	public GameObject prviCesta;
	public GameObject zadnjiCesta;

	public GameObject prviVoda;
	public GameObject zadnjiVoda;

	public GameObject prviZeleznica;
	public GameObject zadnjiZeleznica;

	public GameObject prviSiroka;
	public GameObject zadnjiSiroka;

	public GameObject prviCrte;
	public GameObject zadnjiCrte;

	public GameObject prviTrava;
	public GameObject zadnjiTrava;

	public GameObject prviLevi;
	public GameObject zadnjiLevi;

	public GameObject prviDesni;
	public GameObject zadnjiDesni;


	GameObject prejsni;
	GameObject[] tabela;
	Vector3 vec;
	List<GameObject> list;
	int brisi=0;

	RandomVoziloSkripta randomVozilo;

	void Awake(){
		int skupaj = verCesta + verVoda + vertrava + verZeleznica;
		int sestevek = 0;
		randomVozilo = transform.FindChild ("randomVozilo").GetComponent<RandomVoziloSkripta>();
		
		raca = GameObject.Find ("raca");
		list = new List<GameObject>();
		vec = transform.position;
		tabela = new GameObject[skupaj];
		for (int i=0; i < verCesta; i++) {
			tabela[i] = cesta;
			
		}
		sestevek += verCesta;
		for (int i=sestevek; i < sestevek+verVoda; i++) {
			tabela[i] = voda;
			
		}
		sestevek += verVoda;
		for (int i=sestevek; i < sestevek+verZeleznica; i++) {
			tabela[i] = zeleznica;
			
		}
		sestevek += verZeleznica;
		for (int i=sestevek; i < sestevek+vertrava; i++) {
			tabela[i] = travaSiroka;
			
		}
		sestevek += vertrava;

		prviCesta = Instantiate (cesta) as GameObject;
		prviCesta.transform.SetParent (transform);
		GameObject zacasna = prviCesta;

		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(cesta) as GameObject;
			zacasna.GetComponent<nazajSkripta>().nazaj = inst;
			inst.transform.SetParent(transform);
			zacasna = inst;

		}
		zadnjiCesta = zacasna;

		prviVoda = Instantiate (voda) as GameObject;
		prviVoda.transform.SetParent (transform);
		GameObject zacasna1 = prviVoda;

		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(voda) as GameObject;
			zacasna1.GetComponent<nazajSkripta>().nazaj = inst;
			inst.transform.SetParent(transform);
			zacasna1 = inst;

		}
		zadnjiVoda = zacasna1;

		prviZeleznica = Instantiate (zeleznica) as GameObject;
		prviZeleznica.transform.SetParent (transform);
		GameObject zacasna2 = prviZeleznica;

		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(zeleznica) as GameObject;
			zacasna2.GetComponent<nazajSkripta>().nazaj = inst;
			inst.transform.SetParent(transform);
			zacasna2 = inst;

		}
		zadnjiZeleznica = zacasna2;

		prviSiroka = Instantiate (travaSiroka) as GameObject;
		prviSiroka.transform.SetParent (transform);
		GameObject zacasna3 = prviSiroka;

		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(travaSiroka) as GameObject;
			zacasna3.GetComponent<nazajSkripta>().nazaj = inst;
			inst.transform.SetParent(transform);
			zacasna3 = inst;

		}
		zadnjiSiroka = zacasna3;

		prviCrte = Instantiate (crte) as GameObject;
		prviCrte.transform.SetParent (transform);
		GameObject zacasna4 = prviCrte;

		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(crte) as GameObject;
			zacasna4.GetComponent<nazajSkripta>().nazaj = inst;
			inst.transform.SetParent(transform);
			zacasna4 = inst;

		}
		zadnjiCrte = zacasna4;

		prviTrava = Instantiate (trava) as GameObject;
		prviTrava.transform.SetParent (transform);
		GameObject zacasna5 = prviTrava;

		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(trava) as GameObject;
			zacasna5.GetComponent<nazajSkripta>().nazaj = inst;
			inst.transform.SetParent(transform);
			zacasna5 = inst;

		}
		zadnjiTrava = zacasna5;

		prviLevi = Instantiate (leviBreg) as GameObject;
		prviLevi.transform.SetParent (transform);
		GameObject zacasna6 = prviLevi;

		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(leviBreg) as GameObject;
			zacasna6.GetComponent<nazajSkripta>().nazaj = inst;
			inst.transform.SetParent(transform);
			zacasna6 = inst;

		}
		zadnjiLevi = zacasna6;

		prviDesni = Instantiate (desniBreg) as GameObject;
		prviDesni.transform.SetParent (transform);
		GameObject zacasna7 = prviDesni;

		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(desniBreg) as GameObject;
			zacasna7.GetComponent<nazajSkripta>().nazaj = inst;
			inst.transform.SetParent(transform);
			zacasna7 = inst;

		}
		zadnjiDesni = zacasna7;

		list.Add (Instantiate (kmetija));



	}

	void Start () {
		dodajElement(prviCesta);
		prejsni = cesta;
		for (int i=0; i < 4; i++) {
			GameObject spawn = tabela[Random.Range(0,tabela.Length)];
			if(prejsni == spawn && spawn == cesta){
				dodajElement(prviCrte);
			}else if(spawn == voda && prejsni != voda){
				dodajElement(prviDesni);
			}else if(spawn!= voda && prejsni == voda){
				dodajElement(prviLevi);
			}else if(prejsni == spawn && spawn == zeleznica){
				dodajElement(prviTrava);
				
			}else if(prejsni != travaSiroka && prejsni != spawn && spawn != travaSiroka){
				dodajElement(prviTrava);
			}

			if(spawn == cesta){
				dodajElement(prviCesta);
			}
			else if(spawn == zeleznica){
				dodajElement(prviZeleznica);
			}else if(spawn == voda){
				dodajElement(prviVoda);
			}else if(spawn == travaSiroka){
				dodajElement(prviSiroka);
			}

			prejsni = spawn;
		}
	}
	
	// Update is called once per frame
	void Update () {
		/*if (raca && list[3+brisi].transform.position.z < raca.transform.position.z) {
			GameObject spawn = tabela[Random.Range(0,tabela.Length)];
			if(prejsni == spawn && spawn == cesta){
				dodajElement(crte);
			}else if(spawn == voda && prejsni != voda){
				dodajElement(desniBreg);
			}else if(spawn!= voda && prejsni == voda){
				dodajElement(leviBreg);
			}
			dodajElement(spawn);
			prejsni = spawn;
			Destroy(list[brisi++]);
		}*/
	}

	void dodajElement(GameObject spawn){
		Mesh mesh = spawn.GetComponent<MeshFilter>().sharedMesh;
		Bounds bounds = mesh.bounds;
		vec.z+= bounds.size.z*spawn.transform.localScale.z;
		Vector3 pozicija = spawn.transform.position;
		pozicija.z = vec.z - bounds.size.z/2f*spawn.transform.localScale.z;
		spawn.transform.position = pozicija;
		spawn.SetActive (true);

		if(spawn == cesta){
			prviCesta = spawn.GetComponent<nazajSkripta>().nazaj;
		}
		else if(spawn == zeleznica){
			prviZeleznica = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawn == voda){
			prviVoda = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawn == travaSiroka){
			prviSiroka = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawn == crte){
			prviCrte = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawn == trava){
			prviTrava = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawn == leviBreg){
			prviLevi = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawn == desniBreg){
			prviDesni = spawn.GetComponent<nazajSkripta>().nazaj;
		}
		//GameObject zac = Instantiate (spawn, pozicija, Quaternion.Euler (0, 0, 0)) as GameObject;
		//zac.transform.SetParent (transform);
		Debug.Log ("dodaj element");
		list.Add(spawn);
	}

	public GameObject vrniRandomVozilo(){
		return randomVozilo.vrniVozilo ();
	}
}
