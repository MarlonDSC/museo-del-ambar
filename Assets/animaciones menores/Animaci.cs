using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaci : MonoBehaviour
{
	public GameObject BtnVR;
	private int ContadorBtnVR;
	public Animator klk;
	public AnimationClip ExpAbre;
	public AnimationClip ExpCierre;
	
	public void ContadoVR()
	{
		
		if(BtnVR == true )
		{
			ContadorBtnVR++;
		
	
			if(ContadorBtnVR % 2 != 0)
			{
				klk.Play(ExpAbre.name);
				
		
			}
			
			if(ContadorBtnVR % 2 == 0)
			{
	
				klk.Play(ExpCierre.name);
			}

		}
	}
}
