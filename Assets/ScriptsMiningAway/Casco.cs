using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casco : MonoBehaviour
{
	public bool Hayrb=false;
	public ActivarCajaNaranja ScriptActivarCajaNaranja;
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if(ScriptActivarCajaNaranja.SeActivo == true & Hayrb==false)
		{
			Hayrb=true;
			
			Rigidbody2D rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;

		
		}
	}
	
	
	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(collisionInfo.gameObject.tag=="Player")
		{
			Destroy(gameObject);      

		}
	}
    
}
