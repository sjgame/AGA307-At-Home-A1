using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 2f;
    public GameObject FloatingTextPrefab;

    public void TakeDamage (float amount)
    {
        if(FloatingTextPrefab && health > 0)
        {
            ShowFloatingText();
        }
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
        
       
    }

    void ShowFloatingText()
    {
        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
    }
    void Die()
    {
        //Destroy the target after a set period of time. The extra time also allows for the hitmarkers to be displayed properly.
        Destroy(gameObject, 0.6f);
    }
}
