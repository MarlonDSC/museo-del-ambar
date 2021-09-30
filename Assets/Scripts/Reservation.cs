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
	public int assistance {get; set;}
	
	[FirestoreProperty]
	public int children {get; set;}
	
	[FirestoreProperty]
	public DateTime orderDate {get; set;}
	
	[FirestoreProperty]
	public Dictionary<string, object> payment {get; set;}
	//public Dictionary<string, object> payment = new Dictionary<string, object>{
	//	{},
	//};
	[FirestoreProperty]
	public DateTime reservationDate {get; set;}
	
	public string user {get; set;}
	
}
