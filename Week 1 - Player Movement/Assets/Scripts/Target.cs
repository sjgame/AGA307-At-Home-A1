using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 2f;
    public GameObject FloatingTextPrefab;
    public VariedSize variedSize;
    public MyType type; 

    void Start()
    {
        SetUp();
    }

    void SetUp()
    { 
        //Set up a switch function that allocates the size of a particular target. This is set to public so we can manually change their sizes.
        switch(variedSize)
        {
            case VariedSize.Small:
                print ("im small");
                break; 
            case VariedSize.Medium:
                print("im medium");
                break;
            case VariedSize.Large:
                print("im large");
                break;
        }
    }

    public void TakeDamage (float amount)
    {
        if(FloatingTextPrefab && health > 0)
        {
            ShowFloatingText();
        }
        health -= amount;
        if (health <= 0f)
        {
            Die();
            GetComponent<Renderer>().material.color = Color.red;
        }
        
       
    }

    void ShowFloatingText()
    {
        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
    }
    void Die()
    {
        //Destroy the target after a set period of time. The extra time also allows for the hitmarkers to be displayed properly.
        Destroy(gameObject, 0.6f);
    }
}
