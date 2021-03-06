﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomCreatorSkripta : MonoBehaviour {

	// Use this for initialization
	GameObject raca;

	public GameObject kmetija;
	public GameObject cesta;
	public GameObject voda;
	public GameObject crte;
	public GameObject zeleznica;
	public GameObject travaSiroka;
	public GameObject trava;
	public GameObject leviBreg;
	public GameObject desniBreg;

	GameObject prejsni;
	GameObject[] tabela;
	Vector3 vec;
	List<GameObject> list;
	int brisi=0;

	RandomVoziloSkripta randomVozilo;
	void Start () {

		randomVozilo = transform.FindChild ("randomVozilo").GetComponent<RandomVoziloSkripta>();

		raca = GameObject.Find ("raca");
		list = new List<GameObject>();
		vec = transform.position;
		tabela = new GameObject[5];
		tabela [0] = cesta;
		tabela [1] = voda;
		tabela [2] = zeleznica;
		tabela [3] = trava;
		tabela [4] = travaSiroka;

		list.Add (Instantiate (kmetija));
		for (int i=0; i < 7; i++) {
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
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (raca && list[list.Count-6].transform.position.z < raca.transform.position.z) {
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
		}
	}

	void dodajElement(GameObject spawn){
		Mesh mesh = spawn.GetComponent<MeshFilter>().sharedMesh;
		Bounds bounds = mesh.bounds;
		vec.z+= bounds.size.z*spawn.transform.localScale.z;
		Vector3 pozicija = spawn.transform.position;
		pozicija.z = vec.z - bounds.size.z/2f*spawn.transform.localScale.z;
		GameObject zac = Instantiate (spawn, pozicija, Quaternion.Euler (0, 0, 0)) as GameObject;
		zac.transform.SetParent (transform);
		list.Add(zac);
	}

	public GameObject vrniRandomVozilo(){
		return randomVozilo.vrniVozilo ();
	}
}
