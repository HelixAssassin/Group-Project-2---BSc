using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {
    [SerializeField] float sensitivityY;
    public float minimumY = -30f;
    public float maximumY = 30f;
    float rotationY = 0F;

    void Update()
    {
        MoveY();
    }


    private void MoveY()
    {

        if (Time.timeScale != 0)
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }
}

