using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class arRaycaster : MonoBehaviour {
    
    

	public GameObject penderPanel;
	public GameObject penderPANELsECONDS;
	public GameObject objetoIns;
	bool activo=false;
	
	
	
	[SerializeField] float RotationSpeed = 2f;
	bool dragging = false;
	Rigidbody rb; 
	
	
	
	
	
	
	
	
	
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
	
	void OnMouseDrag()
	{
		dragging = true;
	}
	
	void Update() {
		
		if(Input.GetMouseButtonUp (0))
		{
			dragging = false; 
		}
		
		
		
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
					
					string nam;
					nam=hitObject.transform.name;
					
					
					//hitObject.transform.localScale *= 1.2f;
					if(activo==false&&nam=="01objeCondatos"||activo==false&&nam=="02objeCondatos"||activo==false&&nam=="03AzulobjeCondatos"||activo==false&&nam=="04AzulNormalobjeCondatos"||activo==false&&nam=="05AmbarEscarabajo"||activo==false&&nam=="06Ambar Flores"||activo==false&&nam=="07Ambar Lagarto"||activo==false&&nam=="08Ambar Mantis"||activo==false&&nam=="09Ambar Mosquito"||activo==false&&nam=="10Ambar Musgo"||activo==false&&nam=="11Ambar Pelos"){
						penderPanel=hitObject.transform.GetChild(1).gameObject;
						penderPanel.SetActive(true);
						
						//penderPANELsECONDS=hitObject.transform.GetChild(2).gameObject;
						//penderPANELsECONDS.SetActive(true);
						
						
						
						objetoIns=hitObject.transform.GetChild(0).gameObject;
						rb=objetoIns.GetComponent<Rigidbody>();
						
						
						
					}else  if(activo==false){
	        	          
						if(hitObject.transform.name=="canvasInformacion"){
							penderPanel=hitObject.transform.gameObject;
							penderPanel.SetActive(false);	
							//penderPANELsECONDS.SetActive(false);
							//activo=false;
						}
					}
				}
			}
		
			
			//float X = Input.GetAxis ("Mouse X") * RotationSpeed * Time.fixedDeltaTime;
			//float y = Input.GetAxis ("Mouse Y") * RotationSpeed * Time.fixedDeltaTime;
			
			float X = Input.GetAxis ("Mouse X") * RotationSpeed * Time.deltaTime * Time.deltaTime;
			float y = Input.GetAxis ("Mouse Y") * RotationSpeed * Time.deltaTime* Time.deltaTime;
			
			
			rb.AddTorque (Vector3.down*X);
			rb.AddTorque (Vector3.right*y);
	
			
	
	
			
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
	
	
	//void FixedUpdate()
	//{
	//	if(dragging)
	//	{
	//		float X = Input.GetAxis ("Mouse X") * RotationSpeed * Time.fixedDeltaTime;
	//		float y = Input.GetAxis ("Mouse Y") * RotationSpeed * Time.fixedDeltaTime;
	//		rb.AddTorque (Vector3.down*X);
	//		rb.AddTorque (Vector3.right*y);
			
	//	}
	//}
	
	
	
	
	
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
