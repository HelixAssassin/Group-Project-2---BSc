using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorialObject : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("PlayerCanvas").GetComponent<UITutorialScript>().DisplayCubeTutorial();

            Debug.Log("Tutorial");
        }
    }
}
