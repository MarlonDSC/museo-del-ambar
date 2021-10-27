using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproduceAnimacion : MonoBehaviour
{
	
	//Contador
	private int ParOImpar;
	//Contadores panel menores total
	private int ContadorBtnAmbarOrigen;
	private int ContadorBtnJuegosOrigen;
	//Contadores panel menores Origen
	private int ContadorBtnAmbar;
	private int ContadorBtnJuegos;
	private int ContadorBtnLinterna;
	private int ContadorBtnVR;
	private int ContadorBtnTabaco;
	//Botones panel menores Origen
	public GameObject BtnAmbarOrigen;
	public GameObject BtnJuegosOrigen;
	//Botones panel menores total
	public GameObject BtnAmbar; 
	public GameObject BtnJuegos;
	public GameObject BtnLinterna;
	public GameObject BtnVR;
	public GameObject BtnTabaco;
	//Animator paneles padres
	public Animator PanelDetallesDeLaExperienciaTotalMenores;
	public Animator PanelDetallesDeLaExperienciaOrigenMenores;
	//Animations panel menores total
	public AnimationClip ExperienciaAmbarOrigen;
	public AnimationClip ExperienciaAmbarCierreOrigen;
	public AnimationClip ExperienciaJuegosOrigen;
	public AnimationClip ExperienciaJuegosCierreOrigen;
	public AnimationClip ExpVRAbre;
	public AnimationClip ExpVRCierra;
	//Animations panel menores total
	public AnimationClip ExperienciaAmbar;
	public AnimationClip ExperienciaAmbarCierre;
	public AnimationClip ExperienciaJuegos;
	public AnimationClip ExperienciaJuegosCierre;
	public AnimationClip ExperienciaLinterna;
	public AnimationClip ExperienciaLinternaCierre;

	public AnimationClip ExperienciaTabaco;
	public AnimationClip ExperienciaTabacoCierre;
	

	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    
	    
    }
    
	public void VRAnimReproduce()
	{
		if(BtnVR == true)
		{
			ContadorBtnVR++;
			if(ContadorBtnVR % 2 != 0)
			{
				PanelDetallesDeLaExperienciaOrigenMenores.Play(ExpVRAbre.name);
				
		
			}
			
			if(ContadorBtnVR % 2 == 0)
			{
	
				PanelDetallesDeLaExperienciaOrigenMenores.Play(ExpVRCierra.name);		
			}
		}
	}
    
	//contadores panel experiencia origen menores    
	public void ContadorAmbarOrigen()
	{
		
		if(BtnAmbarOrigen == true )
		{
			ContadorBtnAmbarOrigen++;
		
	
			if(ContadorBtnAmbarOrigen % 2 != 0)
			{
				PanelDetallesDeLaExperienciaOrigenMenores.Play(ExperienciaAmbarOrigen.name);
				
		
			}
			
			if(ContadorBtnAmbarOrigen % 2 == 0)
			{
	
				PanelDetallesDeLaExperienciaOrigenMenores.Play(ExperienciaAmbarCierreOrigen.name);		
			}
			
			
		}
	
	}
	
	public void ContadorJuegosOrigen()
	{
		
		if(BtnJuegosOrigen == true )
		{
			ContadorBtnJuegosOrigen++;
		
	
			if(ContadorBtnJuegosOrigen % 2 != 0)
			{
				PanelDetallesDeLaExperienciaOrigenMenores.Play(ExperienciaJuegosOrigen.name);
				
		
			}
			
			if(ContadorBtnJuegosOrigen % 2 == 0)
			{
	
				PanelDetallesDeLaExperienciaOrigenMenores.Play(ExperienciaJuegosCierreOrigen.name);		
			}
			
			
		}
	
	}
	
	
	
	
	//contadores panel experiencia total menores
	public void Contador()
	{
		
		if(BtnAmbar == true )
		{
			ContadorBtnAmbar++;
		
	
			if(ContadorBtnAmbar % 2 != 0)
			{
				PanelDetallesDeLaExperienciaTotalMenores.Play(ExperienciaAmbar.name);
				
		
			}
			
			if(ContadorBtnAmbar % 2 == 0)
			{
	
				PanelDetallesDeLaExperienciaTotalMenores.Play(ExperienciaAmbarCierre.name);		
			}
			
			
		}
	
	}
	
	public void ContadorTabaco()
	{
		
		if(BtnTabaco == true )
		{
				ContadorBtnTabaco++;
		
	
				if(ContadorBtnTabaco % 2 != 0)
				{
					PanelDetallesDeLaExperienciaTotalMenores.Play(ExperienciaTabaco.name);
				
		
				}
			
				if(ContadorBtnTabaco % 2 == 0)
				{
	
					PanelDetallesDeLaExperienciaTotalMenores.Play(ExperienciaTabacoCierre.name);			
				}

	
			}

	}
	
	public void ContadorJuegos()
	{
			if(BtnJuegos == true )
			{
				ContadorBtnJuegos++;
		
	
				if(ContadorBtnJuegos % 2 != 0)
				{
					PanelDetallesDeLaExperienciaTotalMenores.Play(ExperienciaJuegos.name);
				
		
				}
			
				if(ContadorBtnJuegos % 2 == 0)
				{
	
					PanelDetallesDeLaExperienciaTotalMenores.Play(ExperienciaJuegosCierre.name);

			
				}
			}
	
	}
	
	public void contadorLinterna()
	{
	
			if(BtnLinterna == true )
			{
				ContadorBtnLinterna++;
		
	
				if(ContadorBtnLinterna % 2 != 0)
				{
					PanelDetallesDeLaExperienciaTotalMenores.Play(ExperienciaLinterna.name);
				
		
				}
			
				if(ContadorBtnLinterna % 2 == 0)
				{
	
					PanelDetallesDeLaExperienciaTotalMenores.Play(ExperienciaLinternaCierre.name);				
				}
				
			}
	}
	

	
	
	
}
