using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonController : MonoBehaviour
{
    private bool doorOpen = false;

    public Transform teleportPlayer;
    public GameObject thePlayer;
   
    // Start is called before the first frame update
    public void NewScene()
    {
        //string scene = SceneManager.GetSceneByName("Dungeon").name;
        if(!doorOpen)
        {
            thePlayer.transform.position = teleportPlayer.position;
        }
    }
}
