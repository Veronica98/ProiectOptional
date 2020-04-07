using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float movementSpeedChange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Se cauta dupa tag player-ul
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerStats>().setMovementSpeed(movementSpeedChange); // Daca exista coliziune cu player-ul se apeleaza functia din PlayerStats pentru stat-ul respectiv si apoi se distruge obiectul instant
            Destroy(gameObject);
        }
    }
}
