using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPanelAfterAnimation : MonoBehaviour
{	
	public Animation anim;

	public void SetTrigger()
	{
		StartCoroutine(PerformAnimRoutine());
	}

	private IEnumerator PerformAnimRoutine()
	{
		var state = anim.PlayQueued("Fade_In", QueueMode.PlayNow, PlayMode.StopSameLayer);

		yield return new WaitForSeconds(state.length);

		gameObject.SetActive(false);
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
