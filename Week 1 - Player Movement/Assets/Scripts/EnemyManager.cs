using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VariedSize { Small, Medium, Large }
public enum MyType { One, Two, Archer }

public enum EnemyType
{
    OneHand, TwoHand, Archer
}

public enum PatrolType
{
    Linear, Random, Loop 
}

public class EnemyManager : Singleton<EnemyManager>
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
        if(Input.GetKeyDown(KeyCode.I))
        {
            SpawnEnemy();   
        }
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
    void SpawnEnemy()
    {
        //Create new int using the Random.Range function and declare the range between two points.
        // enemyTypes.Length declares the max value of enemies that can be randomly assigned.
        int enemyNumber = Random.Range(0, enemyTypes.Length);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        GameObject enemy = Instantiate(enemyTypes[enemyNumber], spawnPoints[spawnPoint].position,
            spawnPoints[spawnPoint].rotation, transform);
        //Adding transform at the end spawns the enemies within our gameManager gameObject.

        //Adds enemies to our list.
        enemies.Add(enemy);
        //Shows enemy count in inspector.
        print(enemies.Count);
        //_UI.UpdateEnemyCount(enemies.Count);
    }
    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
