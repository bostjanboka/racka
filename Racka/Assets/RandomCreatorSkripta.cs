using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomCreatorSkripta : MonoBehaviour {

	// Use this for initialization
	GameObject raca;

	public GameObject cesta;
	public GameObject voda;
	public GameObject crte;
	public GameObject zeleznica;

	GameObject prejsni;
	GameObject[] tabela;
	Vector3 vec;
	List<GameObject> list;
	int brisi=0;
	void Start () {

		raca = GameObject.Find ("raca");
		list = new List<GameObject>();
		vec = transform.position;
		tabela = new GameObject[3];
		tabela [0] = cesta;
		tabela [1] = voda;
		tabela [2] = zeleznica;


		for (int i=0; i < 10; i++) {
			GameObject spawn = tabela[Random.Range(0,3)];
			if(prejsni == spawn && spawn == cesta){
				dodajElement(crte);
			}
			dodajElement(spawn);
			prejsni = spawn;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (raca && list[list.Count-5].transform.position.z < raca.transform.position.z) {
			GameObject spawn = tabela[Random.Range(0,3)];
			if(prejsni == spawn && spawn == cesta){
				dodajElement(crte);
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
		list.Add(Instantiate(spawn,pozicija,Quaternion.Euler(0,0,0)) as GameObject);
	}
}
