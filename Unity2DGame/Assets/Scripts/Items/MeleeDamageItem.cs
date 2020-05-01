using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamageItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float meleeDamageChange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Se cauta dupa tag player-ul
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerStats>().setMeleeDamage(meleeDamageChange); // Daca exista coliziune cu player-ul se apeleaza functia din PlayerStats pentru stat-ul respectiv si apoi se distruge obiectul instant
            Destroy(gameObject, 2f);
        }
    }
}
