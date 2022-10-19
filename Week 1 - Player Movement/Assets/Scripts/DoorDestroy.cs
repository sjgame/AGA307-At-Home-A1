using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DoorDestroy : MonoBehaviour
{
    public GameObject target1; 
    public GameObject target2; 
    public GameObject door1;
    public GameObject door2;
    //List<GameObject> listOfTargets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //listOfTargets.AddRange(GameObject.FindGameObjectsWithTag("Target"));
        //print(listOfTargets.Count);
    }
    
    /// <summary>
    /// If the 2 targets are destroyed. Destroy both doors so the player can continue.
    /// </summary>
    void Update()
    {
        if (!target1 && !target2)
        {
            Destroy(door1);
            Destroy(door2);
        }
    }

    //public void TargetDestroyed(GameObject target)
    //{
    //    if (listOfTargets.Contains(target))
    //    {
    //        listOfTargets.Remove(target);

    //    }
    //    else
    //    {
    //        print(listOfTargets.Count);
    //    }
        
    //}

    

    //public void OpenDoor()
    //{
    //    if (listOfTargets.Count <= 0)
    //    {
    //       Destroy(door1);  
    //    }
    //    else 
    //    {
    //        print(listOfTargets.Count); 
    //    }
    //}


    // Update is called once per frame


    //public bool AreTargtsDestroyed()
    //{
    //    if(listOfTargets.Count <= 0)
    //    {
    //        return true;

    //    }
    //    else
    //    {
    //        return false;
    //    }


    //}

}
