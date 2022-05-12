using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCoin : MonoBehaviour
{
    public GameObject bullet;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextFire = Time.time + fireRate;
        Fire();
    }
    void Fire()
    {
        bulletPos = transform.position;
        bulletPos += new Vector2(+0.6f, 5f);
        Instantiate(bullet, bulletPos, Quaternion.identity);
    }
}
