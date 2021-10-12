using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class Experience : MonoBehaviour
{
	[FirestoreProperty]
	public int duration {get; set;}
	
	[FirestoreProperty]
	public string price {get; set;}
	
	[FirestoreProperty]
	public string title {get; set;}
}
