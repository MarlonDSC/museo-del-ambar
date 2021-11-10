using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Flappy : MonoBehaviour
{
	IEnumerator Paleta()
	{ 
		yield return new WaitForSeconds(2);
		Time.timeScale=0;

	}
	
	public Animator Anim;
	
	public void Imiciar()
	{
		
		
		//PanelInicio.SetActive(false);
		//Anim.Play("Inicio");
	
		Time.timeScale=1;
	}
	
	public void Reintentar()
	{
		//SceneManager.LoadScene(SceneManager, LoadSceneMode);
		//SceneManager.GetActiveScene().name;
		//SceneManager.LoadScene();
		
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		string currentScene = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(currentScene);
		
	}
	
	public void GameOver()
	{
		Anim.Play("GameOver");

	}
	
	public float VelocidadUp=4;
	Rigidbody2D mirb;
	public bool Vida=true;
	public GameObject PanelInicio;
	
	public GameObject PanelGameOver;
	
	//Score//
	public int Score=0;
	public int HighScore=0;
	public TextMeshProUGUI ScoreText;
	
	public TextMeshProUGUI ScoreGameOver;
	public TextMeshProUGUI HighScoreGameOver;
	Vector3 OriginalPosition;

	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		mirb=GetComponent<Rigidbody2D>();
		OriginalPosition=new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		gameObject.transform.position=OriginalPosition;


	}
	
	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		
		if(collisionInfo.gameObject.tag=="tubo")
		{
			
			Vida=false;
			GameOver();
			
		}
		
		
	}
   
   
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.CompareTag("tuti"))
		{
			
			Score++;
			Debug.Log("ScoreUp");
			
		}
		
	}
	
	
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		
		if(Input.GetMouseButtonDown(0))
		{
			
			mirb.velocity = Vector2.up * VelocidadUp;
			
			
			
		}
		
		/*	if(Vida==false)
		{
			
			Time.timeScale=0;
			PanelGameOver.SetActive(true);
		}*/
		
		//Score//
		HighScore=PlayerPrefs.GetInt("HighScorePapo");

		
		ScoreText.text=Score.ToString();
		HighScoreGameOver.text=HighScore.ToString();
		ScoreGameOver.text=Score.ToString();

		
		if(HighScore<Score)
		{
			HighScore=Score;

			PlayerPrefs.SetInt("HighScorePapo", HighScore);
		}
		
		
		
		//	if(HighScore>=10)
		{
			//	Moneda.SetActive(true);
		}
		
		//	if(HighScore>=50)
		{
			//	Moneda2.SetActive(true);
		}
		
		//if(HighScore>=100)
		{
			//	Moneda3.SetActive(true);
		}
		
	}
	//monedas
	//public GameObject Moneda;
	//public GameObject Moneda2;
	//public GameObject Moneda3;

}
