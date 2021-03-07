using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;
    public GameObject powerUpObject;
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

    IEnumerator powerUp()
    {
        GameObject gameObject = Instantiate(powerUpObject, transform.position, Quaternion.identity);
        yield return 0;
    }


    IEnumerator Die()
    {
        GameObject deathAnim = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(deathAnim, 0.5f);
        if (Random.value < 0.1)
        {
            //yield return new WaitForSeconds(0.5f);
            yield return powerUp();
        }
        else
        {
            yield return 0;
        }
    }
}
