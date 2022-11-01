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


    void FixedUpdate()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if(Physics.Raycast(ray, out hit, rayLength))
        {
            //print(hit.collider.name);
            
            if(hit.collider.CompareTag("Load"))
            {
                //print("hit");
               
                if(Input.GetKeyDown(KeyCode.E))
                {
                    print("hit");
                    thePlayer.transform.position = teleportPlayer.position;
                }

            }
        }

       
    }




}