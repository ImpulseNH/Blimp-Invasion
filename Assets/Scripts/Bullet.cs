using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage = 50;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        collision.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
    }
}
