using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ManagerAmabarito : MonoBehaviour
{
	//public GameObject CarpetaJuegoInicial;
	//public GameObject Camera;
	
	//public GameObject PanelMenu;
	public GameObject PanelInicio;
	
	//public GameObject Flecha;
	//public GameObject CarpetaMultyUno;
	//public GameObject CarpetaMultyDos;
	//public GameObject PanelMulti;
	
	
	public GameObject PanelGameover1;
	//public GameObject PanelGameover2;
	//public GameObject PanelGameover3;
	//public GameObject PanelGameover4;
	
	public GameObject BotonIniciar1;
	//	public GameObject BotonIniciar2;
	
	public GameObject PanelTienda;
	
	public GameObject PanelAdvertencia;
	

	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		//	Other2.Play("ambarito");

	}
	
	public void CerrarMultiSingle()
	{
	 
	 //PanelMenu.SetActive(true);
		//CarpetaMultyUno.SetActive(false);
		//PanelMulti.SetActive(false);
		//CarpetaMultyDos.SetActive(false);
		
		//CarpetaJuegoInicial.SetActive(true);
		//	Camera.SetActive(true);
		
		//	PanelGameover2.SetActive(false);
		PanelGameover1.SetActive(false);
		//	PanelGameover3.SetActive(false);
		//PanelGameover4.SetActive(false);
		
		PanelTienda.SetActive(false);
		
		PanelAdvertencia.SetActive(false);
		
		BotonIniciar1.SetActive(true);
		//BotonIniciar2.SetActive(true);
		
		
		Time.timeScale=0;
	}
	
	
	public void Papo()
	{
		
		//CarpetaJuegoInicial.SetActive(true);
		//	Camera.SetActive(true);
		//PanelMenu.SetActive(false);
		
		//	CarpetaMultyDos.SetActive(false);
		//	CarpetaMultyUno.SetActive(false);
		
	}
	
	//BOTONES//
	//public GameObject IniciarBt;
	//public GameObject MenuBT;
	public GameObject BotonReplayBT;

	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		
		PanelInicio.SetActive(true);
		PanelGameover1.SetActive(false);
		PanelTienda.SetActive(false);
		PanelAdvertencia.SetActive(false);
		
		Time.timeScale=0;
		StartCoroutine(tiempoDeDia());

	}
	
	
	public void Replay()
	{
		SceneManager.LoadScene(0);
		
	}
	
	public void Iniciar()
	{
		
		Time.timeScale=1;
		
	}
    
    
	public void IniciarMulty()
	{
		
		Time.timeScale=1;
		//CarpetaJuegoInicial.SetActive(false);
	}
	
		public void INICIARMULTY()
	{
		//CarpetaMultyUno.SetActive(true);
		//CarpetaMultyDos.SetActive(true);
		//CarpetaJuegoInicial.SetActive(false);
		PanelInicio.SetActive(false);
		//	Camera.SetActive(false);
		
		PanelInicio.SetActive(false);
		//PanelMulti.SetActive(true);
		//PanelMenu.SetActive(false);
		Time.timeScale=0;
		
		
	}
	//public Animator Advertencia;
	//public Animator Apagaradvertencia;
	
	public void VolverAlInicio(){
		
		PanelTienda.SetActive(false);
		PanelAdvertencia.SetActive(false);
		PanelInicio.SetActive(true);
	}
	
	public void EncenderAdvertencia(){
		PanelAdvertencia.SetActive(true);
		//Advertencia.Play("advertenciaactivada");
		
		
	}
	
	public void ApagarAdvertencia(){
		
		PanelAdvertencia.SetActive(false);
		//Apagaradvertencia.Play("apagarADvertencia");
		PanelTienda.SetActive(true);
		//	StartCoroutine(ApagarAdvertenciaEnumerator());
		
		Debug.Log("hola");
		
	}
	
	/*IEnumerator ApagarAdvertenciaEnumerator(){
	Apagaradvertencia.Play("apagarADvertencia");
	yield return new WaitForSeconds(2);
	PanelAdvertencia.SetActive(false);
	}
	*/
	//tiempos

	public Animator Other;
	public Animator Other2;

	IEnumerator tiempoDeDia()
	{
		Other.Play("New Animation");
		yield return new WaitForSeconds(10);

		StartCoroutine(tiempoDeNoche());
	}


	IEnumerator tiempoDeNoche()
	{
		Other.Play("New Animation1");
		yield return new WaitForSeconds(10);

		StartCoroutine(tiempoDeDia());

	}
	
	
	public void CerrarApp(){Application.Quit();}

	
}


