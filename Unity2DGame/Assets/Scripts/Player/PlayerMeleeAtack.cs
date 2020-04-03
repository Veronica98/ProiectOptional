using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAtack : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackDamage = 20f;



    // Update is called once per frame
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
                enemyTiger.GetComponent<EnemyController>().TakeDamage(attackDamage);
            }

            if(enemyParrot != null)
            {
                enemyParrot.TakeDamage(attackDamage);
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

    
}
