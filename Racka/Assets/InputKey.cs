using UnityEngine;
using System.Collections;

public class InputKey : MonoBehaviour {

	// Use this for initialization
	static public bool w;
	static public bool a;
	static public bool s;
	static public bool d;

	public GameObject instTocka;
	public static GameObject tocka;

	void Start () {
		tocka = null;
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
					if(hit[i].point != null && hit[i].collider.gameObject.tag.Equals("teren") || hit[i].collider.gameObject.tag.Equals("tla") || hit[i].collider.gameObject.tag.Equals("voda")){
						//tocka = hit[i].point;
						Destroy(tocka);
						tocka = Instantiate(instTocka,hit[i].point, Quaternion.Euler(90,0,0)) as GameObject;
					}
				}

			}
		}

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = SlediRaciSkripta.kamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit[] hit;
			hit = Physics.RaycastAll(ray);
			for(int i=0; i < hit.Length; i++){
				if(hit[i].point != null && hit[i].collider.gameObject.tag.Equals("teren") || hit[i].collider.gameObject.tag.Equals("tla") || hit[i].collider.gameObject.tag.Equals("voda")){
					Destroy(tocka);
					tocka = Instantiate(instTocka,hit[i].point, Quaternion.Euler(90,0,0)) as GameObject;
				}
			}


		}
	}
}
