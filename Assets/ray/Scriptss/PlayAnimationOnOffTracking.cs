using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnOffTracking : NYImageTrackerEventHandler
{
    public Animator targetAnim;

    public string onFoundAnimName;
	public string onLostAnimName;
    
	public GameObject objetoOFFon;
    
	bool activandoInvoke=false;

    public override void OnTrackingFound()
    {
	    //targetAnim.Play(onFoundAnimName);
	    
	    objetoOFFon.SetActive(true);
	    activandoInvoke=true;
	   
    }

    public override void OnTrackingLost()
    {
	    //targetAnim.Play(onLostAnimName);
	    
	    //objetoOFFon.SetActive(false);
	    activandoInvoke=false;
	    Invoke("ver", 8f);
    }
    
	void ver(){
		if(activandoInvoke==false){		
			objetoOFFon.SetActive(false);
		}
		
	}
    
}
