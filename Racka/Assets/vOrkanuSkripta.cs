using UnityEngine;
using System.Collections;

public class vOrkanuSkripta : MonoBehaviour {

	// Use this for initialization
	public float kot;
	public float speed;
	public float trajanje = 7;
	public bool enable=true;

	Transform orkan=null;
	void Start () {
		if (enable) {
			transform.Rotate (kot, 0, 0);
		}
		orkan = transform.parent;
		while (orkan.parent != null) {
			orkan = orkan.parent;
		}
	}
	
	// Update is called once per frame
	void Update () {
		trajanje -= Time.deltaTime;
		if (trajanje < 6 && !enable) {
			sirota();
		}
		if (transform.position.y > 15) {
			Destroy (gameObject);
		}
		if (enable) {
			transform.position += transform.up * speed * Time.deltaTime;
		}
	}

	void sirota(){
		Debug.Log ("sirota");
		transform.parent = orkan;
		enable = true;
		speed = Random.Range (2.0f, 3.1f);
	}


}
