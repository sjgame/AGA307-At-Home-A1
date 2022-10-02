using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform playerRoot;

    //Movement variables
    public float defaultSpeed;
    public float sprintSpeed;
    public float currentSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float enhancedJump = 4f;

    public float speedSlowed;

    public KeyCode sprintKeyCode;
    //public KeyCode crouchKeyCode;
    public KeyCode slowKeyCode;

    //Sprint fov variables
    public Camera playerCam;
    public float defaultFOV;
    public float sprintFOV;
    public float fovChangeSpeed;

    //public float playerWidth;
    //public float currentPlayerHeight;
    //public float defaultPlayerHeight;
    //public float crouchPlayerHeight;
    //public float crouchSpeed;
    //public bool crouching;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public GameObject scroll;

    private void Start()
    {
        //Starts game paused.
        Time.timeScale = 0f;
    }


    void Update()
    {
        
        //Removes popup and starts the game.
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1f;
            Destroy(scroll);
        }

        //Checks to see if player is touching ground.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        /*Allow player to run faster by pressing down specified keycode.
          Also changes the FOV to create the illusion of running faster.*/
        if (Input.GetKey(sprintKeyCode))
        {
            currentSpeed = sprintSpeed;
            playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, sprintFOV, fovChangeSpeed * Time.deltaTime);
        }
        else
        {
            currentSpeed = defaultSpeed;
            playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, defaultFOV, fovChangeSpeed * Time.deltaTime);
        }

        if (Input.GetKey(slowKeyCode))
        {
            currentSpeed = speedSlowed;
            jumpHeight = enhancedJump;
        }
        else
        {
            jumpHeight = 3f;
        }


        //Get WASD movement and creates variable.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Create a move variable that transforms the position and direction based on the input.
        Vector3 move = transform.right * x + transform.forward * z;

        //Tell the CharacterController to move based on the input, direction, speed and time.
        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
