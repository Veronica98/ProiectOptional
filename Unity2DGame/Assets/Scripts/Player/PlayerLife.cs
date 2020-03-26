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
        EnemyController enemy = collision.collider.GetComponentInParent<EnemyController>();


        if (enemy != null)
        {
            Hurt();
        }

    }

    private void Hurt()
    {

        if (currentLife > 0)
        {
            currentLife -= 10;
            healthBar.SetHealth(currentLife);

            if (currentLife <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
