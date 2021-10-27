using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgePanels : MonoBehaviour
{
	public Toggle toggle;
	public GameObject button;
	
	public void AcceptTermsAndServices(){
		if(toggle.isOn){
			button.SetActive(true);
			Debug.Log("activo");
		}
		else if(!toggle.isOn) {
			button.SetActive(false);
			Debug.Log("inactivo");
		}
		//toggle.isOn = true ? button.SetActive(true) : button.SetActive(false);
	}
}
