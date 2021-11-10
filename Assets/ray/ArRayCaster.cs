using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class ArRayCaster : MonoBehaviour {
    
    

	public GameObject penderPanel;
	bool activo=false;
	
	[SerializeField]
	[Tooltip("Camera for raycast, default is Camera which tagged as MainCamera")]
	private Camera arCamera;
	[SerializeField]
	[Tooltip("Material of Drawn Raycast line")]
	private Material lineMaterial;
	private LineRenderer viewLine;
	private LineRenderer touchLine;
	void Start()
	{
		if(arCamera == null)    arCamera = Camera.main;
		//viewLine = CreateLine("ViewLine", Color.red);

        
	}
	void Update() {
		// Touch raycast
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			var touchPositon = touch.position;
			Ray touchRay = arCamera.ScreenPointToRay(touchPositon);
			switch (touch.phase)
			{
			case TouchPhase.Began :
				touchLine = CreateLine("touchLine",Color.clear);
				touchLine.SetPosition(0,touchRay.origin - new Vector3(0,0.1f,0));
				touchLine.SetPosition(1,touchRay.direction*10f);
				break;
			case TouchPhase.Ended :
			case TouchPhase.Canceled :
				Destroy(touchLine.gameObject,1f);
				StartCoroutine(DestroyLineSmoothly(touchLine));
				break;
			case TouchPhase.Moved :
				//case TouchPhase.Stationary :
				touchLine.SetPosition(1,touchRay.direction*10f);
				break;
			}
			if (touch.phase == TouchPhase.Began) {

				RaycastHit hitObject;
				if (Physics.Raycast(touchRay,out hitObject)) {
					//hitObject.transform.localScale *= 1.2f;
					if(activo==false){
						penderPanel=hitObject.transform.GetChild(1).gameObject;
						penderPanel.SetActive(true);
						activo=true;
					}else  if(activo==true){
	        	          
						if(hitObject.transform.name=="canvasInformacion"){
							penderPanel=hitObject.transform.gameObject;
							penderPanel.SetActive(false);		      
							activo=false;
						}
					}
				}
			}
		}

		// Viewpoint raycast
		Ray viewRay =arCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        
		//Draw ray
		viewLine.SetPosition(0,viewRay.origin - new Vector3(0,0.1f,0));
		viewLine.SetPosition(1,viewRay.direction*10f);

		RaycastHit hit;
		if (Physics.Raycast(viewRay, out hit)) {
			hit.transform.localScale *= 0.99f;
            
		}
	}
	LineRenderer CreateLine(string name, Color lineColor)
	{
		GameObject go = new GameObject(name);
		LineRenderer line = go.AddComponent<LineRenderer>();
		line.material = lineMaterial;
		line.positionCount=2;
		line.startWidth=0.01f;
		line.endWidth=0.01f;
		line.colorGradient.mode = GradientMode.Fixed;
		line.startColor=lineColor;
		line.endColor=lineColor;
		return line;
	}
	IEnumerator DestroyLineSmoothly(LineRenderer line)
	{
		while(line.startColor.a >0) {
            
			Color color = line.startColor - new Color(0,0,0,Time.deltaTime * 0.5f);
			line.startColor=color;
			line.endColor=color;
			Debug.Log(line.startColor);
			yield return 0;
		}
		Destroy(line.gameObject);
	}
}
