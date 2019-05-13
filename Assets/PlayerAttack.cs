﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Camera cam;
    public GameObject Hand;
    public Weapon myWeapon;
    Animator handanim;

    private float attackTimer;

    void Start() {
        handanim = Hand.GetComponent<Animator>();
        myWeapon = Hand.GetComponentInChildren<Weapon>();
    }

    void Update() {
        attackTimer += Time.deltaTime;
        if (Input.GetMouseButtonUp(0) && attackTimer >= myWeapon.attackCoolDown)
        {
            handanim.SetTrigger("attack");
            attackTimer = 0f;
            DoAttack();
        }
     }

   private void DoAttack()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray , out hit, myWeapon.attackRange))
        {
            if(hit.collider.tag == "Enemy")
            {
                EnemyHealth eHealth = hit.collider.GetComponent<EnemyHealth>();
                eHealth.TakeDamage(myWeapon.attackDamage);
            }
        }
    }
}