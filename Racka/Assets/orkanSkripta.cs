using UnityEngine;
using System.Collections;

public class orkanSkripta : MonoBehaviour {

	// Use this for initialization
	public float histrostVrtenja;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,histrostVrtenja*Time.deltaTime,0);

	}
}
