using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Firestore;
using System;

public class PaymentConfirmation : MonoBehaviour
{
	FirebaseFirestore database;
	public TextMeshProUGUI TMPReservationId;
	public TextMeshProUGUI TMPUserName;
	public TextMeshProUGUI TMPAmount;
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		database = FirebaseFirestore.DefaultInstance;
		OnEnable();
	}
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		GetReservation();
		GetUserName();
	}
	
	private async void GetReservation(){
		string getDate = DateTime.Now.ToString("MM-dd-yyyy");
		//DocumentReference docRef = database.Collection("reservations").Document(SignInWithGoogle.NewUser.UserId + "-" + getDate);
		DocumentReference docRef = database.Collection("reservations").Document("5k9eMx6YwLcRJH9s8MwicqNMwi93-11-10-2021");
		
		DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
		if (snapshot.Exists)
		{
			Reservation reservation = snapshot.ConvertTo<Reservation>();
			TMPReservationId.text = reservation.reservationId;
			TMPAmount.text = "US$" + reservation.amount;
		}
	}
	
	private async void GetUserName(){
		//DocumentReference docRef = database.Collection("users").Document(SignInWithGoogle.NewUser.UserId);
		DocumentReference docRef = database.Collection("users").Document("5k9eMx6YwLcRJH9s8MwicqNMwi9");
		
		DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
		if (snapshot.Exists)
		{
			Debug.Log(snapshot.Id);
			User user = snapshot.ConvertTo<User>();
			TMPUserName.text = user.firstName + " " + user.lastName;
		}
	}
	
	//private async void GetAmount(){
	//	DocumentReference docRef = database.Collection("users").Document(SignInWithGoogle.NewUser.UserId);
		
	//	DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
	//	if (snapshot.Exists)
	//	{
	//		Debug.Log(snapshot.Id);
	//		User user = snapshot.ConvertTo<User>();
	//		TMPamount.text = user.firstName;
	//	}
	//}
}
