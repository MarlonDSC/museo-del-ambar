using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanicaEstalagnita : MonoBehaviour
{
	public VerSiHayPlayer Script;
	public Player ScriptPlayer;
	public bool rbActivado=false;
	Rigidbody2D m_Rigidbody2D;
	



	
 // Update is called every frame, if the MonoBehaviour is enabled.
 protected void Update()
 {
 	if(Script.HayPlayer==true & rbActivado==false)
 	{
 		
	 	Rigidbody2D rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
	 	rbActivado=true;
 	}
 	
 	
 	if(rbActivado==true)
 	{
	 	m_Rigidbody2D = GetComponent<Rigidbody2D>();
	 	m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
 	}
 }
}
