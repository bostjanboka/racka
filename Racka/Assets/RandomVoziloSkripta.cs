using UnityEngine;
using System.Collections;

public class RandomVoziloSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject avto1;
	public GameObject avto2;
	public GameObject avto3;
	public GameObject avto4;
	public GameObject avto5;
	public GameObject avto6;
	public GameObject avto7;
	public GameObject avto8;

	GameObject[] tabela;
	void Awake(){
		tabela = new GameObject[8];
		tabela [0] = avto1;
		tabela [1] = avto2;
		tabela [2] = avto3;
		tabela [3] = avto4;
		tabela [4] = avto5;
		tabela [5] = avto6;
		tabela [6] = avto7;
		tabela [7] = avto8;
	}
	void Start () {



	}
	
	public GameObject vrniVozilo(){
		return tabela[Random.Range(0,tabela.Length)];
	}
}
