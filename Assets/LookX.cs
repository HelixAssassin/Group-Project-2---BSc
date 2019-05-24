using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour {

    [SerializeField] float sensitivity = 5.0f;
	
	// Update is called once per frame
	void Update ()
    {
        MoveX();
	}

    private void MoveX()
    {
        if (Time.timeScale != 0)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }
    }
}
