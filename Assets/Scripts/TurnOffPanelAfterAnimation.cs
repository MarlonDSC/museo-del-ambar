using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPanelAfterAnimation : MonoBehaviour
{
	public AnimationClip animationClip;
	public Animator animator;
	public GameObject panel;
 
	public void SetTrigger()
	{
		//StartCoroutine(PerformAnimRoutine());
		//Solo tomare una foto
		//tt
	}
 
	//private IEnumerator PerformAnimRoutine()
	//{
		//var state = animation.PlayQueued("anim_1", QueueMode.PlayNow, PlayMode.StopSameLayer);
		//ggracias profe
		//yield return new WaitForSeconds(state.length);
     
		//var state = animator.PlayQueued("Close", QueueMode.PlayNow, PlayMode.StopSameLayer);
		//animator = animator.Play(animationClip);
 
		//yield return new WaitForSeconds(animator.);
     
		///panel.gameObject.SetActive(false);
	}
//
