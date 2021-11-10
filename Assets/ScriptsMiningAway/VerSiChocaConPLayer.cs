using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerSiChocaConPLayer : MonoBehaviour
{
	public Animator Estalagnita;
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player")
		{
			//destruir esta estalagnita
			Estalagnita.Play("Estalagnita");
			
			//Destroy(this.gameObject,1);
			Destroy(transform.parent.gameObject);      
			  

			
			
		}
		
		if(other.gameObject.tag=="Piso")
		{
	
			//destruir esta estalagnita
			Estalagnita.Play("Estalagnita");
			
			//Destroy(this.gameObject,1);
			Destroy(transform.parent.gameObject);    
		}
	}
	
	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(collisionInfo.gameObject.tag=="Player")
		{
			//destruir esta estalagnita
			Estalagnita.Play("Estalagnita");
			
			//Destroy(this.gameObject,1);
			Destroy(transform.parent.gameObject);      
			  

			
			
		}
		
		if(collisionInfo.gameObject.tag=="Piso")
		{
	
			//destruir esta estalagnita
			Estalagnita.Play("Estalagnita");
			
			//Destroy(this.gameObject,1);
			Destroy(transform.parent.gameObject);    
		}
	}
}
