using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] private Image axeFill;

    [SerializeField] private Image swordFill;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update ()
    {
        ButtonInput();
	}

    private void ButtonInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EnableAxe();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EnableSword();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EnableHands();
        }
    }

    private void EnableAxe()
    {
        axeFill.gameObject.SetActive(true);
        swordFill.gameObject.SetActive(false);
    }

    private void EnableSword()
    {
        axeFill.gameObject.SetActive(false);
        swordFill.gameObject.SetActive(true);
    }

    private void EnableHands()
    {
        axeFill.gameObject.SetActive(false);
        swordFill.gameObject.SetActive(false);
    }
}
