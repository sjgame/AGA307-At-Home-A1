using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VariedSize { Small, Medium, Large }
public enum MyType { One, Two, Archer }

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints; //Spawn points of where enemies will spawn.
    public List<GameObject> enemies; //List containing all of the enemies within our scene
    public GameObject[] enemyTypes; //Contains all thr different enemy types
    
    public VariedSize variedSize;
    
    void Start()
    {
        SpawnEnemies();
    }

   
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        //this for loop allows us to set how many enemies will spawn in a loop depending on our set spawn points.


        for (int i = 0; i < spawnPoints.Length; i++)
        {

            GameObject enemy = Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], spawnPoints[i].position,
            spawnPoints[i].rotation, transform);
            enemies.Add(enemy);
        }
    }
}
