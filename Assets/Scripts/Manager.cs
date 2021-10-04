using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    
	//Botones
	public Button Touch;
	//Animator
	public Animator Anim;

    // Update is called once per frame
    void Update()
    {
	    Touch.onClick.AddListener(SeTocoTouch);
    }
    
	public void SeTocoTouch()
	{
		
		Anim.Play("SeTocoTouch");
		
	}
}
