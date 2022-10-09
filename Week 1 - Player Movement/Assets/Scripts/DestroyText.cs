using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    public float DestroyTime = 3f;
    void Start()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
        
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    
}
