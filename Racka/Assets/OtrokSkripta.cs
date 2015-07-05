using UnityEngine;
using System.Collections;

public class OtrokSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject zasleduj;
	public GameObject zasledujeMe;
	public GameObject povozenaRaca;
	Vector3 smer;
	public float speed;
	void Start () {
		smer = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (zasleduj) {

			smer = zasleduj.transform.position - transform.position;
			float step = speed*Time.deltaTime;

			Vector3 newDir = Vector3.RotateTowards(transform.forward,smer,step,0.0f);
			transform.rotation = Quaternion.LookRotation(newDir);
			if(Vector3.Distance(transform.position,zasleduj.transform.position) > 3f){
				transform.position += transform.forward * step;
			}else{
				//transform.RotateAround (zasleduj.transform.position, Vector3.up, 60 * Time.deltaTime);
			}
		}
	}


	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("kolo")) {
			Instantiate(povozenaRaca,transform.position,transform.rotation);
			if(zasledujeMe){
				zasledujeMe.GetComponent<OtrokSkripta>().zasleduj = zasleduj;
			}
			Destroy(gameObject);
		}
	}
}
