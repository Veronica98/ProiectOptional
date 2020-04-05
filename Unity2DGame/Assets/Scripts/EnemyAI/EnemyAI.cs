using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    public Transform EnemyParrotGFX;

    [SerializeField] private float maxHealth;
    private float currentHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int killPoints = 20;
    [SerializeField] private float damage = 20;
    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindWithTag("Score").GetComponent<Score>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        target = GameObject.FindWithTag("Player").transform;


    }

    void UpdatePath()
    {
        if(seeker.IsDone()) 
           seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachEndOfPath = true;
            return;

        }
        else
        {
            reachEndOfPath = false;

        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance<nextWaypointDistance)
        {
            currentWaypoint++;
        }
        if(force.x >= 0.01f) //velocity that the enemy would like to travel in the current path
        {
            EnemyParrotGFX.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (force.x <= -0.01f) //in this case we are moving to the left
        {
            EnemyParrotGFX.localScale = new Vector3(-1f, 1f, 1f); //we flip the bird
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        score.setScore(killPoints);
        Destroy(gameObject);
    }

    public float getDamage()
    {
        return damage;
    }
}
