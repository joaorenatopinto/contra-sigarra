using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
     public Rigidbody2D rb;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 moveDirection = (target.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3);
    }

}
