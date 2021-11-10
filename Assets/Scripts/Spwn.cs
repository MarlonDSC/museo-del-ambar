using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwn : MonoBehaviour
{
	public float tiempo = 0;
	public float tiempodeEspera = 1;
	public GameObject ElTubo;
	public float altura;
	
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		
		tiempo += Time.deltaTime;
		
		
		if(tiempo > tiempodeEspera){
			
		 Instantiate(ElTubo,transform.position + new Vector3(0,Random.Range(-altura, altura),0),transform.rotation);
			tiempo = 0;
		}
		
		tiempo += Time.deltaTime;
	}
   
   
   
}
