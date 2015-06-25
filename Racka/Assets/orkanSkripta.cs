using UnityEngine;
using System.Collections;

public class orkanSkripta : MonoBehaviour {

	// Use this for initialization
	public float histrostVrtenja;
	public float speed = 3;
	public GameObject vOrkanu;
	Vector3 premakni;
	void Start () {
		premakni = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (premakni, transform.position) < 0.1) {
			premakni.x += Random.Range (-5, 6);
			premakni.z += Random.Range (-5, 6);
		} else {
			transform.position = Vector3.MoveTowards(transform.position,premakni,speed*Time.deltaTime);
		}
		transform.Rotate (0,histrostVrtenja*Time.deltaTime,0);


	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("raca") || other.tag.Equals ("otrok") || other.tag.Equals ("coln")|| other.tag.Equals ("avto") || other.tag.Equals ("drevo")) {
			/*GameObject game = Instantiate(glavnaRacaVOrkanu,Vector3.zero,Quaternion.Euler(0,0,0)) as GameObject;*/
			GameObject game = sestavi(other.gameObject,gameObject);
			//game.transform.parent = transform;
			game.transform.position = other.transform.position - game.transform.position;
			Destroy(other.gameObject);

		}
	}

	GameObject sestavi(GameObject obj, GameObject stars){
		GameObject game = Instantiate(vOrkanu,Vector3.zero,Quaternion.Euler(0,0,0)) as GameObject;
		if (obj.GetComponent<MeshFilter> ()) {
			game.GetComponent<MeshFilter> ().mesh = obj.GetComponent<MeshFilter> ().mesh;
		}
		if (obj.GetComponent<MeshRenderer> ()) {
			game.GetComponent<MeshRenderer> ().material = obj.GetComponent<MeshRenderer> ().material;
		}
		if (stars != null) {
			game.transform.parent = stars.transform;
		}
		for (int i=0; i < obj.transform.childCount; i++) {
			GameObject otrok = sestavi(obj.transform.GetChild(i).gameObject,game);
			otrok.GetComponent<vOrkanuSkripta>().enable=false;
			otrok.transform.localPosition = obj.transform.GetChild(i).transform.localPosition;
			otrok.transform.localRotation = obj.transform.GetChild(i).transform.localRotation;
			otrok.transform.localScale = obj.transform.GetChild(i).transform.localScale;
		}
		return game;
	}
}
