using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float speed = 0.4f;
    public float radius = 5f;
    public float force = 700f;
    public Vector3 launchOffset;
    public Rigidbody2D rigidBody2D;
   // public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", delay);
        var direction = transform.right + Vector3.up;
        rigidBody2D.AddForce(direction * speed, ForceMode2D.Impulse);
        transform.Translate(launchOffset);
    }

    void Explode(){
        Debug.Log("boom!");

        // Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null) {
                rb.AddForce(transform.position * force, ForceMode2D.Impulse);
            }
        }
        Destroy(gameObject);
    }
}
