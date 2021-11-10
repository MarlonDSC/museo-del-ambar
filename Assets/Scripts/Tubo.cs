using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubo : MonoBehaviour
{
	
	public float Velocidad;
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		Destroy(this.gameObject,6);
	}
    // Update is called once per frame
    void Update()
    {
       
	    transform.position += Vector3.left*Velocidad*Time.deltaTime;
    }
}
