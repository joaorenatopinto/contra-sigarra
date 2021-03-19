using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    public float dropDelay = 1f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void DropTrigger()
    {
        Debug.Log("Fall");
        Invoke("DropPlatform", dropDelay);
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 2f);
    }
}
