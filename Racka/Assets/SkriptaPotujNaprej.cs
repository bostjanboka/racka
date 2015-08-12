using UnityEngine;
using System.Collections;

public class SkriptaPotujNaprej : MonoBehaviour {

	// Use this for initialization
	public float speed=4;
	public GameObject nazaj;
	public Vector3 pozicija;

	public float size=0;
	public float zamik;

	float casNastanka;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position+= (transform.forward * speed * Time.deltaTime);


	}

	public float vrniZamikPrvi(){
		if (size == 0) {
			BoxCollider colider = gameObject.GetComponent<BoxCollider> ();
			size = Mathf.Abs(colider.size.z);
			zamik = colider.center.z;
		}
		return size/2f;
	}
	public float vrniZamikZadnji(){
		return size / 2f;// + zamik;
	}
}
