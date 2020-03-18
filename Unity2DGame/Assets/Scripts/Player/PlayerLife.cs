using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float startingLife;
    private float currentLife;
    void Start()
    {
        currentLife = startingLife;
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

            if (currentLife <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
