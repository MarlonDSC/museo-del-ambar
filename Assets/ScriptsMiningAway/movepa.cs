using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movepa : MonoBehaviour
{
	
	FixedJoystick eljoy;
	Rigidbody2D rb;
	public float moveSpeed, jumpForce;
	public Animator Anim;
	public Button saltar;	
	public bool grounded=true;
	bool salto;
	// Start is called before the first frame update
    void Start()
	{
		eljoy = FindObjectOfType<FixedJoystick>();
		eljoy = FindObjectOfType<FixedJoystick>();
		grounded=true;
		rb=GetComponent<Rigidbody2D>();
		moveSpeed= 15f;
		jumpForce = 7;
		
		saltar.onClick.AddListener(ensantiagonohayplaya);

        
    }

    // Update is called once per frame
    void Update()
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
	    }
	    if(salto){
	    	
	    	rb.velocity =Vector2.up * jumpForce;
		    saltar.interactable = false;
	    }
        
    }
    
	void ensantiagonohayplaya (){
		salto = true;
		StartCoroutine(nosaltona());
		
	}
	
	IEnumerator nosaltona(){
		yield return new WaitForSeconds(0.4f);
		salto = false;
		
	}
}
