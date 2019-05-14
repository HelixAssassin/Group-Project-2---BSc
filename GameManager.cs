using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    internal static int amountkilled;

    // This controls the player's health bar
    public Slider playerHealth;
    // Thus controls the score counter
    public Text score;
    // This controls the numbered text of the player's health bar
    public Text playerHealthTxt;
    // This controls the time counter
    public Text timeTxt;
    public bool won;
    public GameObject winPanel;
    public GameObject losePanel;

    // Use this for initialization
	void Start () 
    {
		winPanel.SetActive(false);
        losePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (Time.timeSinceLevelLoad > 300)
        {
            won = true;
        }
        if (won == true)
        {
            winPanel.SetActive(true);
        }
	}
}
