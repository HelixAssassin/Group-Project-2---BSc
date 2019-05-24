using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;

    [SerializeField] private TextMeshProUGUI deathMenuText;

    private int kills;

    public void Start()
    {
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        deathMenu.SetActive(true);

        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(kills == 30)
        {
            deathMenuText.text = "Congratulations, you won!";
        }
        else
        {
            deathMenuText.text = "You have died!";
        }
    }


    public void Restart()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    public void AddKill()
    {
        kills += 1;

        if (kills == 30)
        {
            EndGame();
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
