using Firebase.Auth;
using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersonalDetails : MonoBehaviour
{
	FirebaseFirestore database;
	public TMP_InputField firstNameInputField;
	public TMP_InputField lastNameInputField;
	public TMP_InputField countryOrRegionInputField;
	public TMP_InputField emailInputField;
	public TMP_InputField phoneNumberinputField;
	public GameObject button;
	public Toggle toggle;

	public void Start()
	{
		database = FirebaseFirestore.DefaultInstance;
		OnEnable();
	}
    
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		Task retrieveFormData = ListenDocument();
	}

	public async Task ListenDocument()
    {
	    
	    DocumentReference docRef = database.Collection("users").Document(SignInWithGoogle.NewUser.UserId);
		
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
        if (snapshot.Exists)
        {
            Debug.Log(snapshot.Id);
	        User user = snapshot.ConvertTo<User>();
            firstNameInputField.text = user.firstName;
            lastNameInputField.text = user.lastName;
            countryOrRegionInputField.text = user.country;
            emailInputField.text = user.email;
            phoneNumberinputField.text = user.phoneNumber;
        }
    }
    
	public async void Continue(){
		DocumentReference docRef = database.Collection("users").Document(SignInWithGoogle.NewUser.UserId);
		//DocumentReference docRef = database.Collection("users").Document("5k9eMx6YwLcRJH9s8MwicqNMwi93");
		//DocumentReference docRef = database.Collection("reservations").Document(SignInWithGoogle.NewUser + "-" + getDate);
		Dictionary<string, object> user = new Dictionary<string, object>
		{
			{"firstName", firstNameInputField.text},
			{"lastName", lastNameInputField.text},
			{"country", countryOrRegionInputField.text},
			{"email", emailInputField.text},
			{"phoneNumber", phoneNumberinputField.text},
		};
		await docRef.UpdateAsync(user);
	}
	
	public void AcceptTermsAndServices(){
		if(toggle.isOn){
			button.SetActive(true);
			Debug.Log("activo");
		}
		else if(!toggle.isOn) {
			button.SetActive(false);
			Debug.Log("inactivo");
		}
		//toggle.isOn = true ? button.SetActive(true) : button.SetActive(false);
	}
}
