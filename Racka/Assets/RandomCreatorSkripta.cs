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

	bool vDelovanju=false;

	RandomVoziloSkripta randomVozilo;

	void Awake(){
		int skupaj = verCesta + verVoda + vertrava + verZeleznica;
		int sestevek = 0;
		randomVozilo = transform.FindChild ("randomVozilo").GetComponent<RandomVoziloSkripta>();
		
		raca = GameObject.Find ("raca");
		list = new List<GameObject>();
		vec = Vector3.zero;//transform.position;
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
			zacasna.GetComponent<nazajSkripta>().id = "cesta";
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
			zacasna.GetComponent<nazajSkripta>().id = "voda";
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
			zacasna.GetComponent<nazajSkripta>().id = "zeleznica";
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
			zacasna.GetComponent<nazajSkripta>().id = "siroka";
			inst.transform.SetParent(transform);
			zacasna3 = inst;

		}
		zadnjiSiroka = zacasna3;

		prviCrte = Instantiate (crte) as GameObject;
		prviCrte.transform.SetParent (transform);
		GameObject zacasna4 = prviCrte;
		zacasna4.SetActive (false);
		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(crte) as GameObject;
			zacasna4.GetComponent<nazajSkripta>().nazaj = inst;
			zacasna.GetComponent<nazajSkripta>().id = "crte";
			inst.transform.SetParent(transform);
			zacasna4 = inst;
			zacasna4.SetActive (false);
		}
		zadnjiCrte = zacasna4;

		prviTrava = Instantiate (trava) as GameObject;
		prviTrava.transform.SetParent (transform);
		GameObject zacasna5 = prviTrava;
		zacasna5.SetActive (false);
		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(trava) as GameObject;
			zacasna5.GetComponent<nazajSkripta>().nazaj = inst;
			zacasna.GetComponent<nazajSkripta>().id = "trava";
			inst.transform.SetParent(transform);
			zacasna5 = inst;
			zacasna5.SetActive (false);
		}
		zadnjiTrava = zacasna5;

		prviLevi = Instantiate (leviBreg) as GameObject;
		prviLevi.transform.SetParent (transform);
		GameObject zacasna6 = prviLevi;
		zacasna6.SetActive (false);
		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(leviBreg) as GameObject;
			zacasna6.GetComponent<nazajSkripta>().nazaj = inst;
			zacasna.GetComponent<nazajSkripta>().id = "levi";
			inst.transform.SetParent(transform);
			zacasna6 = inst;
			zacasna6.SetActive (false);
		}
		zadnjiLevi = zacasna6;

		prviDesni = Instantiate (desniBreg) as GameObject;
		prviDesni.transform.SetParent (transform);
		GameObject zacasna7 = prviDesni;
		zacasna7.SetActive (false);
		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(desniBreg) as GameObject;
			zacasna7.GetComponent<nazajSkripta>().nazaj = inst;
			zacasna.GetComponent<nazajSkripta>().id = "desni";
			inst.transform.SetParent(transform);
			zacasna7 = inst;
			zacasna7.SetActive (false);
		}
		zadnjiDesni = zacasna7;

		list.Add (Instantiate (kmetija));



	}

	public void StartPostavitev () {
		dodajElement(prviCesta,cesta);
		prejsni = cesta;
		for (int i=0; i < 4; i++) {
			GameObject spawn = tabela[Random.Range(0,tabela.Length)];
			if(spawn == prejsni && spawn == travaSiroka){
				spawn = cesta;
			}
			if(prejsni == spawn && spawn == cesta){
				dodajElement(prviCrte,crte);
			}else if(spawn == voda && prejsni != voda){
				dodajElement(prviDesni,desniBreg);
			}else if(spawn!= voda && prejsni == voda){
				dodajElement(prviLevi,leviBreg);
			}else if(prejsni == spawn && spawn == zeleznica){
				dodajElement(prviTrava,trava);
				
			}else if(prejsni != travaSiroka && prejsni != spawn && spawn != travaSiroka){
				dodajElement(prviTrava,trava);
			}

			if(spawn == cesta){
				dodajElement(prviCesta,spawn);
			}
			else if(spawn == zeleznica){
				dodajElement(prviZeleznica,spawn);
			}else if(spawn == voda){
				dodajElement(prviVoda,spawn);
			}else{ //if(spawn == travaSiroka){
				dodajElement(prviSiroka,spawn);
			}

			prejsni = spawn;
		}
		vDelovanju = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (raca && vDelovanju && list[list.Count-2].transform.position.z < raca.transform.position.z) {
			GameObject spawn = tabela[Random.Range(0,tabela.Length)];
			if(spawn == prejsni && spawn == travaSiroka){
				spawn = cesta;
			}
			if(prejsni == spawn && spawn == cesta){
				dodajElement(prviCrte,crte);
			}else if(spawn == voda && prejsni != voda){
				dodajElement(prviDesni,desniBreg);
			}else if(spawn!= voda && prejsni == voda){
				dodajElement(prviLevi,leviBreg);
			}else if(prejsni == spawn && spawn == zeleznica){
				dodajElement(prviTrava,trava);
				
			}else if(prejsni != travaSiroka && prejsni != spawn && spawn != travaSiroka){
				dodajElement(prviTrava,trava);
			}

			if(spawn == cesta){
				dodajElement(prviCesta,spawn);
			}
			else if(spawn == zeleznica){
				dodajElement(prviZeleznica,spawn);
			}else if(spawn == voda){
				dodajElement(prviVoda,spawn);
			}else{ //if(spawn == travaSiroka){
				dodajElement(prviSiroka,spawn);
			}
			prejsni = spawn;
			//Destroy(list[brisi++]);

		}
		Debug.Log (list [0].transform.position.z);
		if (raca && vDelovanju && list[2].transform.position.z < raca.transform.position.z) {
			GameObject brisem = list[0];
			Debug.Log("prisem primerek");
			string id = brisem.GetComponent<nazajSkripta>().id;
			brisem.SetActive(false);
			if(id.Equals("cesta")){
				zadnjiCesta.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiCesta = brisem;
			}else if(id.Equals("voda")){
				zadnjiVoda.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiVoda = brisem;
			}else if(id.Equals("zeleznica")){
				zadnjiZeleznica.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiZeleznica = brisem;
			}else if(id.Equals("siroka")){
				zadnjiSiroka.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiSiroka = brisem;
			}else if(id.Equals("levi")){
				zadnjiLevi.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiLevi = brisem;
			}else if(id.Equals("desni")){
				zadnjiDesni.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiDesni = brisem;
			}else if(id.Equals("trava")){
				zadnjiTrava.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiTrava = brisem;
			}else if(id.Equals("crte")){
				zadnjiCrte.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiCrte = brisem;
			}
			list.RemoveAt(0);
		}
	}

	void dodajElement(GameObject spawn, GameObject spawnTabela){
		Mesh mesh = spawn.GetComponent<MeshFilter>().sharedMesh;
		Bounds bounds = mesh.bounds;
		vec.z+= bounds.size.z*spawn.transform.localScale.z;
		Vector3 pozicija = spawn.transform.position;
		pozicija.z = vec.z - bounds.size.z/2f*spawn.transform.localScale.z;
		spawn.transform.localPosition = pozicija;
		spawn.SetActive (true);

		if(spawnTabela == cesta){
			prviCesta = spawn.GetComponent<nazajSkripta>().nazaj;
		}
		else if(spawnTabela == zeleznica){
			prviZeleznica = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawnTabela == voda){
			prviVoda = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawnTabela == travaSiroka){
			prviSiroka = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawnTabela == crte){
			prviCrte = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawnTabela == trava){
			prviTrava = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawnTabela == leviBreg){
			prviLevi = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawnTabela == desniBreg){
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
