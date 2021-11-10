using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomAR : MonoBehaviour
{
	
	private float InitialDistance;
	private Vector3 InitialScale; 
	// Start is called before the first frame update
	void Start()
	{
        
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.touchCount == 2)
		{
			var TouchZero = Input.GetTouch(0);
			var TouchOne = Input.GetTouch(1);
	    	
			if(TouchZero.phase == TouchPhase.Ended || TouchZero.phase == TouchPhase.Canceled || TouchOne.phase == TouchPhase.Ended || TouchOne.phase == TouchPhase.Canceled)
			{
				return;
			}
	    	
			if(TouchZero.phase == TouchPhase.Began ||  TouchOne.phase == TouchPhase.Began )
			{
				InitialDistance = Vector2.Distance(TouchZero.position, TouchOne.position);
				InitialScale = gameObject.transform.localScale;
	    	
			}
			else
			{
				var currentDistance = Vector2.Distance(TouchZero.position, TouchOne.position);
				if(Mathf.Approximately(InitialDistance, 0))
				{
					return;
				}
	    		
				var factor = currentDistance / InitialDistance;
				gameObject.transform.localScale = InitialScale * factor; 
			}
		}
	}
}