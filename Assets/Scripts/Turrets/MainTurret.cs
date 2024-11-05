using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTurret : Turret
{
    // Movement Settings
    public Transform turretHead;

    private Vector2 mouseScreenPosition;
    private Vector2 direction;

    [Header("Shooting Settings")]
    public Transform firePoint;
    public Transform bullets;

    public float fireRate = 0.25f;
    private float nextFire = 0f;

    public GameObject bulletPrefab;
    public float bulletForce = 10f;

    // Update is called once per frame
    void Update()
    {
        mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mouseScreenPosition - (Vector2) turretHead.transform.position).normalized;

        turretHead.transform.right = direction;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            shootBullet();
        }
    }

    void shootBullet()
    {
        nextFire = Time.time + fireRate;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, bullets);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
