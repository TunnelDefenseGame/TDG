using UnityEngine;
using System.Collections;

public class BoltBehavior : MonoBehaviour {

	public GameObject boltTemplate;

	private GameObject activeBolt;

	private GameObject ship = null;

	Lightning newLightning = null;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(activeBolt) {
			newLightning.SetStartPos(Vector3.zero);
			newLightning.SetEndPos(this.transform.InverseTransformPoint(ship.transform.position));
		}
	}

	public void createBolt(GameObject end) {
		//activeBolt = (GameObject)Instantiate (boltTemplate, this.transform.position, Quaternion.identity);
		//activeBolt.GetComponent<Example>().setVars(this.transform, end.transform);
		activeBolt = Instantiate(boltTemplate);
		activeBolt.transform.SetParent(this.transform);
		activeBolt.transform.localPosition = Vector3.zero;
		newLightning = activeBolt.GetComponent<Lightning>();

		ship = end;
		newLightning.Create(this.transform.position, end.transform.position);
		Destroy (activeBolt.gameObject, 0.9f);
		Destroy (newLightning.gameObject, 0.9f);
	}
}
