using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLookAt : MonoBehaviour
{
    [SerializeField] Camera playerCamera;


	void Update ()
    {
        transform.LookAt(playerCamera.transform.position);
	}
}
