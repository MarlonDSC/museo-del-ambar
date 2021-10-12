using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using TMPro;
using System.Threading.Tasks;
using System;

public class PaymentDetails : MonoBehaviour
{
	FirebaseFirestore database;
	public TextMeshProUGUI TMPreservationId;
	public TextMeshProUGUI TMPdescription;
	public TextMeshProUGUI TMPamount;
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	public void Start()
	{
		database = FirebaseFirestore.DefaultInstance;
		OnEnable();
		//Task retrieveFormData = ShowPaymentDetails();
		//Debug.Log("panel 3 prendido");
	}
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		Task retrieveFormData = ShowPaymentDetails();
	}
	
	public async Task ShowPaymentDetails(){
		//DocumentReference docRef;
	    
		//docRef = database.Collection("reservations").Document(SignInWithGoogle.NewUser.UserId + "-" + ServiceSelection.getDate);
		////docRef = database.Collection("reservations").Document("5k9eMx6YwLcRJH9s8MwicqNMwi93-10-11-2021");
		
		//DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
		//if (snapshot.Exists)
		//{
		//	Debug.Log(snapshot.Id);
		//	Reservation reservation = snapshot.ConvertTo<Reservation>();
		//	Debug.Log(reservation.reservationId);
		//	Debug.Log(reservation.user);
		//	reservationId.text = reservation.reservationId;
		//	description.text = reservation.user;
		//	//amount.text = amount.text + reservation.payment.amount.ToString();
		//}
		string getDate = DateTime.Now.ToString("MM-dd-yyyy");
		DocumentReference docRef = database.Collection("reservations").Document(SignInWithGoogle.NewUser.UserId + "-" + getDate);
		//DocumentReference docRef = database.Collection("reservations").Document("5k9eMx6YwLcRJH9s8MwicqNMwi93" + "-" + getDate);		
		DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
		if (snapshot.Exists)
		{
			Reservation reservation = snapshot.ConvertTo<Reservation>();
			Debug.Log(reservation.reservationId);
			TMPreservationId.text = reservation.reservationId;
			TMPamount.text = "US$ " + reservation.amount;
			TMPdescription.text = reservation.description;

			//TMPdescription.text = 
			//Debug.Log(reservation.payment.description);
			//Debug.Log(reservation.payment.amount.ToString());
			//reservationId.text = reservation.reservationId;
			//description.text = reservation.payment.description;
			//amount.text = reservation.payment.amount.ToString();
			//emailInputField.text = user.email;
			//phoneNumberinputField.text = user.phoneNumber;
		}
	}
	
	public async void Continue(){
		
	}
}
