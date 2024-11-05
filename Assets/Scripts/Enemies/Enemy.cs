using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed;
    public Transform spawn;
    public Transform destiny;
    private Vector2 destination;

    [Header("Health Settings")]
    [SerializeField] protected int maxHealth;
    protected int currentHealth;
    [SerializeField] protected HealthBar healthBar;

    private Transform target;
    private float targetPosition;
    private Transform firePoint;

    private bool shooting = false;

    [Header("Shooting Settings")]
    public GameObject bombPrefab;

    [Header("Reward Settings")]
    [SerializeField] protected int reward;

    void Awake()
    {
        destination = new Vector2(destiny.position.x, Random.Range(destiny.position.y - 3.5f, destiny.position.y + 3.5f));

        target = GameObject.Find("Main Turret").GetComponent<Transform>();
        firePoint = transform.GetChild(0);
        targetPosition = target.position.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, destination, step);

        if(transform.position.x == destination.x)
        {
            teleportToSpawn();
        }

        if(!shooting && firePoint.position.x >= targetPosition)
        {
            shootBomb();
            shooting = true;
        }
    }

    void teleportToSpawn()
    {
        var newPosition = new Vector2(spawn.position.x, Random.Range(spawn.position.y - 3.5f, spawn.position.y + 3.5f));
        transform.position = newPosition;
        resetShooting();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth < maxHealth)
        {
            healthBar.gameObject.SetActive(true);
        }
        if(currentHealth == 0)
        {
            PlayerStats.addReward(reward);
            Destroy(gameObject);
        }
    }

    void shootBomb()
    {
        Instantiate(bombPrefab, firePoint.position, Quaternion.Euler(0,0,90f));
    }

    public void resetShooting()
    {
        shooting = false;
    }
}