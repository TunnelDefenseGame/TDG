using UnityEngine;
using System.Collections;

public class MiddleMove : MonoBehaviour {

	public GameObject startPoint;
	public GameObject controlPoint;
	public GameObject endPoint;


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
	private float BezierTime;

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

	}
	
	// Update is called once per frame
	void Update () {
		BezierTime = BezierTime + Time.deltaTime;

		if (BezierTime >= 1) {
			BezierTime = 1;

		} else {
			//this will move along a curve toward a point in the middle of the tunnel toward the camera
			CurveX = (((1 - BezierTime) * (1 - BezierTime)) * StartPointX) + (2 * BezierTime * (1 - BezierTime) * ControlPointX) + ((BezierTime * BezierTime) * EndPointX);
			CurveY = (((1 - BezierTime) * (1 - BezierTime)) * StartPointY) + (2 * BezierTime * (1 - BezierTime) * ControlPointY) + ((BezierTime * BezierTime) * EndPointY);
			CurveZ = (((1 - BezierTime) * (1 - BezierTime)) * StartPointZ) + (2 * BezierTime * (1 - BezierTime) * ControlPointZ) + ((BezierTime * BezierTime) * EndPointZ);
			this.transform.position = new Vector3 (CurveX, CurveY, CurveZ);
	
		}
	}
}
