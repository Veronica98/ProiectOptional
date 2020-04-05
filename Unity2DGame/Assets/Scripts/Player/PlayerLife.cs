using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float startingLife; // Max health-ul playerului
    private float currentLife; 
    [SerializeField] private HealthBar healthBar; // Componenta UI health bar
    [SerializeField] private Text healthNumberText; // Componenta Health ui text
    private GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        startingLife = player.GetComponent<PlayerStats>().getMaxHealth(); // Accesam viata maxima a player-ului din scriptul PlayerStats
        currentLife = startingLife; // Egalam viata curenta cu cea maxima pentru inceput
        healthBar.SetMaxHealth(startingLife); // Setam bara de UI Health sa fie plina (cat viata maxima)
        healthNumberText.text = currentLife.ToString() + " / " + startingLife.ToString(); // Afisam in bara si viata in text pentru o claritate mai buna
    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {
        EnemyController enemyTiger = collision.collider.GetComponentInParent<EnemyController>(); // Coliziune cu tigru
        EnemyAI enemyParrot = collision.collider.GetComponent<EnemyAI>(); // Coliziune cu papagal

        if (enemyTiger != null)
        {
            Hurt(enemyTiger.getDamage()); // Primim damage in functie de cat damage are tigrul
        }

        if (enemyParrot != null)
        {
            Hurt(enemyParrot.getDamage()); // Primi damage in functie de cat damage are papagalul
        }

    }

    private void Hurt(float damage) // Functia prin care primim damage
    {

        if (currentLife > 0) // Daca player-ul inca este in viata
        {
            currentLife -= damage; // Scadem damage-ul primit din  viata
            healthBar.SetHealth(currentLife); // Updatam bara de health
            healthNumberText.text = currentLife.ToString() + " / " + startingLife.ToString(); // Updatam si textul de health


            if (currentLife <= 0) // Daca player-ul a murit
            {
                Destroy(gameObject);
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }


    public void changeMaxHealth(float maxHealth) // Functie folosita atunci cand iei un item care mareste maxHealth
    {
        startingLife = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentLife);
        healthNumberText.text = currentLife.ToString() + " / " + startingLife.ToString();

    }
}
