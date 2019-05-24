using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{

    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;

    [SerializeField] private float runSpeed, sprintSpeed;
    [SerializeField] private float runBuildUpSpeed;
    [SerializeField] private KeyCode runKey;

    private float movementSpeed;

    [SerializeField] private float slopeForceRayLenght;
    [SerializeField] private float slopeForce;
    private CharacterController charController;

    public Animator rifleAnim;

    private bool isJumping;
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    void Start()
    {
        /*rifleAnim.GetComponent<Animator>();*/ 
    }


    void Update()
    {
        PlayerMove(); //Check for movement input

        JumpInput(); //Check for jump input
    }

    private void PlayerMove()
    {

        float horizInput = Input.GetAxis(horizontalInputName); //Get horizontal input
        float vertInput = Input.GetAxis(verticalInputName); //Get vertical input

        rifleAnim.SetFloat("Speed", horizInput); //Set the Speed parameter equal to horiz input
        rifleAnim.SetFloat("Direction", vertInput); //Set the direction parameter equal to vert unput

        Vector3 forwardMovement = transform.forward * vertInput; 
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed);

        if ((vertInput != 0 || horizInput != 0) && OnSlope())
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);

        SetMovementSpeed();

        if (charController.isGrounded) //If grounded set grounded bool to true, else to false
            rifleAnim.SetBool("isGrounded", true);
        else
            rifleAnim.SetBool("isGrounded", false);

    }

    private void SetMovementSpeed()
    {
        if (Input.GetKey(runKey))
        {
            rifleAnim.SetBool("IsSprinting", true);
            movementSpeed = Mathf.Lerp(movementSpeed, sprintSpeed, Time.deltaTime * runBuildUpSpeed); //Lerp increase speed when pressing sprint key
        }
        else
        {
            rifleAnim.SetBool("IsSprinting", false);
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildUpSpeed); //Lerp Decrease speed when releasing sprint key
        }
    }

    private bool OnSlope() //This function sends a raycast below the player to check if he is on a slope 
    {
        if (isJumping) 
            return false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLenght))
            if (hit.normal != Vector3.up)
                return true;
        return false;

    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine("JumpEvent"); //Start coroutine which allows us to jump
        }
    }

    private IEnumerator JumpEvent() //This function allows the player to jump
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

    public void IncreaseSpeed(int amount) //This function increases player's speed if he upgrades it
    {
        runSpeed += amount;

        sprintSpeed += amount;
    }
}
