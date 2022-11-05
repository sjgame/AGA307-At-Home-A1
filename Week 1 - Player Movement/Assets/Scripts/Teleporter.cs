using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject teleportLocation;
    public bool playerTeleport = true;
    
    //Player can teleport when the game starts
    private void Start()
    {
        playerTeleport = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        print("trigger");
        if(other.CompareTag("Player") && playerTeleport)
        {
            print("collided");
            teleportLocation.GetComponent<Teleporter>().playerTeleport = true;
            Vector3 finalPos = new Vector3(teleportLocation.transform.position.x, 1, teleportLocation.transform.position.z);
            other.transform.position = finalPos;
        }
            

       
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && !playerTeleport)
        {
            playerTeleport = true;
        }
    }

}
