using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;
using System;
using TMPro;

public class ServiceSelection : MonoBehaviour
{
	//first page
	static FirebaseFirestore database;
	static int number;
	GameObject selector;
	Toggle toggle;
	string reservationType;
	static string getDate;

	//second page
	GameObject year;
	GameObject month;
	GameObject day;
	string setDateToFirestore;
	string setTimeToFirestore;
	GameObject schedule;
	GameObject adults;
	GameObject children;
	GameObject assistance;

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

		getDate = DateTime.Now.ToString("MM-dd");


		DocumentReference docRef = database.Collection("reservations").Document("vfEXj9VTRDhQgVnVSrMuugQWBLr1_" + getDate);
		Dictionary<string, object> reservation = new Dictionary<string, object>
        {
            {"reservationType", reservationType},
            {"userId", "vfEXj9VTRDhQgVnVSrMuugQWBLr1"}
        };
		await docRef.SetAsync(reservation);
		Debug.Log("pressed");
		
	}

	public async void Continue2()
	{
		year = GameObject.Find("Año");
		day = GameObject.Find("Dia");
		adults = GameObject.Find("numero de Adultos");
		children = GameObject.Find("numero de Niños");
		assistance = GameObject.Find("numero de Discapacitados");
		//month = GameObject.Find("Mes");
		//day = GameObject.Find("Dia");
		
		string setDateToFirestore = FantomLib.DatePickerController.dateValue.ToString("yyyy/MM/dd");
		//year.GetComponent<TextMeshProUGUI>().text = setDateToFirestore;
		string setTimeToFirestore = FantomLib.TimePickerController.timeValue;
		//string setTimeToFirestore = FantomLib.DatePickerController.timeValue.ToString();
		//day.GetComponent<TextMeshProUGUI>().text = setTimeToFirestore;
		DateTime saveDate = DateTime.Parse(setDateToFirestore+setTimeToFirestore);
		
		
		DocumentReference docRef = database.Collection("reservations").Document("vfEXj9VTRDhQgVnVSrMuugQWBLr1_" + getDate);
		Reservation reservation = new Reservation
		{
			adults = int.Parse(adults.GetComponent<TextMeshProUGUI>().text),
			assistance = int.Parse(assistance.GetComponent<TextMeshProUGUI>().text),
			children = int.Parse(children.GetComponent<TextMeshProUGUI>().text),
			reservationDate = saveDate,
			user = "vfEXj9VTRDhQgVnVSrMuugQWBLr1",
		};
		//Dictionary<string, object> city = new Dictionary<string, object>
		//{
		//	{"reservationType", reservationType},
		//	{"userId", "vfEXj9VTRDhQgVnVSrMuugQWBLr1"}
        //};
		await docRef.SetAsync(reservation);
	}
}
