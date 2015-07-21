using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OsamljenaRacaSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject NavadnaRacka;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 180 * Time.deltaTime, 0);


	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("raca")) {
			GameObject[] tocke = other.gameObject.GetComponent<RackaSkripta>().tocke;
			for(int i=0; i < tocke.Length; i++){
				if(!tocke[i].GetComponent<ZasledujeMeSkripta>().ZasledujeMe){
					GameObject game = Instantiate(NavadnaRacka,transform.position,transform.rotation) as GameObject;
					game.GetComponent<OtrokSkripta>().zasleduj = tocke[i];
					tocke[i].GetComponent<ZasledujeMeSkripta>().ZasledujeMe = game;
					Debug.Log("zasleduje raca");
					RackaSkripta.stRack++;
					Destroy(gameObject);
					break;
				}
			}

		}
	}
}
