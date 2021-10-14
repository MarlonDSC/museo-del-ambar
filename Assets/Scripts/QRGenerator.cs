using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using TMPro;
using System;
using Firebase.Firestore;


public class QRGenerator : MonoBehaviour
{
	[SerializeField]
	private RawImage ImagenReceptoraDelQr;
	//[SerializeField]
	//private TMP_InputField InformacionQueSeEnvia;
	
	private Texture2D TextoCodificado;
	string Escritor;
	FirebaseFirestore database;
	
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		TextoCodificado = new Texture2D(256, 256);
		database = FirebaseFirestore.DefaultInstance;
		OnEnable();
	}
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		GetUserId();
		//TextoCodificadoEnQR();
	}
	
	private Color32 [] Encode(string TextoParaCodificar, int width, int height)
	{
		BarcodeWriter ElQueEscribe = new BarcodeWriter
		{
			Format = BarcodeFormat.QR_CODE,
			Options = new QrCodeEncodingOptions
			{
					
			Height = height,
			Width =  width
			 
			}
		};
		return ElQueEscribe.Write(TextoParaCodificar);
	}
	
	public void TextoCodificadoEnQR()
	{

		// En esta parte de codigo es donde puedes elegir la informacion que se genererara en el codigo QR. 
		//string  =  string.IsNullOrEmpty(Escritor) ? "No te has registrado" : "10-13-2021-oCtvV";
		//Escritor = "10-13-2021-oCtvV";
		
		Color32 [] ConvertidorPixelesenTextura = Encode(Escritor, TextoCodificado.width, TextoCodificado.height);
		TextoCodificado.SetPixels32(ConvertidorPixelesenTextura);
		TextoCodificado.Apply();
		
		ImagenReceptoraDelQr.texture = TextoCodificado;
	
	}
	
	private async void GetUserId(){
		Query capitalQuery = database.Collection("reservations").WhereEqualTo("user", "5k9eMx6YwLcRJH9s8MwicqNMwi93");
		QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
		
		foreach (DocumentSnapshot documentSnapshot in capitalQuerySnapshot.Documents)
		{
			Console.WriteLine("Document data for {0} document:", documentSnapshot.Id);
			Dictionary<string, object> city = documentSnapshot.ToDictionary();
			foreach (KeyValuePair<string, object> pair in city)
			{
				//Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
				if(pair.Key.Equals("reservationId")){
					Escritor = pair.Value.ToString();
					Debug.Log("Escritor uwu " + Escritor);
					//InformacionQueSeEnvia.text = pair.Value.ToString();
					TextoCodificadoEnQR();
					//Escritor = "10-13-2021-OQN14";
				}
			}
			Console.WriteLine("");
		}
	}
}
 
//public class QRGenerator : MonoBehaviour
//{
//	[SerializeField]
//	private RawImage ImagenReceptoraDelQr;
//	//[SerializeField]
//	private TMP_InputField InformacionQueSeEnvia;
	
//	FirebaseFirestore database;
	
//	private Texture2D TextoCodificado;
	
	
//	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
//	protected void Start()
//	{
//		database = FirebaseFirestore.DefaultInstance;
//		TextoCodificado = new Texture2D(256, 256);
//		OnEnable();
		
//	}
	
//	// This function is called when the object becomes enabled and active.
//	protected void OnEnable()
//	{
//		OnClickEncoding();
//	}
	
//	private Color32 [] Encode(string TextoParaCodificar, int width, int height)
//	{
//		BarcodeWriter ElQueEscribe = new BarcodeWriter
//		{
//			Format = BarcodeFormat.QR_CODE,
//			Options = new QrCodeEncodingOptions
//			{
					
//			Height = height,
//			Width =  width
			 
//			}
//		};
//		return ElQueEscribe.Write(TextoParaCodificar);
//	}
	
//	public void OnClickEncoding()
//	{
//		TextoCodificadoEnQR	();
//	}
//	public async void TextoCodificadoEnQR()
//	{
//		//Query capitalQuery = database.Collection("reservations").WhereEqualTo("user", "5k9eMx6YwLcRJH9s8MwicqNMwi93");
//		//QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
		
//		//foreach (DocumentSnapshot documentSnapshot in capitalQuerySnapshot.Documents)
//		//{
//		//	Console.WriteLine("Document data for {0} document:", documentSnapshot.Id);
//		//	Dictionary<string, object> city = documentSnapshot.ToDictionary();
//		//	foreach (KeyValuePair<string, object> pair in city)
//		//	{
//		//		//Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
//		//		if(pair.Key.Equals("reservationId")){
//		//			//Escritor = pair.Value.ToString();
//		//			InformacionQueSeEnvia.text = pair.Value.ToString();
//		//			//Escritor = "10-13-2021-OQN14";
//		//		}
//		//	}
//		//	Console.WriteLine("");
//		//}
		
//		// En esta parte de codigo es donde puedes elegir la informacion que se genererara en el codigo QR. 
//		string Escritor =  string.IsNullOrEmpty(InformacionQueSeEnvia.text) ? "No te has registrado" : InformacionQueSeEnvia.text;
		
//		Color32 [] ConvertidorPixelesenTextura = Encode("10-13-2021-OQN14", TextoCodificado.width, TextoCodificado.height);
//		TextoCodificado.SetPixels32(ConvertidorPixelesenTextura);
//		TextoCodificado.Apply();
		
//		ImagenReceptoraDelQr.texture = TextoCodificado;
//	}
//}
