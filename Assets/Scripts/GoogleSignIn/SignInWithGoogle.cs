using Firebase.Auth;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Firebase.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantomLib;

public class SignInWithGoogle : MonoBehaviour
{
	FirebaseAuth auth;
	public static FirebaseUser NewUser;
	public static string Userdocument { get; set; }
	bool logsEnabled = true;
	public GameObject nextPanel;
	
	void Start()
	{
		//enable Login
		LCGoogleLoginBridge.ChangeLoggingLevel(true);
		//Keep logging to false in production
		//62683424096-fj9pc3k43hk3met5in22er6lqp077hat.apps.googleusercontent.com
		//62683424096-g4i4da95v1845js0rp4u7lj3rr2hj5bb.apps.googleusercontent.com
		LCGoogleLoginBridge.InitWithClientID("62683424096-g4i4da95v1845js0rp4u7lj3rr2hj5bb.apps.googleusercontent.com",
			"<IOSClientIdData>.apps.googleusercontent.com");
		Debug.Log("Firebase init");
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
				UserID();
				StartCoroutine(LoadPanel());
			}

			else
			{
				PrintMessage("Google Login Failed");
				 OKDialogController.titleDialog = "Error al iniciar sesión";
				 OKDialogController.messageDialog = "Inténtelo de nuevo o más tarde";
				 OKDialogController.ShowDialog();
			}
		};

		LCGoogleLoginBridge.LoginUser(logInCallBack, false);
	}

	public void UserID()
	{
		//GameObject FormPanel = GameObject.Find("FormPanel");
		Credential credential =
		GoogleAuthProvider.GetCredential(LCGoogleLoginBridge.GSIIDUserToken(), LCGoogleLoginBridge.GSIServerAuthCode());
		auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
			if (task.IsCanceled)
			{
				//OKDialogController.titleDialog = "Error al iniciar sesión";
				//OKDialogController.messageDialog = "La sesión fue cancelada, inténtelo de nuevo o más tarde";
				//OKDialogController.ShowDialog();
				Debug.LogError("SignInWithCredentialAsync was canceled.");
				return;
			}
			if (task.IsFaulted)
			{
				//OKDialogController.titleDialog = "Error al iniciar sesión";
				//OKDialogController.messageDialog = "Inténtelo de nuevo o más tarde";
				//OKDialogController.ShowDialog();
				Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
				return;
			}
			if(task.IsCompleted){
				NewUser = task.Result;
				PrintMessage("DisplayName: " + NewUser.DisplayName + "\n" + "UID: " +  NewUser.UserId + "\n" + "PhotoURL: " + NewUser.PhotoUrl);
				Debug.LogFormat("User signed in successfully: {0} ({1})",
					NewUser.DisplayName, NewUser.UserId);
				Userdocument = NewUser.UserId;
				Task createUser = CreateInstanceOnFirestore();
				return;
			}
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
	
	IEnumerator LoadPanel(){
		yield return new WaitForSeconds(1);
		nextPanel.SetActive(true);
	}

}