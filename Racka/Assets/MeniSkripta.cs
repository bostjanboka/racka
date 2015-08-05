using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeniSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject kamera;
	public GameObject meni;
	public GameObject hud;
	public GameObject loose;

	public Text bestScore;
	public Text Score;
	public Text stRack;

	float tocke;
	float zacetna;
	void Awake(){
		hud.SetActive (false);
		loose.SetActive (false);
		zacetna = kamera.transform.position.z;
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		stRack.text = RackaSkripta.stRack+" / 10";

	}


	public void play(){
		meni.SetActive (false);
		hud.SetActive (true);
		loose.SetActive (false);
		InputKey.enableI = true;
	}

	public void reset(){
		InputKey.enableI = false;
		hud.SetActive (false);
		loose.SetActive (false);
		meni.SetActive (true);
	}

	public void lost(){
		InputKey.enableI = false;
		//hud.SetActive (false);
		loose.SetActive (true);
	}
}
