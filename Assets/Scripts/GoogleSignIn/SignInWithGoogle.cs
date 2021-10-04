using Firebase.Auth;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Firebase.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SignInWithGoogle : MonoBehaviour
{
	FirebaseAuth auth;
	public static FirebaseUser NewUser;
	public static string Userdocument { get; set; }
	bool logsEnabled = true;
	
	void Start()
	{
		//Keep logging to false in production
		LCGoogleLoginBridge.InitWithClientID("62683424096-g4i4da95v1845js0rp4u7lj3rr2hj5bb.apps.googleusercontent.com",
			"<IOSClientIdData>.apps.googleusercontent.com");
		Debug.Log("Firebase init");
		//enable Login
		LCGoogleLoginBridge.ChangeLoggingLevel(true);
		auth = FirebaseAuth.DefaultInstance;
		//SignInNormal();
	}

	public void SignInNormal()
	{
		Action<bool> logInCallBack = (loggedIn) =>
		{
			if (loggedIn)
			{
				PrintMessage("Google Login Success> " + LCGoogleLoginBridge.GSIUserName());
			}

			else
			{
				PrintMessage("Google Login Failed");
			}
		};

		LCGoogleLoginBridge.LoginUser(logInCallBack, false);
	}

	public void UserID()
	{
		//GameObject FormPanel = GameObject.Find("FormPanel");
		GameObject LoginPanel = GameObject.Find("Panel de cuentas para iniciar sesion ");
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

			NewUser = task.Result;
			PrintMessage("DisplayName: " + NewUser.DisplayName + "\n" + "UID: " +  NewUser.UserId + "\n" + "PhotoURL: " + NewUser.PhotoUrl);
			Debug.LogFormat("User signed in successfully: {0} ({1})",
				NewUser.DisplayName, NewUser.UserId);
			Userdocument = NewUser.UserId;
			Task createUser = CreateInstanceOnFirestore();
		});

		//"UserID: " + LCGoogleLoginBridge.GSIUserID()
	}

    void SetActiveRecursivelyExt(GameObject obj, bool state)
    {
        obj.SetActive(state);
        foreach (Transform child in obj.transform)
        {
            SetActiveRecursivelyExt(child.gameObject, state);
        }
    }

	public static async Task CreateInstanceOnFirestore()
    {
		FirebaseFirestore database = FirebaseFirestore.DefaultInstance;
	    DocumentReference userReference = database.Collection("users").Document(NewUser.UserId);
		string[] fullName = NewUser.DisplayName.Split(' ');
		User user = new User
        {
			country = "",
			email = NewUser.Email,
			firstName = fullName[0],
			lastName = fullName[1],
			phoneNumber = NewUser.PhoneNumber,
		};

		await userReference.SetAsync(user);
    }

    void PrintMessage(string message)
	{
		if (logsEnabled == false)
		{
			Debug.Log(message);
		}
		//statusText.text = message;
	}
	
	IEnumerator DownloadImage(string MediaUrl)
	{
		UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
		yield return request.SendWebRequest();
		
		if (request.result == UnityWebRequest.Result.ConnectionError)
			Debug.Log(request.error);
		else
		{
			Texture2D webTexture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture2D;
			Sprite webSprite = SpriteFromTexture2D(webTexture);
			//profilePicture.GetComponent<Image>().sprite = webSprite;
		}
	}

	Sprite SpriteFromTexture2D(Texture2D texture)
	{
		return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
	}

}