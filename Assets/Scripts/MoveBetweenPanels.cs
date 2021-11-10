using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBetweenPanels : MonoBehaviour
{
	public GameObject previousPanel;
	public GameObject nextPanel;

	public void PreviousPanel(){
		previousPanel.SetActive(true);
		gameObject.SetActive(false);
		
	}
	
	public void NextPanel(){
		nextPanel.SetActive(true);
		gameObject.SetActive(false);
	}
	
	public void OpenScene(string Scene)
	{
		SceneManager.LoadScene(Scene);
	}
	
	public void CloseScene(string Scene)
	{
		SceneManager.UnloadScene(Scene);
	}
	
	public void AbrirLink(string Url)
	{
		Application.OpenURL("http://" + Url);
	}

}
