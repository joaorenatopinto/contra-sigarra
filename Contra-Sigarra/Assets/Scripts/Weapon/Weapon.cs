using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject grenadePrefab;
    

    // Update is called once per frame
    void Update()
    {

        rotateFirePoint();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Throw();
        }
    }


    void rotateFirePoint()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }

    void Throw() {
        
        Instantiate(grenadePrefab, firePoint.position, firePoint.rotation);

    }
}
