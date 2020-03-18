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

        EnemyController enemy = hitInfo.GetComponentInParent<EnemyController>();
        

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log(enemy.currentHealth);
        }

        if (hitInfo.name != "Player")
        {
            Destroy(gameObject);
        }

        Debug.Log("You hit " + hitInfo.name);
    }
        

   
}
