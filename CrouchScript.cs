using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchScript : MonoBehaviour {

	public CharacterController characterController;
	void Start () 
	{
		characterController = gameObject.GetComponent<CharacterController>();
	}

	void Update ()
	{
		if(Input.GetKey(KeyCode.C))
	    {
		characterController.height = 1f;
	    }
	    else
	    {
		characterController.height = 1.0f;
	    }
	}
}
	
