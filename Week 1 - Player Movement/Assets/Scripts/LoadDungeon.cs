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
    {
        doorText.SetActive(false);
    }

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
                //ShowText();

                doorText.SetActive(true);

                
                //print("hit");
               
                if(Input.GetKeyDown(KeyCode.E))
                {
                    print("hit");
                    thePlayer.transform.position = teleportPlayer.position;
                }

            }
            else
            {
                doorText.SetActive(false);
            }
           
        }

       
    }
    //void ShowText()
    //{
    //    Instantiate(FloatingTextPrefab, door.transform.position, Quaternion.identity, transform);
    //    FloatingTextPrefab.transform.LookAt(2 * transform.position - Camera.main.transform.position);
    //}




}
