using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool collided;
    public float damage = 1f;

    public GameObject target;
    public GameObject prefab;
   

    private Vector3 destination;
    public float distance = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        //If the projectile collides with anything other then the projectile or player it will be destroyed
        if (collision.gameObject.tag != "Projectile" &&  collision.gameObject.tag !="Player" && !collided)
        {
            //Instantiates the projectiles prefab, position and rotation.
            GameObject blue = Instantiate(prefab, transform.position, transform.rotation);
            Destroy(blue, 2f);
            
            //When the projectile collides with anything other then another projectile or payer, it will be destroyd.
            collided = true;
            Destroy(gameObject);
        }

        //If our projectile collides with a target, that target will take damage.
        Target target = collision.transform.GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }

}
