using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float lineOfSight;
    public float speed;
    public float shootingRange;
    public GameObject bullet;
    public GameObject firingPoint;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceToPlayer < lineOfSight && distanceToPlayer > shootingRange) {    
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        } else if (distanceToPlayer <= shootingRange) {
            Instantiate(bullet, firingPoint.transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}
