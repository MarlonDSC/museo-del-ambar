using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Estrellas : MonoBehaviour
{
	public Button EstrellaUno, EstrellaDos, EstrellaTres, EstrellaCuatro, EstrellaCinco;
	
	
	//tt
    // Start is called before the first frame update
    void Start()
    {
	    EstrellaUno.onClick.AddListener(Estrella1);
	    EstrellaDos.onClick.AddListener(Estrella2);
	    EstrellaTres.onClick.AddListener(Estrella3);
	    EstrellaCuatro.onClick.AddListener(Estrella4);
	    EstrellaCinco.onClick.AddListener(Estrella5);
	    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    
    
    
    
	public void Estrella1()
	{
		if(EstrellaUno == true)
		{
			EstrellaUno.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
			EstrellaDos.GetComponent<Image>().color = new Color32(255, 255, 255, 255); 
			////////////////////////////////////////////////////////////////////////// 
			EstrellaDos.GetComponent<Image>().color = new Color32(255, 255, 255, 255); 
			EstrellaTres.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
			EstrellaCuatro.GetComponent<Image>().color = new Color32(255, 255, 255, 255); 
			EstrellaCinco.GetComponent<Image>().color = new Color32(255, 255, 255, 255); 
		}
		
		
	}
	
	
	public void Estrella2()
	{
		if(EstrellaDos == true)
		{
			EstrellaUno.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
			EstrellaDos.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
			//////////////////////////////////////////////////////////////////////////
			EstrellaTres.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
			EstrellaCuatro.GetComponent<Image>().color = new Color32(255, 255, 255, 255); 
			EstrellaCinco.GetComponent<Image>().color = new Color32(255, 255, 255, 255); 
		}
	}
	
	public void Estrella3()
	{
		if(EstrellaTres== true)
		{
			EstrellaUno.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
			EstrellaDos.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
			EstrellaTres.GetComponent<Image>().color = new Color32(255, 213, 0, 255);
			//////////////////////////////////////////////////////////////////////////
			EstrellaCuatro.GetComponent<Image>().color = new Color32(255, 255, 255, 255); 
			EstrellaCinco.GetComponent<Image>().color = new Color32(255, 255, 255, 255); 
		
			
		}
	}
	
	public void Estrella4()
	{
		if(EstrellaCuatro == true)
		{
			EstrellaUno.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
			EstrellaDos.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
			EstrellaTres.GetComponent<Image>().color = new Color32(255, 213, 0, 255);
			EstrellaCuatro.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
			//////////////////////////////////////////////////////////////////////////
			EstrellaCinco.GetComponent<Image>().color = new Color32(255, 255, 255, 255); 
		}
	}
	
	public void Estrella5()
	{
		if(EstrellaCinco == true)
		{
			EstrellaUno.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
			EstrellaDos.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
			EstrellaTres.GetComponent<Image>().color = new Color32(255, 213, 0, 255);
			EstrellaCuatro.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
			EstrellaCinco.GetComponent<Image>().color = new Color32(255, 213, 0, 255); 
		}
	}
}
