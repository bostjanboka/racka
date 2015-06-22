using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomCreatorSkripta : MonoBehaviour {

	// Use this for initialization
	GameObject raca;

	public GameObject cesta;
	public GameObject voda;

	GameObject[] tabela;
	Vector3 vec;
	List<GameObject> list;
	int brisi=0;
	void Start () {

		raca = GameObject.Find ("raca");
		list = new List<GameObject>();
		vec = Vector3.zero;
		tabela = new GameObject[2];
		tabela [0] = cesta;
		tabela [1] = voda;


		for (int i=0; i < 3; i++) {
			GameObject spawn = tabela[Random.Range(0,2)];
			Mesh mesh = spawn.GetComponent<MeshFilter>().sharedMesh;
			Bounds bounds = mesh.bounds;
			
			vec.z+= bounds.size.z*spawn.transform.localScale.z;
			
			Vector3 pozicija = spawn.transform.position;
			pozicija.z = vec.z - bounds.size.z/2f*spawn.transform.localScale.z;

			list.Add(Instantiate(spawn,pozicija,Quaternion.Euler(0,0,0)) as GameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (list[list.Count-2].transform.position.z < raca.transform.position.z) {
			GameObject spawn = tabela[Random.Range(0,2)];
			Mesh mesh = spawn.GetComponent<MeshFilter>().sharedMesh;
			Bounds bounds = mesh.bounds;
			
			vec.z+= bounds.size.z*spawn.transform.localScale.z;
			
			Vector3 pozicija = spawn.transform.position;
			pozicija.z = vec.z - bounds.size.z/2f*spawn.transform.localScale.z;
			
			list.Add(Instantiate(spawn,pozicija,Quaternion.Euler(0,0,0)) as GameObject);
			Destroy(list[brisi++]);

		}
	}
}
