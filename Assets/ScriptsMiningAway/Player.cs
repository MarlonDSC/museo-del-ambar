using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	
	

	
	public bool PisandoElPiso=true;
	
	public int Vidas=5;
	public	bool CascoBool=false;
	public GameObject Casco;
	public int Monedas=0;
	public int MonedasGeneral=0;
	
	//bool SaltoIzquierda=false;
	//bool SaltoDerecho=false;
	
	public TextMeshProUGUI MonedasTx;
	public TextMeshProUGUI VidasTx;
	
	FixedJoystick eljoy;
	
	
	public bool conio=true;
	

	//Movement
	Rigidbody2D rb;
	public float moveSpeed, jumpForce;
	bool moveLeft, moveRight;
	
	public Animator Anim;
	public Animator Canvas;
	public Button salto;
	
	
	public void Replay()
	{
		SceneManager.LoadScene("LevelOne");

	}
	
	public void Inicio()
	{
		Time.timeScale=1;
		Canvas.Play("Iniciar");
		
	}
	

	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		salto.onClick.AddListener(Jump);
		
		eljoy = FindObjectOfType<FixedJoystick>();
		conio=false;
		PisandoElPiso=true;
		//	StartCoroutine(tutituti());
		rb=GetComponent<Rigidbody2D>();
		moveSpeed= 7f;
		moveLeft=false;
		moveRight=false;
		
		PisandoElPiso=true;

		Time.timeScale=0;
	}

	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		float x = eljoy.Horizontal;
	 if(x!=0){
		 transform.position +=new Vector3(x,0,0) * moveSpeed * Time.deltaTime;
	
		
	
		
		
		
		if(x<0){
			transform.rotation = Quaternion.Euler(0, -180, 0);
	
		
		}
		
		else{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		
		
		}
		
		
		 if(rb. velocity. magnitude==0)
		 {
			 Anim.Play("AmbaritoWalk");

		 }
		 
		 if(rb. velocity. magnitude!=0)
		 {
			 Anim.Play("AmbaritoIdle");

		 }
		
		
	 }
		
		
		
		VidasTx.text=Vidas.ToString();
		MonedasTx.text=Monedas.ToString();
		
		
		
		
		
		if(rb.velocity.y != 0 & PisandoElPiso==true)
		{
			//PisandoElPiso=false;
		
		}
	

	
		
	
		
		if(moveLeft)
		{
			rb.velocity = new Vector2(-moveSpeed, 0f);
			//	Anim.SetFloat("BlendTutiTuti", 0.3f);
		}

		if(moveRight)
		{
			rb.velocity = new Vector2(moveSpeed, 0f);
			//Anim.SetFloat("BlendTutiTuti", 0.3f);

		}
		
		
		//Si el jugador se quedo sin vidas...recargo scene
		if(Vidas==0)
		{
			string currentScene = SceneManager.GetActiveScene ().name; 
			SceneManager.LoadScene(currentScene);
			
		}
		
		if(PisandoElPiso==false)
		{
			//bt.SetActive(false);
			//bt1.SetActive(false);
			//	StartCoroutine(Desgracia());
		}
		if(PisandoElPiso==true)
		{
			//bt.SetActive(true);
			//bt1.SetActive(true);
			conio=false;

		}
	}
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
	
		if(other.gameObject.tag=="MineEntrance")
		{
			
			Canvas.Play("YouWin");
			//SceneManager.LoadScene("Level1Complete");

		}
		
		
		if(other.gameObject.tag=="Moneda")
		{
				
			Monedas++;
		}
			
	}


	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		
		if (collisionInfo.gameObject.tag == "Piso")
	 {
		 PisandoElPiso = true;
		 salto.interactable = true;

	 }
		
		if (collisionInfo.gameObject.tag == "VerConQueChoco")
	 {
		 

		 if(CascoBool==false)
		 {
		 	Vidas--;
		 	CascoBool=false;
		 }
		 else
		 {
		 	PisandoElPiso = true;
			 salto.interactable = true;
		 }

	 }
		if (collisionInfo.gameObject.tag == "Estalagnita")
	 {
		 
		 
		 if(CascoBool==false)
		 {
		 	Vidas--;
		 	CascoBool=false;
		 }
		 else
		 {
		 	PisandoElPiso = true;
			 salto.interactable = true;
		 }

	 }
		if (collisionInfo.gameObject.tag == "Bloque")
	 {
		 PisandoElPiso = true;
		 salto.interactable = true;

	 }
	 
	if(collisionInfo.gameObject.tag=="Bloque")
	{
			
		PisandoElPiso = true;

	}
	

	
	
	
		if(collisionInfo.gameObject.tag=="Casco")
		{
			Casco.SetActive(true);	
			CascoBool=true;

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
			
	
			if(collisionInfo.gameObject.tag=="Estalagnita")
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
	
	
	
			
		}
	
		











	public void MoveLeft()
	{
		
		if(PisandoElPiso==true)
		{    
			//transform.Rotate(new Vector3(0.0f,-180.0f,0.0f));
			transform.rotation = Quaternion.Euler(0, -180, 0);
			conio=false;


			moveLeft = true;
			//SaltoIzquierda=true;
			//SaltoDerecho=false;
			//	StartCoroutine(PorFavor());
			//StartCoroutine(tutituti());
			
			//rb.AddForce(Vector2.down* jumpForce);


		}

		//rb.AddForce(new Vector2(0.0f, -10.0f) * jumpForce);


	}

	public void MoveRight()
	{

		if(PisandoElPiso==true)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
			conio=false;
			moveRight = true;
			//SaltoIzquierda=false;
			//SaltoDerecho=true;
			//StartCoroutine(PorFavor());
			//StartCoroutine(tutituti());

			//rb.AddForce(Vector2.down* jumpForce);


			
		}
	
		//rb.AddForce(new Vector2(0.0f, -10.0f) * jumpForce);

	}

	public void Jump()
	{
		rb.velocity =Vector2.up * jumpForce;

		salto.interactable = false;
		if(rb.velocity.y == 0)
		{
			PisandoElPiso=false;
			Anim.Play("AmbaritoJump");
			

			//	Anim.SetFloat("BlendTutiTuti", 0.6f);
			//	Anim.SetFloat("BlendTutiTuti", 1.0f);

			rb.velocity =Vector2.up * jumpForce;
			/*

			if(SaltoDerecho==true)
			{
				rb.AddForce(new Vector2(0.3f, 1.0f) * jumpForce);
				conio=true;

			}
			
			if(SaltoIzquierda==true)
			{
				rb.AddForce(new Vector2(-0.3f, 1.0f) * jumpForce);
				conio=true;

			}
			*/
			
			//	StartCoroutine(hartancia());

		}
		
		
	}

	


	/*public void StopMoving()
	{
		moveLeft=false;
		moveRight=false;
		rb.velocity=Vector2.zero;
		Anim.SetFloat("BlendTuti", 0f);



	}
	*/
 
	// Sent when a collider on another object stops touching this object's collider (2D physics only).
	/*protected void OnCollisionExit2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.tag != "Piso"|| collisionInfo.gameObject.tag!="Bloque"|| collisionInfo.gameObject.tag=="Estalagnita")
	 {
		 PisandoElPiso = false;
	 }
	}
	
	
	IEnumerator hartancia()
	{
		yield return new WaitForSeconds(3f);
		conio=false;

	}
	IEnumerator tutituti()
	{
		
		
		yield return new WaitForSeconds(1.5f);
		PisandoElPiso=true;
		

		
		
	}
	IEnumerator PorFavor()
	{
		yield return new WaitForSeconds(1);

		bt.SetActive(false);
		bt1.SetActive(false);
		//rb.AddForce(new Vector2(0.0f, -1.0f) * jumpForce);
		

		
	

	}
	/*	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Aburrimiento");
		{
			StartCoroutine(tutituti());

		}
		if(other.gameObject.tag=="VerConQueToco");
		{
			StartCoroutine(tutituti());

		}
	}*/
	
	/*	public void Tired()
	{
		rb.AddForce(new Vector2(0.0f, -1.0f) * jumpForce);

	}
	
	
	IEnumerator Botones()
	{
		
		bt.SetActive(false);
		bt1.SetActive(false);
		conio=false;
		yield return new WaitForSeconds(3);

	}
	
	IEnumerator Desgracia()
	{
		yield return new WaitForSeconds(3);

		moveLeft=false;
		moveRight=false;

	}*/
}