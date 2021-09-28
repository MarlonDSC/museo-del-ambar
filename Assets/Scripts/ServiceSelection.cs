using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;
using System;

public class ServiceSelection : MonoBehaviour
{
	static FirebaseFirestore database;
	static int number;
	GameObject selector;
	Toggle toggle;
	string reservationType;
	
	//enum reservationType {
	//	originAndHistory = 1,
	//	originHistoryAndPairing = 2,
	//	completeExperience = 3 
	//}
    
    void Start()
	{
		database = FirebaseFirestore.DefaultInstance;
		toggle = GetComponent<Toggle>();
	}
	
	public void ToggleValueChanged()
	{
		if(toggle.isOn){
			number = int.Parse(name.Replace("Opción ", ""));
			selector = GameObject.Find("Seleccionador " + name.Replace("Opción ", ""));
			selector.GetComponent<Image>().color = new Color32(247,153,12,255);
			//Debug.Log(number);
			//Debug.Log(this.gameObject.name.ToString());
        }
		else{
			selector.GetComponent<Image>().color = new Color32(255,255,255,255);
		}
	}
	
	public async void Continue()
	{
		if(number == 1){
			reservationType = "Origin And History";
		}
		else if(number == 2){
			reservationType = "Origin, History and Pairing";
		}
		else if(number == 3){
			reservationType = "Complete Experience";
		}
		Debug.Log("reservation Type " + reservationType);
		
		DocumentReference docRef = database.Collection("reservations").Document("vfEXj9VTRDhQgVnVSrMuugQWBLr1" + DateTime.Now.ToString("hh:mm:ss"));
        Dictionary<string, object> city = new Dictionary<string, object>
        {
            {"reservationType", reservationType},
            {"userId", "vfEXj9VTRDhQgVnVSrMuugQWBLr1"}
        };
		await docRef.SetAsync(city);
		//if (number == 1){
		//	Dictionary<string, object> city = new Dictionary<string, object>
		//	{
		//		{ "reservationType", "Origin And History" },
		//		{ "userId", "vfEXj9VTRDhQgVnVSrMuugQWBLr1" }
		//	};
		//	await docRef.SetAsync(city);
		//}
		//else if(number == 2){
		//	Dictionary<string, object> city = new Dictionary<string, object>
		//	{
		//		{ "reservationType", "Origin, History and Pairing" },
		//		{ "userId", "vfEXj9VTRDhQgVnVSrMuugQWBLr1" }
		//	};
		//	await docRef.SetAsync(city);
		//}
		//else if(number == 3){
		//	Dictionary<string, object> city = new Dictionary<string, object>
		//	{
		//		{ "reservationType", "Complete Experience" },
		//		{ "userId", "vfEXj9VTRDhQgVnVSrMuugQWBLr1" }
		//	};
		//	await docRef.SetAsync(city);
		//}
		Debug.Log("pressed");
	}
    
	//public void onPressed()
	//{
		
	//	if(toggle.isOn)
	//	{
	//		number = int.Parse(name.Replace("Opción ", ""));
	//		selector = GameObject.Find("Seleccionador " + name.Replace("Opción ", ""));
	//		selector.GetComponent<Image>().color = new Color32(247,153,12,255);
	//		Debug.Log(number);
	//	}
	//	else if(!toggle.isOn){
	//		selector = GameObject.Find("Seleccionador " + name.Replace("Opción ", ""));
	//		selector.GetComponent<Image>().color = new Color32(0,0,0,255);
	//	}
	//}
}
