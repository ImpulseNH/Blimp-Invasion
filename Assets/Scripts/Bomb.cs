using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int bombDamage = 100;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Turret")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Turret>().TakeDamage(bombDamage);
        }
    }
}
