using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour

{
    public GameObject sphere;

    public Vector3 endScale = Vector3.one * 3.0f;

    public float xMin = 1, xMax =3;
    public float yMin = 1, yMax =3;
    public float zMin = 1, zMax =3;

    

    //float scale = 0f;

    //The object we wish to change

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        //change the spheres colour to green
    //    }
    //}
    void Start()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        //float xValue = sphere.transform.localScale.x;
        //float yValue = sphere.transform.localScale.y;
        //float zValue = sphere.transform.localScale.z;
        //float xScale = Mathf.Clamp(xValue, xMin, xMax);
        //float yScale = Mathf.Clamp(yValue, yMin, yMax);
        //float zScale = Mathf.Clamp(zValue, zMin, zMax);

        sphere.transform.localScale += new Vector3(1, 1, 1) * 0.01f;

    }
    //private void Update()
    //{
    //    var sphereScale = sphere.transform.localScale;
    //    var sphereMax = Vector3
    //    if (sphereScale == sphereMax)
    //    {
    //        Destroy(sphere);
    //    }
    //}

    void OnTriggerExit(Collider other)
    {

        sphere.transform.localScale = Vector3.one;

    }
}
