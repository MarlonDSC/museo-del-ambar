using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using System;

[FirestoreData]
public class Reservation : MonoBehaviour
{
	[FirestoreProperty]
	public int adults {get; set;}
	
	[FirestoreProperty]
	public string amount {get; set;}
	
	[FirestoreProperty]
	public string reservationType {get; set;}
	
	[FirestoreProperty]
	public int assistance {get; set;}
	
	[FirestoreProperty]
	public int children {get; set;}
	
	[FirestoreProperty]
	public string description {get; set;}
	
	[FirestoreProperty]
	public DateTime orderDate {get; set;}
	
	//[FirestoreProperty]
	//public Dictionary<Payment, object> payment {get; set;}
	
	[FirestoreProperty]
	public string paymentMethod {get; set;}
	
	[FirestoreProperty]
	public DateTime reservationDate {get; set;}
	
	//[FirestoreProperty]
	//public Payment payment {get; set;}
	
	[FirestoreProperty]
	public string user {get; set;}
	
	[FirestoreProperty]
	public string reservationId {get; set;}
	
}
