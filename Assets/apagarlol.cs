using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class apagarlol : MonoBehaviour
{
	Animator animator;
	//public Button button;
	public GameObject previousPanel;
	public AnimationClip animationClip;
	
	
    // Start is called before the first frame update
    void Start()
    {
	    animator = GetComponent<Animator>();
    }

   
	public void CancelButton(){
		StartCoroutine(Animate());
	}
   
   
	private IEnumerator Animate(){
		animator.Play(animationClip.name);
		yield return new WaitForSeconds(animationClip.length);
		//gameObject.SetActive(false);
		previousPanel.SetActive(true);
		this.gameObject.SetActive(false);
	}
   
}
