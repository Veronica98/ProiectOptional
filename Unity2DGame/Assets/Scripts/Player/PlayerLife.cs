using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float startingLife;
    private float currentLife;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Text healthNumberText;

    void Start()
    {
        currentLife = startingLife;
        healthBar.SetMaxHealth(startingLife);
        healthNumberText.text = currentLife.ToString() + " / " + startingLife.ToString(); // Health ui text
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
            healthNumberText.text = currentLife.ToString() + " / " + startingLife.ToString();


            if (currentLife <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public float getCurrentLife()
    {
        return startingLife;
    }


    public void changeMaxHealth(float maxHealth)
    {
        startingLife = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentLife);
        healthNumberText.text = currentLife.ToString() + " / " + startingLife.ToString();

    }
}
