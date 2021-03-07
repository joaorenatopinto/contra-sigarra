using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float speed = 0.4f;
    public float radius = 5f;
    public float force = 300f;
    public Vector3 launchOffset;
    public Rigidbody2D rigidBody2D;
    public GameObject explosionEffect;
    public int damage = 50;
    public LayerMask layerToHit;    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", delay);
        var direction = transform.right + Vector3.up;
        rigidBody2D.AddForce(direction * speed, ForceMode2D.Impulse);
        transform.Translate(launchOffset);
    }

    void Explode(){

        Destroy(Instantiate(explosionEffect, transform.position, transform.rotation),0.5f);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layerToHit);

        foreach (Collider2D nearbyObject in colliders)
        {
            
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null) {
                Vector2 direction = nearbyObject.transform.position - transform.position;
                rb.AddForce(direction * force);
                Enemy enemy = nearbyObject.GetComponent<Enemy>();
                if(enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
