using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed; // Viteza bullet-ului
    [SerializeField] private Rigidbody2D rb; // Rigidbody-ul bullet-ului
    private float damage;
    private float critChance;
    private float critDamage;

    private GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Cautam player-ul dupa tag
    }

    // Start is called before the first frame update
    void Start()
    {
        critChance = player.GetComponent<PlayerStats>().getCritChance(); // Preluam critChance-ul din scriptul PlayerStats
        critDamage = player.GetComponent<PlayerStats>().getCritDamage(); // Preluam critDamage-ul din scriptul playerStats
        damage = player.GetComponent<PlayerStats>().getRangeDamage();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f); // Se distruge automat dupa 3 secunde pentru a nu incarca scena cu clone
    }

    void OnTriggerEnter2D(Collider2D hitInfo) // Daca exista coliziune
    {

        EnemyController enemyTiger = hitInfo.GetComponentInParent<EnemyController>(); // Cautam ca acea coliziune sa contina scriptul enemyController (tigru)
        EnemyAI enemyParrot = hitInfo.GetComponent<EnemyAI>(); // Cautam ca acea coliziune sa contina scriptul EnemyAI (papagal)


        if (enemyTiger != null) // Daca am gasit un tigru
        {
            if (Random.Range(1,100) <= critChance) // Vedem daca se aplica critical
            {
                enemyTiger.TakeDamage(damage+(damage*(critDamage/100))); // Daca da aplicam la damage si crit damage-ul
            }
            else
            {
                enemyTiger.TakeDamage(damage); // Daca nu doar lovim tigrul cu damage-ul normal
            }
        }

        if (enemyParrot != null) // Daca am gasit un papagal
        {
            if (Random.Range(1, 100) <= critChance) // Vedem daca se aplica critical
            {
                enemyParrot.TakeDamage(damage + (damage * (critDamage / 100))); // Daca da aplicam la damage si crit damage-ul
            }
            else
            {
                enemyParrot.TakeDamage(damage); // Daca nu doar lovim papagalul cu damage-ul normal
            }
        }

        if (hitInfo.name != "Player") // Ne asiguram ca se intampla nimic atunci cand exista coliziune cu player-ul
        {
            Destroy(gameObject); // Daca a lovit orice altceva inafara de ce ne intereseaza (inamici / player) se va distruge
        }

        
    }


        

   
}
