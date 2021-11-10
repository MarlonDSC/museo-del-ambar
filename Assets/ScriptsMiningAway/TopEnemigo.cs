using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopEnemigo : MonoBehaviour
{
    
    
	public Player PlayerScript;
	//	public GameObject sprite;
	//	public Animator Anim;
	//	public Animator Anim2;

	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(collisionInfo.gameObject.tag=="Player")
		{

			//StartCoroutine("Aplastar");
			//Anim.Play("DesaparecerLioMonstruoso");
			//Anim2.Play("DesaparecerMonstruo");
			Destroy(transform.parent.gameObject);      

		}
	}
    
	/*	IEnumerator Aplastar()
	{
		//yield return new WaitForSeconds(0.5f);


		
	}*/
    
}
