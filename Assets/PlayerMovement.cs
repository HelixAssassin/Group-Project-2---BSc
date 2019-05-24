using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    private CharacterController charController;

    //This part of the code allows the player to move in different directions and also sets the jump speed, move speed and gravity
    [SerializeField] float jumpSpeed = 20.0f;
    [SerializeField] float gravity = 1.0f;
    float yVelocity = 0.0f;

    private float attackSpeed;

    protected bool sprinting;

    private bool regenerateStamina = false;

    [SerializeField] private float sprintSpeed;

    [SerializeField] private float normalSpeed;

    private float stamina = 100;

    private float fillAmount = 1f;

    [SerializeField] private Image StaminaBar;

    float moveSpeed;
    public float h;
    public float v;
    [SerializeField] protected Animator anim;

	// Use this for initialization
	void Start () {
        charController = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();

        moveSpeed = normalSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);

        fillAmount = stamina / 100;

        if (stamina > 50)
        {
            anim.SetFloat("AttackSpeed", attackSpeed + fillAmount);
        }
        else
        {
            anim.SetFloat("AttackSpeed", attackSpeed + (fillAmount + 0.25f));
        }

        StaminaBar.fillAmount = Mathf.Lerp(StaminaBar.fillAmount, fillAmount, Time.deltaTime *5f);

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            moveSpeed = sprintSpeed;

            stamina -= Time.deltaTime * 8;

            regenerateStamina = false;

            anim.SetBool("Sprinting", true);
        }
        else
        {
            moveSpeed = normalSpeed;

            StartCoroutine("StartStaminaRegenaration");

            anim.SetBool("Sprinting", false);
        }

        if (regenerateStamina == true && stamina < 100)
        {
            stamina += Time.deltaTime * 10;
        }

        // This is the movespeed variable for the player and this allows the object to move.
        Vector3 direction = new Vector3 (h, 0, v);
        Vector3 velocity = direction * moveSpeed;

        if (charController.isGrounded) {
            if (Input.GetButtonDown("Jump"))
            {
                //anim.SetTrigger("Jump");
                yVelocity = jumpSpeed;
            }

        } else{
            yVelocity -= gravity;
        }
        velocity.y = yVelocity;

        velocity = transform.TransformDirection(velocity);

        charController.Move(velocity*Time.deltaTime);	
	}

    private void OnCollisionEnter(Collision collisionInfo)
    {
        print("hit");
        if (collisionInfo.gameObject.tag == "Elevator")
        {
            //transform.parent = collisionInfo.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        transform.parent = null;
    }

    private IEnumerator StartStaminaRegenaration()
    {
        yield return new WaitForSeconds(2);

        regenerateStamina = true;
    }

    public void AttackBurnStamina(float amount, float speed)
    {
        stamina -= amount;

        attackSpeed = speed;

        if (stamina <= 0)
        {
            stamina = 0;
        }
    }
}