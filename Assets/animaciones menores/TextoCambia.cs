using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Sprites;
public class TextoCambia : MonoBehaviour
{
	//textos
	public TextMeshProUGUI título;
	public TextMeshProUGUI info;
	public TextMeshProUGUI tituloImagenes;
	//Botones 
	public GameObject btnTabaco;
	public GameObject btnLinterna;
	public GameObject btnVr;
	public GameObject btnJuegos;
	public GameObject btnCigarro;
	public GameObject btnCafe;
	// Rawimages
	public Image ImagenRecuadro1;
	public Image ImagenDelVr1;
	//Texturas de las imagnes
	public Sprite Tabao1;
	public Sprite VR1;
	

	
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
			tituloImagenes.text  = "";
			
			ImagenRecuadro1.sprite = Tabao1;
		}
	
	}
	
	public void CambioDeTextoVRYlaImagen()
	{
		título.text = "VR";
		info.text = "Experiecia del VR junto con su historia y como ha ido evolucionando";
		tituloImagenes.text  = "";
		
		ImagenRecuadro1.sprite = VR1;
	}
	
	
	public void CambioTextoLinternaYLaImagen()
	{
		if(btnLinterna == true)
		{
			título.text = "OBSERVACION DEL AMBAR";
			info.text = "Experiecia de observacion del ambar  junto con su historia y como ha ido evolucionando";
			tituloImagenes.text  = "";
			
		
		}
	
	}
	
	public void CambioTextoCigarroYLaImagen()
	{
		if(btnCigarro == true)
		{
			título.text = "MARIDAJE";
			info.text = "Experiecia del Maridaje junto con su historia y como ha ido evolucionando";
			tituloImagenes.text  = "";
			
		}
	
	}
	public void CambioTextoJuegosYLaImagen()
	{
		if(btnJuegos == true)
		{
			título.text = "MiniJuegos";
			info.text = "Experiecia de los minijuegos junto con ambarito ";
			tituloImagenes.text  = "";
			
			ImagenRecuadro1.sprite = Tabao1;
		}
	
	}
	public void CambioTextoCafeYLaImagen()
	{
		if(btnCafe == true)
		{
			título.text = "Cafeteria";
			info.text = "Experiecia del Cafeteria junto con su historia y como ha ido evolucionando";
			tituloImagenes.text  = "";
			
			ImagenRecuadro1.sprite = Tabao1;
		}
	
	}
}
