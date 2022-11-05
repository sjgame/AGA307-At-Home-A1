using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDungeon : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private DungeonController raycastedObj;

    [SerializeField] private KeyCode enterDungeon = KeyCode.E;
    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "InteractableObject";

    public Transform teleportPlayer;
    public GameObject thePlayer;
    public Camera cam;

    public GameObject FloatingTextPrefab;
    public GameObject doorText;

    private void Start()
    {   //Initially sets the door text as false so it is not displayed.
        doorText.SetActive(false);
    }

    void FixedUpdate()
    {   
        //For our raycast variabe we get the posiion of our raycast based on our camera and set parameters. 
        //Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        
        RaycastHit hit;
        
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            //print(hit.collider.name);
            
            if(hit.collider.CompareTag("Load"))
            {
                //ShowText();
                //When we are looking at the door display UI to tell the player what to do.
                doorText.SetActive(true);

                //print("hit");

                //If we press E on the door trigger the player will be teleported to a set location
                if (Input.GetKeyDown(KeyCode.G))
                {
                    print("hit");
                    Continue();
                }

            }
            else
            {   //When we look away from the door collider disable the text. 
                doorText.SetActive(false);
            }
           
        }
       
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Load")) 
    //    {
    //        print("collided");
    //        Continue();
    //    }
    //}
    
    //Function teleports our player to a set location.
    void Continue()
    {
        thePlayer.transform.position = teleportPlayer.position;
    }
    //void ShowText()
    //{
    //    Instantiate(FloatingTextPrefab, door.transform.position, Quaternion.identity, transform);
    //    FloatingTextPrefab.transform.LookAt(2 * transform.position - Camera.main.transform.position);
    //}




}
