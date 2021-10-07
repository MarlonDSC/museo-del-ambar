using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	

}
