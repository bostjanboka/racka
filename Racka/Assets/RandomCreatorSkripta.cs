using UnityEngine;
using System.Collections;

public class RandomCreatorSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject cesta;
	public GameObject voda;

	GameObject[] tabela;
	Vector3 vec;
	void Start () {
		vec = Vector3.zero;
		tabela = new GameObject[2];
		tabela [0] = cesta;
		tabela [1] = voda;

		for (int i=0; i < 100; i++) {
			GameObject spawn = tabela[Random.Range(0,2)];
			Mesh mesh = spawn.GetComponent<MeshFilter>().sharedMesh;
			Bounds bounds = mesh.bounds;

			vec.z+= bounds.size.z*spawn.transform.localScale.z;

			Vector3 pozicija = spawn.transform.position;
			pozicija.z = vec.z - bounds.size.z/2f*spawn.transform.localScale.z;
			Instantiate(spawn,pozicija,Quaternion.Euler(0,0,0));


		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
