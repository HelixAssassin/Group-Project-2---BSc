using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    
    // Each of these lines control a different part of the UI.
    public Health healthScript;
    public Text healthTxt;
    public Slider healthBar;
    public Text scoreNum;
    public Text timeNum;
    static int score;
    public GameObject losePanel;

    void Start()
    {
        // This section of the script imports to the GameManager and allows the UI to function effectively.
        healthScript = GetComponent<Health>();
        GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        healthBar = manager.playerHealth;
        healthTxt = manager.playerHealthTxt;
        scoreNum = manager.score;
        timeNum = manager.timeTxt;

        healthBar.maxValue = healthScript.getMaxHealth();
        healthBar.value = healthScript.getHealth();
        healthTxt.text = "Health: " + healthScript.getHealth();
        StartCoroutine("updateUI");
    }

    // This has been declared as static which means that it doesn't need an object to function.
    public static void updateScore(int amount)
    {
        score += amount;
    }
    //Update is called once per frame
    void Update()
    {
        {
            healthBar.maxValue = healthScript.getMaxHealth();
            healthBar.value = healthScript.getHealth();
            healthTxt.text = "Health:" + healthScript.getHealth();
        }
    }
        IEnumerator updateUI()
        {
            healthBar.value = healthScript.getHealth();
            healthTxt.text = "Health: " + healthScript.getHealth();
            timeNum.text = "" + (int)Time.time;
            scoreNum.text = score + "";

            if (healthScript.IsDead)
            {
                losePanel.SetActive(true);
                Time.timeScale = 0;
            }

            yield return new WaitForSeconds(0.5f);
            StartCoroutine("updateUI");
        }
    
}