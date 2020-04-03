using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxHealth;

    private int facingDirection;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask whatIsGround;

    private bool groundDetected;
    private bool wallDetected;

    private Rigidbody2D aliveRb;
    private GameObject alive;

    private Vector2 movement;

    public float currentHealth;
    public int killPoints = 15;

    [SerializeField] private float damage = 10;

    [SerializeField] private HealthBar healthBar;


    private void Start()
    {
        currentHealth = maxHealth;
        alive = transform.Find("Alive").gameObject;
        aliveRb = alive.GetComponent<Rigidbody2D>();
        facingDirection = 1;
        healthBar.SetMaxHealth(maxHealth);

    }

    private void Update()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);

        if (!groundDetected || wallDetected)
        {
            Flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, aliveRb.velocity.y);
            aliveRb.velocity = movement;
        }
    }





    //knockback state


    private void Flip()
    {
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f);
        wallCheck.transform.Rotate(0.0f, 180.0f, 0.0f);
    }


    
    /*
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }
      */  

    
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
        Score.score += killPoints;
        Destroy(gameObject);
    }


    public float getDamage()
    {
        return damage;
    }

}
