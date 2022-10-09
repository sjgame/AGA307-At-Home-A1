using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 2f;
    public GameObject FloatingTextPrefab;

    public void TakeDamage (float amount)
    {
        if(FloatingTextPrefab)
        {
            ShowFloatingText();
        }
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
        
        ShowFloatingText();
    }

    void ShowFloatingText()
    {
        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
