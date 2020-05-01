using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritChanceItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float critChanceChange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  // Se cauta dupa tag player-ul
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerStats>().setCritChance(critChanceChange); // Daca exista coliziune cu player-ul se apeleaza functia din PlayerStats pentru stat-ul respectiv si apoi se distruge obiectul instant
            Destroy(gameObject,2f);
        }
    }
}
