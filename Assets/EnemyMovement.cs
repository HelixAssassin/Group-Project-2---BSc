using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Transform playerModel;
    CharacterController controller;

    // This allows the character object to move, jump and be affected by gravity
    [SerializeField] float jumpSpeed = 20.0f;
    [SerializeField] float gravity = 1.0f;
    float yVelocity = 0.0f;

    [SerializeField] float moveSpeed = 5.0f;
    public float h;
    public float v;

    // Use this for initialization
    void Start () {
        // This code segment allows the enemy game object to follow an object that is tagged with player.
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerModel = playerGameObject.transform;
        controller = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);
        Vector3 velocity = direction * moveSpeed;

        Vector3 dircetion = playerModel.position - transform.position;
        controller.Move(dircetion * Time.deltaTime);
		
	}
}
