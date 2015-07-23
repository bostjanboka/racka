using UnityEngine;
using System.Collections;

public class OtrokSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject zasleduj;
	public GameObject zasledujeMe;
	public GameObject povozenaRaca;
	public GameObject osamljenaRaca;
	Vector3 smer;
	public float speed;
	void Start () {
		smer = Vector3.zero;
		if(zasleduj)
			zasleduj.GetComponent<ZasledujeMeSkripta> ().ZasledujeMe = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (zasleduj) {

			smer = zasleduj.transform.position - transform.position;
			float step = speed*Time.deltaTime;

			Vector3 newDir = Vector3.RotateTowards(transform.forward,smer,60,0.0f);
			transform.rotation = Quaternion.LookRotation(newDir);
			if(Vector3.Distance(transform.position,zasleduj.transform.position) > 0.1f){
				transform.position += transform.forward * step;
			}else{
				//transform.RotateAround (zasleduj.transform.position, Vector3.up, 60 * Time.deltaTime);
			}
		}
	}


	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("kolo")) {
			Instantiate (povozenaRaca, transform.position, transform.rotation);
			RackaSkripta.stRack--;
			/*if(zasledujeMe){
				zasledujeMe.GetComponent<OtrokSkripta>().zasleduj = zasleduj;
				if(zasleduj.tag.Equals("raca")){
					zasleduj.GetComponent<RackaSkripta>().zasledujeMe = zasledujeMe;
				}else{
					zasleduj.GetComponent<OtrokSkripta>().zasledujeMe = zasledujeMe;
				}
			}*/
			Destroy (gameObject);
		} else if (other.tag.Equals ("coln")) {
			Instantiate (osamljenaRaca, transform.position, transform.rotation);
			RackaSkripta.stRack--;
			Destroy (gameObject);
		}
	}
}
