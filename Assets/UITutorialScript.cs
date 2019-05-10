using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITutorialScript : MonoBehaviour
{
    private bool tutorialDisplayed = false;


    [SerializeField] private Image cubeTutorial;
    private bool cubeTutorialDisplayed = false;
    

    private void Update()
    {
        ButtonInputTutorial();
    }

    private void ButtonInputTutorial()
    {
        if(Input.GetKey(KeyCode.T))
        {
            DisableTutorials();
        }
    }

    public void DisableTutorials()
    {
        cubeTutorial.gameObject.SetActive(false);
    }

    public void DisplayCubeTutorial()
    {
        if (tutorialDisplayed == false)
        {
            if (cubeTutorialDisplayed == false)
            {
                cubeTutorial.gameObject.SetActive(true);
                cubeTutorialDisplayed = true;
                tutorialDisplayed = true;
            }
        }
    }
}
