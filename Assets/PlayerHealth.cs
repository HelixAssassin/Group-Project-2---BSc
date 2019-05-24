using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float currentHealth;

    [SerializeField] private Image playerHealthBar;

    [SerializeField] private TextMeshProUGUI healthText;

    private float fillAmount = 1;

    private void Update()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        fillAmount = currentHealth / 100;
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

    private void UpdateHealthBar()
    {
        playerHealthBar.fillAmount = Mathf.Lerp(playerHealthBar.fillAmount, fillAmount, Time.deltaTime * 4f);

        healthText.text = "" + currentHealth;
    }
 }