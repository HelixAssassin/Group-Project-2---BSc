using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float currentHealth;

    [SerializeField] private Image playerHealthBar;
    

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        playerHealthBar.fillAmount -= amount / 100;
    }

    public void Damage(int damageValue)
    {
        currentHealth -= damageValue;

        if (currentHealth <= 0)
        {
            if (gameObject.tag != "Player") ;
        }
        else
        {
            Destroy(gameObject);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            gameObject.SetActive(false);
        }
    }
 }