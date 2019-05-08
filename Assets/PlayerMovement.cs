using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    CharacterController charController;

    //This part of the code allows the player to move in different directions and also sets the jump speed, move speed and gravity
    [SerializeField] float jumpSpeed = 20.0f;
    [SerializeField] float gravity = 1.0f;
    float yVelocity = 0.0f;

    [SerializeField] float moveSpeed = 5.0f;
    public float h;
    public float v;
    //Animator anim;

	// Use this for initialization
	void Start () {
        charController = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        //anim.SetFloat("Speed", v);
        //anim.SetFloat("Direction", h);

        // This is the movespeed variable for the player and this allows the object to move.
        Vector3 direction = new Vector3 (h, 0, v);
        Vector3 velocity = direction * moveSpeed;

        if (charController.isGrounded) {
            if (Input.GetButtonDown("Jump"))
            {
                //anim.SetTrigger("Jump");
                yVelocity = jumpSpeed;
            }

        } else{
            yVelocity -= gravity;
        }
        velocity.y = yVelocity;

        velocity = transform.TransformDirection(velocity);

        charController.Move(velocity*Time.deltaTime);
		
	}

    private void OnCollisionEnter(Collision collisionInfo)
    {
        print("hit");
        if (collisionInfo.gameObject.tag == "Elevator")
        {
            //transform.parent = collisionInfo.transform;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        transform.parent = null;

    }
}