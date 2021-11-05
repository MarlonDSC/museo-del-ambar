using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptVR : MonoBehaviour
{
	private int ParOImpar;
	private int ContadorBtnVR;
	public GameObject BtnVR;
	public Animator PanelDetallesDeLaExperienciaTotalMenores;
	public AnimationClip ExperienciaVR;
	public AnimationClip ExperienciaVRCierre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void ContadorVR()
	{
		if(BtnVR == true)
		{
			ContadorBtnVR++;
			if(ContadorBtnVR % 2 != 0)
			{
				PanelDetallesDeLaExperienciaTotalMenores.Play(ExperienciaVR.name);
				
		
			}
			
			if(ContadorBtnVR % 2 == 0)
			{
	
				PanelDetallesDeLaExperienciaTotalMenores.Play(ExperienciaVRCierre.name);		
			}
		}
	}
}
