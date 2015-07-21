using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeniSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject meni;
	public GameObject hud;

	public Text bestScore;
	public Text Score;
	public Text stRack;
	void Awake(){
		hud.SetActive (false);
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
		InputKey.enableI = true;
	}
}
