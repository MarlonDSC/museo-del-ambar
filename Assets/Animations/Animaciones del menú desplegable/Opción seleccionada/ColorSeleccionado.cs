using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColorSeleccionado : MonoBehaviour
{
	public TextMeshProUGUI IdiomaSeleccionado;
	public GameObject SeleccionIdiomaIngles;
	public TextMeshProUGUI idiomaTextoIngles;
	public GameObject SeleccionIdiomaEspanol;
	public TextMeshProUGUI idiomaTextoespanol; 
	


	protected void Update()
	{
		switch (IdiomaSeleccionado.text)
		{
		case "ENGLISH":
			idiomaTextoIngles.color = new Color32(249,132,10,255);
			SeleccionIdiomaIngles.GetComponent<Image>().color = new Color32(32,32,32,255);
			idiomaTextoespanol.color = new Color32(32,32,32,255);
			SeleccionIdiomaEspanol.GetComponent<Image>().color = new Color32(249,132,10,255);
			break;
		}
		switch (IdiomaSeleccionado.text)
		{
		case "ESPAÑOL":
			idiomaTextoespanol.color = new Color32(249,132,10,255);
			SeleccionIdiomaEspanol.GetComponent<Image>().color = new Color32(32,32,32,255);
			idiomaTextoIngles.color = new Color32(32,32,32,255);
			SeleccionIdiomaIngles.GetComponent<Image>().color = new Color32(249,132,10,255);
			break;
		}
	}
	public void SeleccionDecolor()
	{
		if(SeleccionIdiomaIngles== true){IdiomaSeleccionado.text = "ENGLISH";}

	}
	public void SeleccionDecolor2()
	{
		if(SeleccionIdiomaEspanol == true){IdiomaSeleccionado.text = "ESPAÑOL";}
	
	}
	
}
