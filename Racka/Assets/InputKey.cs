using UnityEngine;
using System.Collections;

public class InputKey : MonoBehaviour {

	// Use this for initialization
	static public bool w;
	static public bool a;
	static public bool s;
	static public bool d;

	Vector2 staraPozicija;
	Vector2 zdajPozicija;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		w = Input.GetKey("w");

		a = Input.GetKey("a");

		s = Input.GetKey("s");

		d = Input.GetKey("d");

		foreach (Touch touch in Input.touches) {
			if(touch.phase.Equals(TouchPhase.Began)){
				staraPozicija = touch.position;
			}else if(touch.phase.Equals(TouchPhase.Moved) || touch.phase.Equals(TouchPhase.Stationary)){
				zdajPozicija = touch.position;
				if(zdajPozicija.y - staraPozicija.y > 50){
					w=true;
				}else if(zdajPozicija.y - staraPozicija.y < -50){
					s = true;
				}

				if(zdajPozicija.x - staraPozicija.x > 50){
					d=true;
				}else if(zdajPozicija.x - staraPozicija.x < -50){
					a = true;
				}
			}
		}
	}
}
