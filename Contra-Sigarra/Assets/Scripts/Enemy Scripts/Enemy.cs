using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;
    public HealthBar healthbar;

    public void TakeDamage(int damage) 
    {
        health -= damage;
        healthbar.setHealth(health);
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }
    
    IEnumerator Die()
    {
        GameObject deathAnim = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        yield return 0;
        Destroy(deathAnim);
    }
}
