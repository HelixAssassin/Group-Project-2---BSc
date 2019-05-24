using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLookAt : MonoBehaviour
{
    [SerializeField] Transform playerPosition;

    private void Start()
    {
        playerPosition = GameObject.Find("Test Player").transform;
    }


    void Update ()
    {
        transform.LookAt(playerPosition.transform.position);
	}
}
