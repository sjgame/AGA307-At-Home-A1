using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestroy : MonoBehaviour
{

    public GameObject door1;
    public GameObject door2;
    List<GameObject> listOfTargets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        listOfTargets.AddRange(GameObject.FindGameObjectsWithTag("Target"));
        print(listOfTargets.Count);
    }

    public void TargetDestroyed(GameObject target)
    {
        if (listOfTargets.Contains(target))
        {
            listOfTargets.Remove(target);
        }
        print(listOfTargets.Count);
    }


    // Update is called once per frame
   

    public bool AreTargtsDestroyed()
    {
        if(listOfTargets.Count <= 0)
        {
            return true;
            
        }
        else
        {
            return false;
        }

            
    }
    void Update()
    {
        //if (true)
        //{
        //    Destroy(door1);
        //    Destroy(door2);
        //}
        //if (false)
        //{
        //    print(listOfTargets.Count);
        //}
        AreTargtsDestroyed();
        {
            if (true)
            {
                Destroy(door1);
            }
        }
       
    }


}
