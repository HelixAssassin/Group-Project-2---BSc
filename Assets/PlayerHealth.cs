using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float currentHealth;

    [SerializeField] private Image playerHealthBar;

    public void PlayerTakeDamage(float amount)
    {
        currentHealth -= amount;

        playerHealthBar.fillAmount -= amount / 100;
    }
}
