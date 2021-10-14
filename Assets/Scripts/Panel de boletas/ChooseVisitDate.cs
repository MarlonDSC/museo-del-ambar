using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using TMPro;
using System;
using System.Threading.Tasks;

public class ChooseVisitDate : MonoBehaviour
{
	FirebaseFirestore database;
	GameObject year;
	GameObject month;
	GameObject day;
	string setDateToFirestore;
	string setTimeToFirestore;
	public GameObject adults;
	public GameObject children;
	public GameObject assistance;
	double servicePrice = 0.0;
	public TextMeshProUGUI text;
	public TextMeshProUGUI text1;
	public TextMeshProUGUI text2;
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	void Start()
	{
		database = FirebaseFirestore.DefaultInstance;
		OnEnable();
	}
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		GetPrice();
	}
	
	public async void Continue()
	{
		
		string setDateToFirestore = FantomLib.DatePickerController.dateValue.ToString("yyyy/MM/dd");
		string setTimeToFirestore = FantomLib.TimePickerController.timeValue;
		DateTime saveDate = DateTime.Parse(setDateToFirestore + " " + setTimeToFirestore);
		text.text = saveDate.ToString();
		text1.text = setDateToFirestore;
		text2.text = setTimeToFirestore;
		string getDate = DateTime.Now.ToString("MM-dd-yyyy");
		double price = Convert.ToDouble((int.Parse(adults.GetComponent<TextMeshProUGUI>().text) + int.Parse(children.GetComponent<TextMeshProUGUI>().text)))*servicePrice;
		
		DocumentReference docRef = database.Collection("reservations").Document(SignInWithGoogle.NewUser.UserId + "-" + getDate);
		//DocumentReference docRef = database.Collection("reservations").Document("5k9eMx6YwLcRJH9s8MwicqNMwi93" + "-" + getDate);
		Dictionary<string, object> reservation = new Dictionary<string, object>
		{
			{"adults", int.Parse(adults.GetComponent<TextMeshProUGUI>().text)},
			{"assistance", int.Parse(assistance.GetComponent<TextMeshProUGUI>().text)},
			{"children", int.Parse(children.GetComponent<TextMeshProUGUI>().text)},
			{"reservationDate", saveDate},
			{"orderDate", DateTime.Now},
			//{"payment.amount", 5.00},
			//{"payment.description", "lol"},
			//{"payment.paymentMethod", ""},
			{"amount", price.ToString("#.##")},
			//
			{"description", "Compra de " + (int.Parse(adults.GetComponent<TextMeshProUGUI>().text) + int.Parse(children.GetComponent<TextMeshProUGUI>().text)).ToString() + " boletos Museo del Ambar"},
			{"paymentMethod", ""},
		};
		
		await docRef.UpdateAsync(reservation);
	}
	
	async void GetPrice(){
		string getDate = DateTime.Now.ToString("MM-dd-yyyy");
		string reservationType = "";
		
		DocumentReference docRef = database.Collection("reservations").Document(SignInWithGoogle.NewUser.UserId + "-" + getDate);
		//DocumentReference docRef = database.Collection("reservations").Document("5k9eMx6YwLcRJH9s8MwicqNMwi93" + "-" + getDate);
		DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
		if (snapshot.Exists)
		{
			Reservation reservation = snapshot.ConvertTo<Reservation>();
			//Origin and History, Origin History and Pairing, Complete experience for example.
			reservationType = reservation.reservationType;
			Debug.Log("reservationType to get the price " + reservationType);
		}
		
		//DocumentReference docRef2 = database.Collection("experiences").Document("1yHe6t9ilLoMZ2qEpKLA");
		//DocumentSnapshot snapshot2 = await docRef2.GetSnapshotAsync();
		//if (snapshot2.Exists)
		//{
		//	Experience experience = snapshot2.ConvertTo<Experience>();
		//	Debug.Log("price for this " + experience.price);
		//	//servicePrice = Convert.ToDouble(experience.price);
		//}
		
		Query docQuery = database.Collection("experiences").WhereEqualTo("reservationType", reservationType);
		QuerySnapshot dataQuerySnapshot = await docQuery.GetSnapshotAsync();
		
		foreach (DocumentSnapshot documentSnapshot in dataQuerySnapshot.Documents) {
			Debug.Log(String.Format("Document data for {0} document:", documentSnapshot.Id));
			Dictionary<string, object> experiences = documentSnapshot.ToDictionary();
			
			foreach (KeyValuePair<string, object> pair in experiences) {
				if(pair.Key.Equals("price")){
					//servicePrice = Convert.ToDouble(String.Format("{0}: {1}", pair.Key, pair.Value));
					servicePrice = Convert.ToDouble(pair.Value);
					//Debug.Log(String.Format("{0}: {1}", pair.Key, pair.Value));
					//Debug.Log(servicePrice.ToString());
				}
			}
		}
		
		//CollectionReference citiesRef = database.Collection("experiences");
		//Query query = citiesRef.WhereEqualTo("title", "Origin And History");
		//QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
		//foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
		//{
		//	Debug.Log(String.Format("Document {0} returned by query State=CA", documentSnapshot.Id));
		//	//Console.WriteLine("Document {0} returned by query State=CA", documentSnapshot.Id);
		//}
		
		//Query capitalQuery = database.Collection("experiences").WhereEqualTo("title", "Origin And History").Limit(1);
		//QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
		//foreach (DocumentSnapshot documentSnapshot in capitalQuerySnapshot.Documents)
		//{
		//	Debug.Log(String.Format("Document data for {0} document:", documentSnapshot.Id));
		//	Dictionary<string, object> city = documentSnapshot.ToDictionary();
		//	foreach (KeyValuePair<string, object> pair in city)
		//	{
		//		Debug.Log(String.Format("{0}: {1}", pair.Key, pair.Value));
		//	}
		//}
		
		//CollectionReference citiesRef = database.Collection("experiences");
		//Query query = citiesRef.WhereEqualTo("Capital", true);
		//QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
		//foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
		//{
		//	Console.WriteLine("Document {0} returned by query Capital=true", documentSnapshot.Id);
		//}
	}
}
