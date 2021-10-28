using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;
using System;
using TMPro;
using System.Security.Cryptography;

public class ServiceSelection : MonoBehaviour
{
	//first page
	FirebaseFirestore database;
	static int number;
	GameObject selector;
	Toggle toggle;
	string reservationType;
	public static string getDate;
	string reservationTypeName;

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
			//reservationType = 
			//Debug.Log(gameObject.transform.GetChild(0).name);
			//reservationTypeName = GameObject.Find(gameObject.transform.GetChild(0).name).GetComponent<TextMeshProUGUI>().text;
			Debug.Log(GameObject.Find(name).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
			reservationTypeName = GameObject.Find(name).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
			//selector.GetComponent<Image>().color = new Color32(247,153,12,255);
			Debug.Log(number);
        }
		//else{
		//	//selector.GetComponent<Image>().color = new Color32(255,255,255,255);
		//}
	}
	   
	public async void Continue()
	{
		if(number == 1){
			reservationType = "Origin And History";
		}
		else if(number == 2){
			reservationType = "Origin, History And Pairing";
		}
		else if(number == 3){
			reservationType = "Complete Experience";
		}
		Debug.Log("reservation Type " + reservationType);

		getDate = DateTime.Now.ToString("MM-dd-yyyy");
		
		//"-" + uniqueID

		DocumentReference docRef = database.Collection("reservations").Document("5k9eMx6YwLcRJH9s8MwicqNMwi93-10-27-2021");
		//DocumentReference docRef = database.Collection("reservations").Document(SignInWithGoogle.NewUser.UserId + "-" + getDate);
		//DocumentReference docRef = database.Collection("reservations").Document(SignInWithGoogle.NewUser + "-" + getDate);
		Dictionary<string, object> reservation = new Dictionary<string, object>
        {
	        {"reservationType", "EXPERIENCIA TOTAL"},
            //{"user", SignInWithGoogle.NewUser.UserId},
	        {"user", "5k9eMx6YwLcRJH9s8MwicqNMwi93"},
            {"reservationId", GenerateUniqueID(5)},
		};
		await docRef.SetAsync(reservation);
	}
	
	private static readonly RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
	
	private string GenerateUniqueID(int length)
	{
		int sufficientBufferSizeInBytes = (length * 6 + 7) / 8;

		var buffer = new byte[sufficientBufferSizeInBytes];
		random.GetBytes(buffer);
		return getDate + "-" + Convert.ToBase64String(buffer).Substring(0, length);
	}
}
