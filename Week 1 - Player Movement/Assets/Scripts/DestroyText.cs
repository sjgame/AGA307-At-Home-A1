using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    public float DestroyTime = 3f;
    public Vector3 Offset = new Vector3(0, 2, 0);
    public Vector3 RandomizeIntensity = new Vector3(0.5f, 0, 0);
    void Start()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);

        Destroy(gameObject, DestroyTime);

        
        //Creates offset from the parent object. Placing it above the object.
        transform.localPosition += Offset;
        //Creates random variation in the placement of the damage text.
        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x),
            Random.Range(RandomizeIntensity.y, RandomizeIntensity.x),
            Random.Range(RandomizeIntensity.x, RandomizeIntensity.z));
    }

    // Update is called once per frame
    
}
