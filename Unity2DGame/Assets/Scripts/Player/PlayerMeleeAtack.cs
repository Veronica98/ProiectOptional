using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAtack : MonoBehaviour
{

    [SerializeField] private Transform attackPoint; // Locul din care se ataca
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers; // Ce va lovi

    [SerializeField] private float attackDamage;
    private float critChance;
    private float critDamage;



    private void Start()
    {
        critChance = gameObject.GetComponent<PlayerStats>().getCritChance(); // Luam critChance din scriptul playerStats
        critDamage = gameObject.GetComponent<PlayerStats>().getCritDamage();
        attackDamage = gameObject.GetComponent<PlayerStats>().getMeleeDamage();
    }

    void Update()
    {   
        //Atac cu click stanga
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Animatie de atac

        //Detecteaza inamicii in range-ul de atac
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Da damage inamicilor
        foreach(Collider2D enemy in hitEnemies)
        {
            //Cauta scriptul de enemy controller la obiectul pe care l-a lovit
            EnemyController enemyTiger = enemy.GetComponentInParent<EnemyController>();
            EnemyAI enemyParrot = enemy.GetComponent<EnemyAI>();

            //In cazul in care exista un astfel de script atunci se apeleaza functia de take damage de la inamic
            if (enemyTiger != null)
            {
                if (Random.Range(1, 100) <= critChance) // Se verifica daca lovitura este crit
                {
                    enemyTiger.TakeDamage(attackDamage + (attackDamage * (critDamage / 100))); // Se aplica crit damage
                }
                else
                {
                    enemyTiger.TakeDamage(attackDamage);
                }
            }

            if (enemyParrot != null)
            {
                if (Random.Range(1, 100) <= critChance)
                {
                    enemyParrot.TakeDamage(attackDamage + (attackDamage * (critDamage / 100)));
                }
                else
                {
                    enemyParrot.TakeDamage(attackDamage);
                }
            }
        }
    }

    // Vizualizare attack range
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    //Setters

    public void setMeleeDamage(float newMeleeDamage)
    {
        attackDamage = newMeleeDamage;
    }

    public void setCritChance(float newCritChance)
    {
        critChance = newCritChance;
    } 
    
    public void setCritDamage(float newCritDamage)
    {
        critDamage = newCritDamage;
    }



    
}
