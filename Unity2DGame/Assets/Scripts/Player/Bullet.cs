using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private float damage;
    private GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        damage = player.GetComponent<Weapon>().getRangeDamage();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        EnemyController enemy = hitInfo.GetComponentInParent<EnemyController>();
        

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (hitInfo.name != "Player")
        {
            Destroy(gameObject);
        }

        
    }


        

   
}
