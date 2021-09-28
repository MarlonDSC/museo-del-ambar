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
    public Text document;
    // Start is called before the first frame update
    void Start()
    {
        database = FirebaseFirestore.DefaultInstance;
        Task retrieveFormData = ListenDocument();
        document.text = SignInWithGoogle.NewUser.UserId;
        //docRef = database.Collection("users").Document(firebaseUser.UserId);
    }

    private static async Task ListenDocument()
    {
        DocumentReference docRef;
        InputField firstNameInputField = GameObject.Find("First Name InputField").GetComponent<InputField>();
        InputField lastNameInputField = GameObject.Find("Last Name InputField").GetComponent<InputField>();
        InputField countryOrRegionInputField = GameObject.Find("Country/Region InputField").GetComponent<InputField>();
        InputField emailInputField = GameObject.Find("Email InputField").GetComponent<InputField>();
        InputField phoneNumberinputField = GameObject.Find("Phone number InputField").GetComponent<InputField>();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
