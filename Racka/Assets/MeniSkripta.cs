using UnityEngine;
using System.Collections;

public class MeniSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject meni;
	public GameObject hud;

	void Awake(){
		hud.SetActive (false);
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void play(){
		meni.SetActive (false);
		hud.SetActive (true);
		InputKey.enableI = true;
	}
}
