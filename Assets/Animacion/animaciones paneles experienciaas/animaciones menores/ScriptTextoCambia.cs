using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class ScriptTextoCambia : MonoBehaviour
{
	//textos
	public TextMeshProUGUI título;
	public TextMeshProUGUI info;
	//Botones 
	public GameObject btnTabaco;
	public GameObject btnLinterna;
	public GameObject btnVr;
	public GameObject btnAmbar;
	public GameObject btnCigarro;
	public GameObject btnCafe;
	// Rawimages

	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void CambioTextoTabacoYLaImagen()
	{
		if(btnTabaco == true)
		{
			título.text = "TABACO";
			info.text = "Experiecia del tabaco junto con su historia y como ha ido evolucionando";
		
			
		}
	
	}
	
	public void CambioDeTextoVRYlaImagen()
	{
		título.text = "VR";
		info.text = "Experiecia en realidad virtual dentro del museo y asi poder sentirse como minero dentro de ella";

		
	}
	
	
	public void CambioTextoLinternaYLaImagen()
	{
		if(btnLinterna == true)
		{
			título.text = "LINTERNA";
			info.text = "Experiecia de observacion del ambar junto con su historia y como ha ido evolucionando";
		
			
		
		}
	
	}
	
	public void CambioTextoCigarroYLaImagen()
	{
		if(btnCigarro == true)
		{
			título.text = "MARIDAJE";
			info.text = "Experiecia del Maridaje junto con su historia y como ha ido evolucionando";
		
			
		}
	
	}
	public void CambioTextoAmbarYLaImagen()
	{
		if(btnAmbar == true)
		{
			título.text = "Ambar";
			info.text = "Experiecia del ambar junto con su historia y como ha ido evolucionando ";
		
		
		}
	
	}
	public void CambioTextoCafeYLaImagen()
	{
		if(btnCafe == true)
		{
			título.text = "Cafeteria";
			info.text = "Experiecia de la Cafeteria donde se podra recrear de todo lo vivido dentro del museo ";
			
		}
	
	}
    
    
}
