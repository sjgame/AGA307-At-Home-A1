using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportLocation;
    public bool playerTeleport = true;
    public GameObject player;
    
    //Player can teleport when the game starts
    //private void Start()
    //{
    //    //playerTeleport = true;
    //}
    private void OnTriggerEnter(Collider other)
    {
        
        
        {
            //print("can teleport");
            //teleportLocation.GetComponent<Teleporter>().playerTeleport = false; 
            //Vector3 finalPos = new Vector3(teleportLocation.transform.position.x, 1, teleportLocation.transform.position.z);
            other.transform.position = teleportLocation.position;
        }
            

       
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.CompareTag("Player") && !playerTeleport)
    //    {
    //        playerTeleport = true;
    //    }
    //}

}
