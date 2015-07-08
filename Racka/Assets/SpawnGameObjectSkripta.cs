using UnityEngine;
using System.Collections;

public class SpawnGameObjectSkripta : MonoBehaviour {

	// Use this for initialization


	public float zamik=45;
	public float speed=5;

	Collider terminator;
	float cas;
	RandomCreatorSkripta mapCreator;
	void Start () {
		Transform mc = transform.parent;
		while (mc.parent != null) {
			mc = mc.parent;
		}
		mapCreator = mc.gameObject.GetComponent<RandomCreatorSkripta>();
		transform.position += transform.forward * Random.Range (-zamik/2, zamik/2);
		terminator = transform.FindChild ("terminator").GetComponent<Collider> ();
		postaviVozila ();
		cas = zamik / speed;

	}
	
	// Update is called once per frame
	void Update () {
		cas -= Time.deltaTime;
		if (cas <= 0) {
			GameObject zac = Instantiate(mapCreator.vrniRandomVozilo(),transform.position,transform.rotation) as GameObject;
			zac.transform.SetParent(transform.parent);
			Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
			zac.GetComponent<SkriptaPotujNaprej>().speed = speed;
			zac.GetComponent<SkriptaPotujNaprej>().zbrisiPoCasu = 180f/speed;
			cas = zamik / speed;
		}


	}

	public void postaviVozila(){
		float vsota = 0;
		for (int i=0; i < 4; i++) {
			vsota = i * zamik;
			GameObject zac = Instantiate(mapCreator.vrniRandomVozilo(),transform.position + transform.forward*vsota,transform.rotation) as GameObject;
			Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
			zac.transform.SetParent(transform.parent);
			zac.GetComponent<SkriptaPotujNaprej>().speed = speed;
			zac.GetComponent<SkriptaPotujNaprej>().zbrisiPoCasu = 180f/speed;

		}
	}
}
