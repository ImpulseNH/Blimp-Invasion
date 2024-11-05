using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Turret : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth;
    private int currentHealth;

    public HealthBar healthBar;

    [Header("Range")]
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
