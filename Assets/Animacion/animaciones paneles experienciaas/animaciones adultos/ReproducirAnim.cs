using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirAnim : MonoBehaviour
{
	private int paroimpar;
	//Contadores Mayores origen
	private int ContadorBtnCafeHistoria;
	private int ContadorBtnAmbarHistoria;
	//Contadores Mayores maridaje
	private int ContadorBtnCafeMaridaje;
	private int ContadorBtnAmbarMaridaje;
	private int ContadorBtnCigarroMaridaje;
	private int ContadorBtnTabacoMaridaje;
	//Contadores Mayores Total
	private int ContadorBtnCafeTotal;
	private int ContadorBtnAmbarTotal;
	private int ContadorBtnCigarroTotal;
	private int ContadorBtnTabacoTotal;
	private int ContadorBtnLinternaTotal;
	private int ContadorBtnVrTotal;
	//Botones panel mayores historia
	public GameObject BtnCafeHistoria;
	public GameObject BtnAmbarHistoria;
	//Botones panel mayores maridaje
	public GameObject BtnCafeMaridaje;
	public GameObject BtnAmbarMaridaje;
	public GameObject BtnCigarroMaridaje;
	public GameObject BtnTabacoMaridaje;
	//Botones panel mayores total
	public GameObject BtnCafeTotal;
	public GameObject BtnAmbarTotal;
	public GameObject BtnCigarroTotal;
	public GameObject BtnTabacoTotal;
	public GameObject BtnLinternaTotal;
	public GameObject BtnVrTotal;
	//Animator Paneles Padres
	public Animator PanelExperienciaMayoresHistoria;
	public Animator PanelExperienciaMayoresTotal;
	public Animator PanelExperienciaMayoresMaridaje;
	//Animations panel mayores Historia
	public AnimationClip ExperienciaHistoriaCafe;
	public AnimationClip ExperienciaHistoriaCafeCierre;
	public AnimationClip ExperienciaHistoriaAmbar;
	public AnimationClip ExperienciaHistoriaAmbarCierre;
	//Animations panel mayores Maridaje
	public AnimationClip ExperienciaMaridajeCafe;
	public AnimationClip ExperienciaMaridajeCafeCierre;
	public AnimationClip ExperienciaMaridajeAmbar;
	public AnimationClip ExperienciaMaridajeAmbarCierre;
	public AnimationClip ExperienciaMaridajeCigarro;
	public AnimationClip ExperienciaMaridajeCigarroCierre;
	public AnimationClip ExperienciaMaridajeTabaco;
	public AnimationClip ExperienciaMaridajeTabacoCierre;
	//Animations panel mayores total
	public AnimationClip ExperienciaTotalCafe;
	public AnimationClip ExperienciaTotalCafeCierre;
	public AnimationClip ExperienciaTotalAmbar;
	public AnimationClip ExperienciaTotalAmbarCierre;
	public AnimationClip ExperienciaTotalCigarro;
	public AnimationClip ExperienciaTotalCigarroCierre;
	public AnimationClip ExperienciaTotalTabaco;
	public AnimationClip ExperienciaTotalTabacoCierre;
	public AnimationClip ExperienciaTotalLinterna;
	public AnimationClip ExperienciaTotalLinternaCierre;
	public AnimationClip ExperienciaTotalVr;
	public AnimationClip ExperienciaTotalVrCierre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	// contadores experiencia historia adultos 
	
	public void ContadorCafeHistoria()
	{
	
		if(BtnCafeHistoria == true)
		{
			
			ContadorBtnCafeHistoria++;
			
			if (ContadorBtnCafeHistoria % 2 !=0)
			{
				
				PanelExperienciaMayoresHistoria.Play(ExperienciaHistoriaCafe.name);
				
			}
			
			if (ContadorBtnCafeHistoria % 2 == 0)
			{
				
				PanelExperienciaMayoresHistoria.Play(ExperienciaHistoriaCafeCierre.name);
					
			}
		}	
	}
	
	public void ContadorAmbarHistoria()
	{
	
		if(BtnAmbarHistoria == true)
		{
			
			ContadorBtnAmbarHistoria++;
			
			if (ContadorBtnAmbarHistoria % 2 !=0)
			{
				
				PanelExperienciaMayoresHistoria.Play(ExperienciaHistoriaAmbar.name);
				
			}
			
			if (ContadorBtnAmbarHistoria % 2 == 0)
			{
				
				PanelExperienciaMayoresHistoria.Play(ExperienciaHistoriaAmbarCierre.name);
					
			}
		}	
	}
	
	public void ContadorAmbarMaridaje()
	{
	
		if(BtnAmbarMaridaje == true)
		{
			
			ContadorBtnAmbarMaridaje++;
			
			if (ContadorBtnAmbarMaridaje % 2 !=0)
			{
				
				PanelExperienciaMayoresMaridaje.Play(ExperienciaMaridajeAmbar.name);
				
			}
			
			if (ContadorBtnAmbarMaridaje % 2 == 0)
			{
				
				PanelExperienciaMayoresMaridaje.Play(ExperienciaMaridajeAmbarCierre.name);
					
			}
			
			Debug.Log("klk");
		}	
	}
	public void ContadorCafeMaridaje()
	{
	
		if(BtnCafeMaridaje == true)
		{
			
			ContadorBtnCafeMaridaje++;
			
			if (ContadorBtnCafeMaridaje % 2 !=0)
			{
				
				PanelExperienciaMayoresMaridaje.Play(ExperienciaMaridajeCafe.name);
				
			}
			
			if (ContadorBtnCafeMaridaje % 2 == 0)
			{
				
				PanelExperienciaMayoresMaridaje.Play(ExperienciaMaridajeCafeCierre.name);
					
			}
		}	
	}
	
	public void ContadorCigarrosMaridaje()
	{
	
		if(BtnCigarroMaridaje == true)
		{
			
			ContadorBtnCigarroMaridaje++;
			
			if (ContadorBtnCigarroMaridaje % 2 !=0)
			{
				
				PanelExperienciaMayoresMaridaje.Play(ExperienciaMaridajeCigarro.name);
				
			}
			
			if (ContadorBtnCigarroMaridaje % 2 == 0)
			{
				
				PanelExperienciaMayoresMaridaje.Play(ExperienciaMaridajeCigarroCierre.name);
					
			}
		}	
	}
	
	public void ContadorTabacoMaridaje()
	{
	
		if(BtnTabacoMaridaje == true)
		{
			
			ContadorBtnTabacoMaridaje++;
			
			if (ContadorBtnTabacoMaridaje % 2 !=0)
			{
				
				PanelExperienciaMayoresMaridaje.Play(ExperienciaMaridajeTabaco.name);
				
			}
			
			if (ContadorBtnTabacoMaridaje % 2 == 0)
			{
				
				PanelExperienciaMayoresMaridaje.Play(ExperienciaMaridajeTabacoCierre.name);
					
			}
		}	
	}
	
	// contadores experiencia total adultos 
	public void ContadorAmbarTotal()
	{
	
		if(BtnAmbarTotal == true)
		{
			
			ContadorBtnAmbarTotal++;
			
			if (ContadorBtnAmbarTotal % 2 !=0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalAmbar.name);
				
			}
			
			if (ContadorBtnAmbarTotal % 2 == 0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalAmbarCierre.name);
					
			}
		}	
	}
	
	public void ContadorCafeTotal()
	{
	
		if(BtnCafeTotal == true)
		{
			
			ContadorBtnCafeTotal++;
			
			if (ContadorBtnCafeTotal % 2 !=0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalCafe.name);
				
			}
			
			if (ContadorBtnCafeTotal % 2 == 0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalCafeCierre.name);
					
			}
		}
	}
	
	public void ContadorCigarroTotal()
	{
	
		if(BtnCigarroTotal == true)
		{
			
			ContadorBtnCigarroTotal++;
			
			if (ContadorBtnCigarroTotal % 2 !=0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalCigarro.name);
				
			}
			
			if (ContadorBtnCigarroTotal % 2 == 0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalCigarroCierre.name);
					
			}
		}
	}
		
	public void ContadorTabacoTotal()
	{
	
		if(BtnTabacoTotal == true)
		{
			
			ContadorBtnTabacoTotal++;
			
			if (ContadorBtnTabacoTotal % 2 !=0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalTabaco.name);
				
			}
			
			if (ContadorBtnTabacoTotal % 2 == 0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalTabacoCierre.name);
					
			}
		}
	}
		
	public void ContadorLinternaTotal()
	{
	
		if(BtnLinternaTotal == true)
		{
			
			ContadorBtnLinternaTotal++;
			
			if (ContadorBtnLinternaTotal % 2 !=0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalLinterna.name);
				
			}
			
			if (ContadorBtnLinternaTotal % 2 == 0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalLinternaCierre.name);
					
			}
		
		}
	}
    
	public void ContadorVRTotal()
	{
	
		if(BtnVrTotal == true)
		{
			
			ContadorBtnVrTotal++;
			
			if (ContadorBtnVrTotal % 2 !=0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalVr.name);
				
			}
			
			if (ContadorBtnVrTotal % 2 == 0)
			{
				
				PanelExperienciaMayoresTotal.Play(ExperienciaTotalVrCierre.name);
					
			}
		
		}
	}
    
}
