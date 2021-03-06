﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private GameObject sword;

    [SerializeField] private GameObject axe;

    private Animator anim;

    private bool secondAttack;

    private bool firstAttack;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            secondAttack = true;

            FirstAttackAgain();

            firstAttack = true;

            FirstAttack();
        }
        else
        {
            
        }
    }

    private void SecondAttack()
    {
        if (secondAttack == true)
        {
            anim.SetBool("SecondAttack", true);
        }
    }

    private void DisableSecondAttack()
    {
        secondAttack = false;

        anim.SetBool("SecondAttack", false);
    }

    private void FirstAttack()
    {
        anim.SetBool("FirstAttack", true);

        firstAttack = true;
    }


    private void DisableFirstAttack()
    {
        firstAttack = false;

        anim.SetBool("FirstAttack", false);
    }

    private void FirstAttackAgain()
    {
        if (firstAttack == true)
        {
            anim.SetBool("FirstAttackAgain", true);
        }
    }

    private void DisableAttackRepeat()
    {
        anim.SetBool("FirstAttackAgain", false);
    }

    private void EnableRunning()
    {
        anim.SetBool("Running", true);
    }

    private void DisableRunning()
    {
        anim.SetBool("Running", false);
    }

    private void EnableSword()
    {
        BoxCollider swordCollider = sword.GetComponent<BoxCollider>();

        swordCollider.enabled = true;

        BoxCollider axeCollider = axe.GetComponent<BoxCollider>();

        axeCollider.enabled = true;
    }

    private void DisableSword()
    {
        BoxCollider swordCollider = sword.GetComponent<BoxCollider>();

        swordCollider.enabled = false;

        BoxCollider axeCollider = axe.GetComponent<BoxCollider>();

        axeCollider.enabled = false;
    }
}
