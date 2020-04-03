using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float damage;
    

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        EnemyController enemyTiger = hitInfo.GetComponentInParent<EnemyController>();
        EnemyAI enemyParrot = hitInfo.GetComponent<EnemyAI>();
        

        if (enemyTiger != null)
        {
            enemyTiger.TakeDamage(damage);
        }

        if (enemyParrot != null)
        {
            enemyParrot.TakeDamage(damage);
        }

        if (hitInfo.name != "Player")
        {
            Destroy(gameObject);
        }

        
    }
        

   
}
