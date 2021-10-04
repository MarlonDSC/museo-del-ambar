using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using TMPro;
 
public class QRGenerator : MonoBehaviour
{
	[SerializeField]
	private RawImage ImagenReceptoraDelQr;
	[SerializeField]
	private TMP_InputField InformacionQueSeEnvia;
	
	private Texture2D TextoCodificado;
	
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		TextoCodificado = new Texture2D(256, 256);
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
	
	public void OnClickEncoding()
	{
		TextoCodificadoEnQR	();
	}
	public void TextoCodificadoEnQR()
	{
		// En esta parte de codigo es donde puedes elegir la informacion que se genererara en el codigo QR. 
		string Escritor =  string.IsNullOrEmpty(InformacionQueSeEnvia.text) ? "No te has registrado" : InformacionQueSeEnvia.text;
		
		Color32 [] ConvertidorPixelesenTextura = Encode(Escritor, TextoCodificado.width, TextoCodificado.height);
		TextoCodificado.SetPixels32(ConvertidorPixelesenTextura);
		TextoCodificado.Apply();
		
		ImagenReceptoraDelQr.texture = TextoCodificado;
	}
}
