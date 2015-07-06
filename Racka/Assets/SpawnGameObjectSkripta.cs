using UnityEngine;
using System.Collections;

public class SpawnGameObjectSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject objekt;

	public float zamik=45;


	float cas;
	RandomCreatorSkripta mapCreator;
	void Start () {
		Transform mc = transform.parent;
		while (mc.parent != null) {
			mc = mc.parent;
		}
		mapCreator = mc.gameObject.GetComponent<RandomCreatorSkripta>();
		transform.position += transform.forward * Random.Range (-zamik/2, zamik/2);

		postaviVozila ();
		cas = 45f / 4f;

	}
	
	// Update is called once per frame
	void Update () {
		cas -= Time.deltaTime;
		if (cas <= 0) {
			GameObject zac = Instantiate(mapCreator.vrniRandomVozilo(),transform.position,transform.rotation) as GameObject;
			zac.transform.SetParent(transform.parent);
			cas = 45f / 4f;
		}


	}

	public void postaviVozila(){
		float vsota = 0;
		for (int i=0; i < 4; i++) {
			vsota = i * zamik;
			GameObject zac = Instantiate(mapCreator.vrniRandomVozilo(),transform.position + transform.forward*vsota,transform.rotation) as GameObject;
			zac.transform.SetParent(transform.parent);

		}
	}
}
