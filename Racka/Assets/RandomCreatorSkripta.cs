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
		
		
		list.Add (Instantiate (kmetija));
		dodajElement(cesta);
		prejsni = cesta;
		for (int i=0; i < 4; i++) {
			GameObject spawn = tabela[Random.Range(0,tabela.Length)];
			if(prejsni == spawn && spawn == cesta){
				dodajElement(crte);
			}else if(spawn == voda && prejsni != voda){
				dodajElement(desniBreg);
			}else if(spawn!= voda && prejsni == voda){
				dodajElement(leviBreg);
			}else if(prejsni == spawn && spawn == zeleznica){
				dodajElement(trava);
				
			}else if(prejsni != travaSiroka && prejsni != spawn && spawn != travaSiroka){
				dodajElement(trava);
			}
			dodajElement(spawn);
			prejsni = spawn;
		}


	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (raca && list[3+brisi].transform.position.z < raca.transform.position.z) {
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
