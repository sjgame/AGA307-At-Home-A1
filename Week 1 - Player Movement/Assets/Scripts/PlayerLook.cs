using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        //Remove cursor during play
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Get mouse movement, set the sensitivity and move in real time.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate on the Y axis to look up and down (- so rotation doesn't flip)
        xRotation -= mouseY;
        //Lock the rotation to a set degree
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Quanternion is responsible for rotation in Unity. Euler tracks the xRotation.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Move the player body based on the X axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
