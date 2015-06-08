using UnityEngine;
using System.Collections;

public class OtrokSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject zasleduj;
	Vector3 smer;
	public float speed;
	void Start () {
		smer = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (zasleduj) {

			smer = zasleduj.transform.position - transform.position;
			if(smer.magnitude > 2.5f){
				smer.Normalize();
				smer = smer*speed;;
				gameObject.GetComponent<Rigidbody>().velocity = smer;
			}
		}
	}
}
