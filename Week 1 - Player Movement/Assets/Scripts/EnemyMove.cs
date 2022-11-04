using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : GameBehaviour
{
    float moveDistance = 100f;

    Transform startPos;
    Transform endPos;
    Transform moveToPos;
    public float speed = 20.0f;
    public Transform target;

    public float minDist = 1f;

    public float mySpeed;

    int patrolPoint = 0;
    bool reverse = false;

    public PatrolType myPatrol;
    public EnemyType myType;

    void Start()
    {
        //Setup();
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
            else
            {
                StartCoroutine(Move());
                SetupAI();
            }
        }
        void SetupAI()
        {
            startPos = Instantiate(new GameObject(), transform.position, transform.rotation).transform;
            endPos = _EM.GetRandomSpawnPoint();
            moveToPos = endPos;
        }
        IEnumerator Move()
        {
            switch (myPatrol)
            {
                case PatrolType.Linear:

                    moveToPos = endPos;
                    patrolPoint = patrolPoint != _EM.spawnPoints.Length ? patrolPoint + 1 : 0;

                    //if (patrolPoint != _EM.spawnPoints.Length)
                    //{
                    //    patrolPoint = patrolPoint + 1;
                    //}
                    //else
                    //{
                    //    patrolPoint = 0;
                    //}
                    break;
                case PatrolType.Random:
                    moveToPos = _EM.GetRandomSpawnPoint();
                    break;
                case PatrolType.Loop:
                    moveToPos = reverse ? startPos : endPos;
                    reverse = !reverse;
                    break;
            }
            transform.LookAt(moveToPos);
            
            while (Vector3.Distance(transform.position, moveToPos.position) > 0.3f)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveToPos.position, Time.deltaTime
                    * mySpeed);
                yield return null;
            }
            yield return new WaitForSeconds(1);
            StartCoroutine(Move());
        }
    }

    void Update()
    {
        if (target == null)
            return;
        // face the target
        transform.LookAt(target);
        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, target.position);
        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if (distance > minDist)
            transform.position += transform.forward * speed * Time.deltaTime;
    }
    // Set the target of the chaser
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}


