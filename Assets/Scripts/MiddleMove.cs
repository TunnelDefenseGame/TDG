using UnityEngine;
using System.Collections;

public class MiddleMove : MonoBehaviour {

	public float speed;
	public GameObject EnergyPowerUp;
	public GameObject PrefabLightning;

	private Vector3 sp; 
	private Vector3 cp; 
	private Vector3 ep;
	private float StartPointX;
	private float StartPointY;
	private float StartPointZ;
	private float ControlPointX;
	private float ControlPointY;
	private float ControlPointZ;
	private float EndPointX;
	private float EndPointY;
	private float EndPointZ;
	private float CurveX;
	private float CurveY;
	private float CurveZ;
	private float z;
	private float BezierTime;

	private GameObject energy;
	GameObject newObjLightning;
	Lightning newLightning = null;

	private bool lightningIsSpawned;

	// Use this for initialization
	void Start () {
		BezierTime = 0;
		sp = GameObject.Find("Player").transform.position;
		cp = GameObject.Find("ControlPoint").transform.position; 
		ep = GameObject.Find("EndPoint").transform.position; 


		StartPointX = sp.x;
		StartPointY = sp.y;
		StartPointZ = sp.z;
		ControlPointX = cp.x;
		ControlPointY = cp.y;
		ControlPointZ = cp.z;
		EndPointX = ep.x;
		EndPointY = ep.y;
		EndPointZ = ep.z;
		lightningIsSpawned = false;

	}
	
	// Update is called once per frame
	void Update () {
		BezierTime = BezierTime + Time.deltaTime * speed;

		if (BezierTime >= 1) {
			BezierTime = 1;
			if (!lightningIsSpawned) {
				energy = (GameObject)Instantiate (EnergyPowerUp, this.transform.position, Quaternion.identity);
				lightningIsSpawned = true;
			}
			z = this.transform.position.z + speed * 0.15f;
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, z);
			energy.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);

		} else {
			//this will move along a curve toward a point in the middle of the tunnel toward the camera
			CurveX = (((1 - BezierTime) * (1 - BezierTime)) * StartPointX) + (2 * BezierTime * (1 - BezierTime) * ControlPointX) + ((BezierTime * BezierTime) * EndPointX);
			CurveY = (((1 - BezierTime) * (1 - BezierTime)) * StartPointY) + (2 * BezierTime * (1 - BezierTime) * ControlPointY) + ((BezierTime * BezierTime) * EndPointY);
			CurveZ = (((1 - BezierTime) * (1 - BezierTime)) * StartPointZ) + (2 * BezierTime * (1 - BezierTime) * ControlPointZ) + ((BezierTime * BezierTime) * EndPointZ);
			this.transform.position = new Vector3 (CurveX, CurveY, CurveZ);
	
		}

		//kill the objects once they reach the end of the tunnel
		if (this.transform.position.z > -10) {
			Destroy (energy);
			Destroy(this.gameObject);
		}
	}
}
