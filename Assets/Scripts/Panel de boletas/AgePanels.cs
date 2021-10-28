using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgePanels : MonoBehaviour
{
	public Toggle toggle;
	public Toggle adultsToggle;
	public Toggle childrenToggle;
	public GameObject button;
	
	public GameObject adultsPanel;
	public GameObject childrenPanel;
	
	public void AcceptInfoCheckBox(){
		if(toggle.isOn && (adultsToggle.isOn || childrenToggle.isOn)){
			button.SetActive(true);
			Debug.Log("activo");
		}
		//else if(!toggle.isOn) {
		//	button.SetActive(false);
		//	Debug.Log("inactivo");
		//}
		else{
			button.SetActive(false);
			Debug.Log("inactivo");
		}
		//toggle.isOn = true ? button.SetActive(true) : button.SetActive(false);
	}
	
	public void Continue(){
		if(adultsToggle.isOn){
			gameObject.SetActive(false);
			adultsPanel.SetActive(true);
		}
		
		else if(childrenToggle.isOn){
			gameObject.SetActive(false);
			childrenPanel.SetActive(true);
		}
	}
}
