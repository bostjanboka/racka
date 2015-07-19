using UnityEngine;
using System.Collections;

public class upraviteljSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject mapCreator;
	public GameObject raca;

	float cas = 0;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		cas += Time.deltaTime;
		if (cas > 4 && cas < 5) {
			mapCreator.GetComponent<RandomCreatorSkripta> ().StartPostavitev ();
			cas =6;
		}
	}
}
