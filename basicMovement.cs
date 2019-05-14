﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement : MonoBehaviour {

    CharacterController varController;
	[SerializeField]float jumpSpeed = 20.0f;
	[SerializeField]float gravity = 1.0f;
	float yVelocity = 0.0f;
	[SerializeField]float moveSpeed = 5.0f;
	public HorizontalControl horizontal;
	public VerticalControl vertical;
	public RotateControl rotate;

	public enum HorizontalControl
	{
		Horizontal, Horizontal1, Horizontal2
	}

	public enum VerticalControl 
	{
		Vertical, Vertical1, Vertical2
	}

	public enum RotateControl
	{
		MouseX, JoystickX1, JoystickX2
	}
	
	public int playerNum;

	// Use this for initialization
	void Start () 
	{
		varController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float X = Input.GetAxis("JoystickX" + playerNum);
		Vector3 rot = transform.localEulerAngles;
		rot.y += X * 5;
		transform.localEulerAngles = rot;

		float h = Input.GetAxis("Horizontal" + playerNum);
		float v = Input.GetAxis("Vertical" + playerNum);
		Vector3 direction = new Vector3(h, 0, v);
		Vector3 velocity = direction * moveSpeed;
		if (varController.isGrounded)
		{
			if (Input.GetButtonDown("Jump"))
			{
				yVelocity = jumpSpeed;
			}
		}
		else
		{
			{
				yVelocity -= gravity;
			}
			velocity.y = yVelocity;
			velocity = transform.TransformDirection(velocity);
			varController.Move(velocity * Time.deltaTime);
		}
	}
}
