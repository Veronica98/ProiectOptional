using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float startingLife;
    private float currentLife;
    [SerializeField] private HealthBar healthBar;

    void Start()
    {
        currentLife = startingLife;
        healthBar.SetMaxHealth(startingLife);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemyTiger = collision.collider.GetComponentInParent<EnemyController>();
        EnemyAI enemyParrot = collision.collider.GetComponent<EnemyAI>();

        if (enemyTiger != null)
        {
            Hurt(enemyTiger.getDamage());
        }

        if (enemyParrot != null)
        {
            Hurt(enemyParrot.getDamage());
        }

    }

    private void Hurt(float damage)
    {

        if (currentLife > 0)
        {
            currentLife -= damage;
            healthBar.SetHealth(currentLife);

            if (currentLife <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
