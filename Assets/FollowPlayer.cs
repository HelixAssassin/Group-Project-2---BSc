using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float cameraHeight = 20.0f;
	
	void Update ()
    {
        Vector3 pos = target.transform.position;
        pos.y += cameraHeight;
        transform.position = pos;
	}
}
