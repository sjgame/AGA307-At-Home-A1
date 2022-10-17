using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool collided;
    public float damage = 1f;

    public GameObject target;

    private Vector3 destination;
    public float distance = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        //If the projectile collides with anything other then the projectile or player it will be destroyed
        
        if (collision.gameObject.tag != "Projectile" &&  collision.gameObject.tag !="Player" && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }




        Target target = collision.transform.GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }

}
