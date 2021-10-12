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
			Debug.Log(number);
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
			reservationType = "Origin, History And Pairing";
		}
		else if(number == 3){
			reservationType = "Complete Experience";
		}
		Debug.Log("reservation Type " + reservationType);

		getDate = DateTime.Now.ToString("MM-dd-yyyy");
		
		//"-" + uniqueID

		DocumentReference docRef = database.Collection("reservations").Document(SignInWithGoogle.NewUser.UserId + "-" + getDate);
		//DocumentReference docRef = database.Collection("reservations").Document(SignInWithGoogle.NewUser + "-" + getDate);
		Dictionary<string, object> reservation = new Dictionary<string, object>
        {
            {"reservationType", reservationType},
            {"user", SignInWithGoogle.NewUser.UserId},
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
