using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using FantomLib;

public class LCGoogleSignInExample : MonoBehaviour {
	public Text statusText;
	FirebaseAuth auth;

	public void ManualInit(){
		//Keep logging to false in production
		LCGoogleLoginBridge.ChangeLoggingLevel(true);

		//For Android, You need to replace it with web client ID. Check details given in LCGoogleLoginBridge file or ReadMe file or tutorial video
		//For iOS, web client id will be used if you are using server auth. Normal iOS client id is picked up from Google-Services plist file. Its safe to pass null here for iOS if no server auth is used otherwise its ignored by the sdk

		LCGoogleLoginBridge.InitWithClientID ("62683424096-g4i4da95v1845js0rp4u7lj3rr2hj5bb.apps.googleusercontent.com",
			"<IOSClientIdData>.apps.googleusercontent.com");
		PrintMessage("Google Login Initialized");
		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
	}

	public void SignInNormal(){
		Action<bool> logInCallBack = (Action<bool>)((loggedIn)=> {
			if(loggedIn){
				PrintMessage("Google Login Success> " + LCGoogleLoginBridge.GSIUserName()); 
			}

			else{
				PrintMessage("Google Login Failed");
			}	
		});

		LCGoogleLoginBridge.LoginUser (logInCallBack, false);
	}

	public void SignInServerAuth(){
		Action<bool> logInCallBack = (Action<bool>)((loggedIn)=> {
			if(loggedIn){
				PrintMessage("Google Login Success> " + LCGoogleLoginBridge.GSIUserName()); 
			}

			else{
				PrintMessage("Google Login Failed");
			}	
		});

		LCGoogleLoginBridge.LoginUser (logInCallBack, false, true, false, null);
	}

	public void SignInDrive(){
		Action<bool> logInCallBack = (Action<bool>)((loggedIn)=> {
			if(loggedIn){
				PrintMessage("Google Login Drive Success> " + LCGoogleLoginBridge.GSIUserName()); 
			}

			else{
				PrintMessage("Google Login Drive Failed");
			}	
		});

		//Scopes : https://developers.google.com/identity/protocols/googlescopes
		LCGoogleLoginBridge.LoginUser (logInCallBack, false, true, false, 
			new List<string>(){"https://www.googleapis.com/auth/drive.readonly", 
				"https://www.googleapis.com/auth/drive.photos.readonly"});
	}

	public void SignInDriveNoServer(){
		Action<bool> logInCallBack = (Action<bool>)((loggedIn)=> {
			if(loggedIn){
				PrintMessage("Google Login Drive Success> " + LCGoogleLoginBridge.GSIUserName()); 
			}

			else{
				PrintMessage("Google Login Drive Failed");
			}	
		});

		//Scopes : https://developers.google.com/identity/protocols/googlescopes
		LCGoogleLoginBridge.LoginUser (logInCallBack, false, false, false, 
			new List<string>(){"https://www.googleapis.com/auth/drive.readonly", 
				"https://www.googleapis.com/auth/drive.photos.readonly"});
	}

	public void SignInSilent(){
		Action<bool> logInCallBack = (Action<bool>)((loggedIn)=> {
			if(loggedIn){
				PrintMessage("Google Login Success> " + LCGoogleLoginBridge.GSIUserName()); 
			}
		
			else{
				PrintMessage("Google Login Failed");
			}	
		});

		LCGoogleLoginBridge.LoginUser (logInCallBack, true);
	}

	public void SignOut(){
		LCGoogleLoginBridge.LogoutUser ();
		PrintMessage("Logout Done");
	}

	public void UserID(){
		PrintMessage("UserID: " + LCGoogleLoginBridge.GSIUserID ());

		Credential credential =
		GoogleAuthProvider.GetCredential(LCGoogleLoginBridge.GSIIDUserToken(), LCGoogleLoginBridge.GSIServerAuthCode());
		auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
			if (task.IsCanceled)
			{
				Debug.LogError("SignInWithCredentialAsync was canceled.");
				return;
			}
			if (task.IsFaulted)
			{
				Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
				return;
			}

			Firebase.Auth.FirebaseUser newUser = task.Result;
			Debug.LogFormat("User signed in successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);
		});
	}

	public void UserEmail(){
		PrintMessage("UserEmail: " + LCGoogleLoginBridge.GSIEmail ());
	}

	public void UserName(){
		PrintMessage("UserName: " + LCGoogleLoginBridge.GSIUserName ());
	}

	public void PhotoUrl(){
		PrintMessage("PhotoUrl: " + LCGoogleLoginBridge.GSIPhotoUrl ());
	}

	public void UserToken(){
		PrintMessage("UserToken: " + LCGoogleLoginBridge.GSIIDUserToken ());
	}
		
	public void GrantedScopes(){
		string[] scopes = LCGoogleLoginBridge.GSIGrantedScopes ();
		if (scopes == null || scopes.Length <= 0) {
			PrintMessage ("GrantedScopes: None");
		} else {
			string scopeStr = "";
			foreach (string scope in scopes) {
				scopeStr += " " + scope;
			}
			PrintMessage ("GrantedScopes: " + scopes.Length + scopeStr);
		}
	}

	public void AccessToken(){
		PrintMessage("AccessToken: " + LCGoogleLoginBridge.GSIAccessToken () + AdditionalAndroidOnlyNotes());
	}

	public void RefreshToken(){
		PrintMessage("RefreshToken: " + LCGoogleLoginBridge.GSIRefreshToken ()+ AdditionalAndroidOnlyNotes());
	}

	static string AdditionalAndroidOnlyNotes(){
		if (Application.platform == RuntimePlatform.Android) {
			return " >> Its always null for android platform";
		}
		return "";
	}

	//If you are trying to use additional capabilities like server side APIs, you need to pass this will be returned.
	//Read more about it ServerAuthCode in google docs because very few developers actually need this
	public void ServerAuthCode(){
		PrintMessage("ServerAuthCode: " + LCGoogleLoginBridge.GSIServerAuthCode ());
	}

	bool logsEnabled = false;
	public void ChangeLogging(bool enable){
		logsEnabled = enable;
		LCGoogleLoginBridge.ChangeLoggingLevel (enable);
		PrintMessage("ChangeLogging: " + enable);
	}

	void PrintMessage(string message){
		if (logsEnabled == false) {
			Debug.Log (message);
		}
		statusText.text = message;
	}
}
