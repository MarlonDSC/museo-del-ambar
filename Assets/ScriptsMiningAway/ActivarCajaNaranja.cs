using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCajaNaranja : MonoBehaviour
{
	
	public Animator BloqueNaranjaAnim;
	public bool SeActivo=false;
	
	
	
	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(collisionInfo.gameObject.tag=="Player")
		{
			
			BloqueNaranjaAnim.Play("SeActivoElBloque");
			SeActivo=true;

			
		}
		
	}
}
