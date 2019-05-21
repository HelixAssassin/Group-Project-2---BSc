﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : EnemyHealth {

    protected Transform playerModel;
    protected CharacterController controller;
    protected float distance;
    protected bool isAttacking = false;
    protected bool isDamaged = false;

    private float damage = 10;

    // This allows the character object to move, jump and be affected by gravity
    [SerializeField] float jumpSpeed = 20.0f;
    [SerializeField] float gravity = 1.0f;
    float yVelocity = 0.0f;

    [SerializeField] float moveSpeed = 5.0f;
    public float h;
    public float v;

    // Use this for initialization
    void Start () {
        // This code segment allows the enemy game object to follow an object that is tagged with player.
        playerModel = GameObject.FindGameObjectWithTag("Player").transform;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveTowardsPlayer();
	}

    protected void MoveTowardsPlayer()
    {
        Vector3 direction = playerModel.position - transform.position;

        direction *= moveSpeed;
        Debug.Log(direction);

        transform.LookAt(playerModel.position);

        distance = Vector3.Distance(this.transform.position, playerModel.position);

        if (distance >= 2f && isAttacking == false && isDamaged == false && isDead == false)
        {
            controller.Move(direction * Time.deltaTime);

            anim.SetBool("IsAttacking", false);
        }
        else
        {
            anim.SetBool("IsAttacking", true);
        }
    }

    private void DamagePlayer()
    {
        GameObject.Find("Test Player").GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}