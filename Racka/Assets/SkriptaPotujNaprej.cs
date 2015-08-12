using UnityEngine;
using System.Collections;

public class SkriptaPotujNaprej : MonoBehaviour {

	// Use this for initialization
	public float speed=4;
	public GameObject nazaj;
	public Vector3 pozicija;

	public float size;
	public float zamik;

	float casNastanka;
	void Start () {
		BoxCollider colider = gameObject.GetComponent<BoxCollider> ();
		size = Mathf.Abs(colider.bounds.size.z * transform.localScale.z);
		zamik = colider.center.z;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position+= (transform.forward * speed * Time.deltaTime);


	}

	public float vrniZamikPrvi(){
		return size/2 - zamik;
	}
	public float vrniZamikZadnji(){
		return size / 2 + zamik;
	}
}
