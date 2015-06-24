using UnityEngine;
using System.Collections;

public class vOrkanuSkripta : MonoBehaviour {

	// Use this for initialization
	public float kot;
	public float speed;
	public float trajanje = 7;
	void Start () {
		transform.Rotate (kot, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.up * speed * Time.deltaTime;

		trajanje -= Time.deltaTime;
		if (trajanje < 0) {
			Destroy(gameObject);
		}
	}


}
