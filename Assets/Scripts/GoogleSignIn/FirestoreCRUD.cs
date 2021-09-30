using Firebase.Auth;
using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FirestoreCRUD : MonoBehaviour
{
    static FirebaseFirestore database;
    FirebaseUser firebaseUser = SignInWithGoogle.NewUser;
    //public Text document;
    // Start is called before the first frame update
	public void Start()
    {
        database = FirebaseFirestore.DefaultInstance;
        Task retrieveFormData = ListenDocument();
        //document.text = SignInWithGoogle.NewUser.UserId;
        //docRef = database.Collection("users").Document(firebaseUser.UserId);
    }

	public static async Task ListenDocument()
    {
        DocumentReference docRef;
	    InputField firstNameInputField = GameObject.Find("Nombre").GetComponent<InputField>();
	    InputField lastNameInputField = GameObject.Find("Apellido").GetComponent<InputField>();
	    InputField countryOrRegionInputField = GameObject.Find("Pais/Region").GetComponent<InputField>();
	    InputField emailInputField = GameObject.Find("CorreoElectronico").GetComponent<InputField>();
	    InputField phoneNumberinputField = GameObject.Find("NumeroTelefonico").GetComponent<InputField>();
        docRef = database.Collection("users").Document(SignInWithGoogle.NewUser.UserId);

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
}
