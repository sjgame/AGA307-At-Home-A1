using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colour { red, green, blue }

public class SignScript : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    public GameObject floatingText2;
    public float rayLength = 3f;
    public GameObject sphere;

    public Colour colour;
    // Start is called before the first frame update
    void Start()
    {
        floatingTextPrefab.SetActive(false);
        floatingText2.SetActive(false);
    }

    
    
    private void Update()
    {
        //Gets the position of our raycast hit.
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;
        
        
        //If the player looks at object, and presses 1, 2, or 3 change the colour of the ball
        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            switch (colour)
            {
                case Colour.red:
                    sphere.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case Colour.green:
                    sphere.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case Colour.blue:
                    sphere.GetComponent<Renderer>().material.color = Color.blue;
                    break;
            }
            //print(hit.collider.name);
            if (hit.collider.CompareTag("Sphere"))

            {
                //Using 1, 2, 3 we can change the colour of our text.
                floatingText2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    colour = Colour.red;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    colour = Colour.green;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    colour = Colour.blue;
                }


            }
            if (hit.collider.CompareTag("Sign"))
            {
                Debug.Log("Hit");
                //ShowText();
                //When we are looking at the door display UI to tell the player what to do.
                floatingTextPrefab.SetActive(true);
            }
        }
        else
        {
            //When we look away from the door, turn off the text.
            floatingTextPrefab.SetActive(false);
            floatingText2.SetActive(false);
        }
    }
}
