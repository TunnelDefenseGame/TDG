using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum SelectColor{
	Red = 1,
	Green,
	Blue,
	White,
	Black
}

public class Example : MonoBehaviour {
	public GameObject PrefabLightning;
	public Transform ParentTransform;
//	public Button B_CreateLightning;
	[Space(20)]
	public Transform TrStart;
	public Transform TrEnd;
	[Space(20)]
	public float Sl_MaxTimeLifeLightning;
	public float Sl_DeltaTimeNextSubLightning;
	public float Sl_MaxTimeLifeSubLightning;

	//public Toggle Tog_HasLoop;

	public float Sl_QuantityIterations;
	public float Sl_OffsetLine;
	public float Sl_OffsetPlusDistanseLine;

	public float Sl_AngleAdditionalLightning;
	public float Sl_LengthScaleAdditionalLightning;
	public float Sl_ProbabilityAdditionalLightning;

	public float Sl_WidthLightning;
	public float Sl_WidthLightningGlow;


	GameObject newObjLightning;
	Lightning newLightning = null;

	void Start () {
	//	B_CreateLightning.onClick.AddListener(() => { CreateLightning(); });

		CreateLightning();
	}

	void FixedUpdate () {
		if(newObjLightning) {
			newLightning.SetStartPos(TrStart.localPosition);
			newLightning.SetEndPos(TrEnd.localPosition);
		}
		else {
		//	B_CreateLightning.interactable = true;
		}
	}

	void SetDefault() {
		if(newObjLightning){
			Sl_MaxTimeLifeLightning = newLightning.MaxTimeLifeLightning;
			Sl_DeltaTimeNextSubLightning = newLightning.DeltaTimeNextSubLightning;
			Sl_MaxTimeLifeSubLightning = newLightning.MaxTimeLifeSubLightning;
			
	//		Tog_HasLoop.isOn = newLightning.HasLoop;
			SetColor((int)SelectColor.Blue);
			
			Sl_QuantityIterations = (float)newLightning.QuantityIterations;
			Sl_OffsetLine = newLightning.OffsetLine;
			Sl_OffsetPlusDistanseLine = newLightning.OffsetPlusDistanseLine;
			
			Sl_AngleAdditionalLightning = newLightning.AngleAdditionalLightning;
			Sl_LengthScaleAdditionalLightning = newLightning.LengthScaleAdditionalLightning;
			Sl_ProbabilityAdditionalLightning = newLightning.ProbabilityAdditionalLightning;

			Sl_WidthLightning = newLightning.WidthLightning;
			Sl_WidthLightningGlow = newLightning.WidthLightningGlow;
		}
		
		
	//	Sl_MaxTimeLifeLightning.onValueChanged.AddListener((float value) => { if(newObjLightning) newLightning.MaxTimeLifeLightning = value; });
	//	Sl_DeltaTimeNextSubLightning.onValueChanged.AddListener((float value) => { if(newObjLightning) newLightning.DeltaTimeNextSubLightning = value; });
	//	Sl_MaxTimeLifeSubLightning.onValueChanged.AddListener((float value) => { if(newObjLightning) newLightning.MaxTimeLifeSubLightning = value; });
		
	//	Tog_HasLoop.onValueChanged.AddListener((bool value) => { if(newObjLightning) newLightning.HasLoop = value; });
		
	//	Sl_QuantityIterations.onValueChanged.AddListener((float value) => { if(newObjLightning) newLightning.QuantityIterations = (int)value; });
	//	Sl_OffsetLine.onValueChanged.AddListener((float value) => { if(newObjLightning) newLightning.OffsetLine = value; });
	//	Sl_OffsetPlusDistanseLine.onValueChanged.AddListener((float value) => { if(newObjLightning) newLightning.OffsetPlusDistanseLine = value; });
		
	//	Sl_AngleAdditionalLightning.onValueChanged.AddListener((float value) => { if(newObjLightning) newLightning.AngleAdditionalLightning = value; });
	//	Sl_LengthScaleAdditionalLightning.onValueChanged.AddListener((float value) => { if(newObjLightning) newLightning.LengthScaleAdditionalLightning = value; });
	//	Sl_ProbabilityAdditionalLightning.onValueChanged.AddListener((float value) => { if(newObjLightning) newLightning.ProbabilityAdditionalLightning = value; });

	//	Sl_WidthLightning.onValueChanged.AddListener((float value) => { if(newObjLightning) newLightning.WidthLightning = value; });
	//	Sl_WidthLightningGlow.onValueChanged.AddListener((float value) => { if(newObjLightning) newLightning.WidthLightningGlow = value; });
	}

	void CreateLightning() {
		if(!newObjLightning) {
			newObjLightning = Instantiate(PrefabLightning);
			newObjLightning.transform.SetParent(ParentTransform);
			newObjLightning.transform.localPosition = Vector3.zero;
			newLightning = newObjLightning.GetComponent<Lightning>();

			SetDefault();
			newLightning.Create(TrStart.localPosition, TrEnd.localPosition);
			
		//	B_CreateLightning.interactable = false;
		}
	}

	public void SetColor(int c) {
		Color _c = Color.blue;

		switch((SelectColor)c){
		case SelectColor.Red:
			_c = Color.red;
			break;
		case SelectColor.Green:
			_c = Color.green;
			break;
		case SelectColor.Blue:
			_c = Color.blue;
			break;
		case SelectColor.White:
			_c = Color.white;
			break;
		case SelectColor.Black:
			_c = Color.black;
			break;
		}

		if(newObjLightning)
			newLightning.ColorLightning = _c;
	}
}
