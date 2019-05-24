using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkyBox : MonoBehaviour {

    [SerializeField] private float skyBoxRotationSpeed;

	void Update ()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyBoxRotationSpeed); 

    }
}
