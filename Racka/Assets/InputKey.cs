using UnityEngine;
using System.Collections;

public class InputKey : MonoBehaviour {

	// Use this for initialization
	static public bool w;
	static public bool a;
	static public bool s;
	static public bool d;

	public static Vector3 tocka;

	void Start () {
		tocka = GameObject.Find ("raca").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		w = Input.GetKey("w");

		a = Input.GetKey("a");

		s = Input.GetKey("s");

		d = Input.GetKey("d");

		foreach (Touch touch in Input.touches) {
			if(touch.phase.Equals(TouchPhase.Began)){
				Ray ray = SlediRaciSkripta.kamera.ScreenPointToRay(Input.mousePosition);
				RaycastHit[] hit;
				hit = Physics.RaycastAll(ray);
				for(int i=0; i < hit.Length; i++){
					if(hit[i].point != null && hit[i].collider.gameObject.tag.Equals("teren") || hit[i].collider.gameObject.tag.Equals("tla")){
						tocka = hit[i].point;
					}
				}

			}
		}

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = SlediRaciSkripta.kamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit[] hit;
			hit = Physics.RaycastAll(ray);
			for(int i=0; i < hit.Length; i++){
				if(hit[i].point != null && hit[i].collider.gameObject.tag.Equals("teren") || hit[i].collider.gameObject.tag.Equals("tla")){
					tocka = hit[i].point;
				}
			}


		}
	}
}
