using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerSiHayPlayer : MonoBehaviour
{
	public bool HayPlayer=false;
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player")
		{
			
			HayPlayer=true;
			
			
		}
		
	
	}
	

}
