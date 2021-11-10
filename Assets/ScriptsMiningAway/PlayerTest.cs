using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTest : MonoBehaviour
{
   
	public int Vidas=5;
	bool CascoBool=false;
	public GameObject Casco;
	public int Monedas=0;
	public int MonedasGeneral=0;
	


	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		
		if(moveLeft)
		{
			rb.velocity = new Vector2(-moveSpeed, 0f);


		}

		if(moveRight)
		{
			rb.velocity = new Vector2(moveSpeed, 0f);


		}
		
		//Si el jugador se quedo sin vidas...
		if(Vidas==0)
		{
			//We declare a variable to store our currentScene's name. We get this through the SceneManager class's GetActiveScene method. 
			string currentScene = SceneManager.GetActiveScene ().name; 
			Debug.Log (currentScene); 
			//Here we are asking the SceneManager to load the desired scene. In this instance we're providing it our variable 'currentScene'
			SceneManager.LoadScene(currentScene);
			
		}
	}
  
	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		
		if(collisionInfo.gameObject.tag=="Casco")
		{
			Casco.SetActive(true);					
		}
		
		
		if(collisionInfo.gameObject.tag=="Enemigo")
		{  
			
			if(CascoBool==false)
			{
				Vidas=Vidas-1;
				
				
			}
			else
			{
				
				Casco.SetActive(false);
				
			}
			
	
			
			
		}
	}
		
		
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
				
		if(other.gameObject.tag=="VerConQueChoco")
		{  
			
			if(CascoBool==false)
			{
				
				Vidas=Vidas-1;
				
			}
			else
			{
				
				Casco.SetActive(false);
				
			}
			
			if(other.gameObject.tag=="Moneda")
			{
				
				Monedas=Monedas+1;
			}
			
				
		}
	}
	
	
	
	
	
	
	
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		rb=GetComponent<Rigidbody2D>();
		moveSpeed= 5f;
		jumpForce = 450f;
		moveLeft=false;
		moveRight=false;

	}













	


	//Movement
	Rigidbody2D rb;
	float moveSpeed, jumpForce;
	bool moveLeft, moveRight;

	public void MoveLeft()
	{
		moveLeft = true;

	}

	public void MoveRight()
	{
		moveRight = true;

	}

	public void Jump()
	{
		if(rb.velocity.y == 0)
		{
			rb.AddForce(Vector2.up * jumpForce);

		}

	}


	public void StopMoving()
	{
		moveLeft=false;
		moveRight=false;
		rb.velocity=Vector2.zero;


	}
}
