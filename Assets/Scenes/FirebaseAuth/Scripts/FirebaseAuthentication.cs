using Firebase;
using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirebaseAuthentication : MonoBehaviour
{
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    [Header("Login")]
    public InputField emailLoginField;
    public InputField passwordLoginField;
    public Text warningLoginText;
    public Text confirmLoginText;
    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(
            task =>
            {
                dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    InitializeFirebase();
                }
                else
                {
                    Debug.LogError("Could not resolve all Firebase dependencies" + dependencyStatus);
                }
            }
            );
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = FirebaseAuth.DefaultInstance;
    }

    public void LoginButton()
    {
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }
    public void RegisterButton()
    {
        StartCoroutine(Register(emailLoginField.text, passwordLoginField.text));
    }

    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLoginText.gameObject.SetActive(true);
            warningLoginText.text = message;
        }
        else
        {
            //User is now logged in
            //Now get the result
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.gameObject.SetActive(false);
            confirmLoginText.gameObject.SetActive(true);
            warningLoginText.text = "";
            confirmLoginText.text = "Logged In";
            
        }
    }

    private IEnumerator Register(string _email, string _password)
    {
        //if (_username == "")
        //{
        //    //If the username field is blank show a warning
        //    warningRegisterText.text = "Missing Username";
        //}
        //if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        //{
        //    //If the password does not match show a warning
        //    warningRegisterText.text = "Password Does Not Match!";
        //}
        if (passwordLoginField.text != "")
        {
            //Call the Firebase auth signin function passing the email and password
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningLoginText.text = message;
            }
            else
            {
                //User has now been created
                //Now get the result
                User = RegisterTask.Result;

                if (User != null)
                {
                    //Create a user profile and set the username
                    UserProfile profile = new UserProfile { DisplayName = _email };

                    //Call the Firebase auth update user profile function passing the profile with the username
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    //Wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        //If there are errors handle them
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningLoginText.text = "Username Set Failed!";
                    }
                    else
                    {
                        //Username is now set
                        //Now return to login screen
                        UIManager.instance.LoginScreen();
                        warningLoginText.text = "";
                    }
                }
            }
        }
    }
}
