using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Example : MonoBehaviour {
	public GameObject PrefabLightning;
	public Transform ParentTransform;
	[Space(20)]
	public Transform TrStart;
	public Transform TrEnd;


	GameObject newObjLightning;
	Lightning newLightning = null;

	void Start () {
		CreateLightning();
	}

	void FixedUpdate () {
		if(newObjLightning) {
			newLightning.SetStartPos(TrStart.localPosition);
			newLightning.SetEndPos(TrEnd.localPosition);
		}
	}

	void CreateLightning() {
		if(!newObjLightning) {
			newObjLightning = Instantiate(PrefabLightning);
			newObjLightning.transform.SetParent(ParentTransform);
			newObjLightning.transform.localPosition = Vector3.zero;
			newLightning = newObjLightning.GetComponent<Lightning>();

			newLightning.Create(TrStart.position, TrEnd.position);
		}
	}
}
