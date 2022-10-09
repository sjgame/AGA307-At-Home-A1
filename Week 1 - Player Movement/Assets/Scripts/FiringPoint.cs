using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    public GameObject target;
    public GameObject projectile;
    public Transform firePoint;

    public Camera cam;

    private Vector3 destination;
    public float distance = 100f;
    public float damage = 1f;
    public float projectileSpeed = 30f;

    //public GameObject projectilePrefab;
    //public float projectileSpeed = 1000f;

    public LineRenderer laser;
    public GameObject projectilePrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {


        ////Create a reference to hold our instantiated object.
        //GameObject projectileInstance;
        ////Instantiate our projectile prefab at this objects position and rotation.
        //projectileInstance = Instantiate(projectilePrefab, transform.position, transform.rotation);
        ////Get the rigidbody attached to the projectile.
        //projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);

        
        
        //This is a method that uses a combination of Raycasts and Instantiates to fire a projectile.
        
        //Sets initial point of the raycast to the player camera, or where the player is looking.
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }

        else
        {
            destination = ray.GetPoint(1000);
        }

       


        InstantiateProjectile(firePoint);
        //Creates the projectile at fire point positions and fires it in the direction set by the raycast.
        void InstantiateProjectile(Transform firePoint)
        {
            var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
            projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
        }
       
        
        
        
        
        //Target target = hit.transform.GetComponent<Target>();
        //if (target != null)
        //{
        //    target.TakeDamage(damage);
        //}



        //InClass Method of raycasts (Testing)

        //Ray ray = new Ray(transform.position, transform.forward);
        //RaycastHit hit; // A RaycastHit variable that stores information on what is hit.

        ////Forward direction Vector based on gameObject
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);


        //////Create a reference to hold our instantiated object.
        ////GameObject projectileInstance;
        //////Instantiate our projectile prefab at this objects position and rotation.
        ////projectileInstance = Instantiate(projectilePrefab, transform.position, transform.rotation);
        //////Get the rigidbody attached to the projectile.
        ////projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);


        //if (Physics.Raycast(transform.position, fwd, out hit, distance))
        //{
        //    //Prints name of specific collider hit.
        //    print(hit.collider.name);

        //    laser.SetPosition(0, transform.position);
        //    laser.SetPosition(1, hit.point);

        //    Target target = hit.transform.GetComponent<Target>();
        //    if (target != null)
        //    {
        //        target.TakeDamage(damage);
        //    }



        //    //If the hit collides with the tag "Target"
        //    //if(hit.collider.CompareTag("Target"))
        //    //{
        //    //    Destroy(gameObject);
        //    //}
        //}
    }
}
