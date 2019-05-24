using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageWeapons : MonoBehaviour
{
    [SerializeField] private GameObject axe;

    [SerializeField] private GameObject sword;

    [SerializeField] private Image axeFill;

    [SerializeField] private Image swordFill;

    private bool swordEnabled = true;

    private bool axeEnabled = false;

    private bool changingWeapons = false;

    [SerializeField] private Animator anim;

    private void Update()
    {
        WeaponSwitchInput();
    }

    private void WeaponSwitchInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && axeEnabled == false && changingWeapons == false)
        {
            axeEnabled = true;
            swordEnabled = false;
            changingWeapons = true;

            axeFill.gameObject.SetActive(true);
            swordFill.gameObject.SetActive(false);

            anim.SetBool("ChangingWeapon", true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && swordEnabled == false && changingWeapons == false)
        {
            swordEnabled = true;
            axeEnabled = false;
            changingWeapons = true;

            axeFill.gameObject.SetActive(false);
            swordFill.gameObject.SetActive(true);

            anim.SetBool("ChangingWeapon", true);
        }
    }

    private void ActivateWeapon()
    {
        if(axeEnabled == true)
        {
            axe.SetActive(true);
            sword.SetActive(false);
            anim.SetFloat("AttackSpeed", 0.9f);
        }

        if(swordEnabled == true)
        {
            axe.SetActive(false);
            sword.SetActive(true);
            anim.SetFloat("AttackSpeed", 1f);
        }
    }

    private void WeaponsChanged()
    {
        changingWeapons = false;

        anim.SetBool("ChangingWeapon", false);
    }

    private void AttackStamina()
    {
        if(axeEnabled == true)
        {
            GameObject.Find("Test Player").GetComponent<PlayerMovement>().AttackBurnStamina(20f, 0.2f);
        }
        else
        {
            GameObject.Find("Test Player").GetComponent<    PlayerMovement>().AttackBurnStamina(10f, 0.4f);
        }
    }
}
