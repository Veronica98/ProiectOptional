using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float movementSpeedChange;
    private float limitMovementSpeed = 50;
    private float currentMovementSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Se cauta dupa tag player-ul
        currentMovementSpeed = player.GetComponent<PlayerStats>().getMovementSpeed();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (currentMovementSpeed + movementSpeedChange <= limitMovementSpeed)
            {
                player.GetComponent<PlayerStats>().setMovementSpeed(movementSpeedChange); // Daca exista coliziune cu player-ul se apeleaza functia din PlayerStats pentru stat-ul respectiv si apoi se distruge obiectul instant
            }
            Destroy(gameObject, 2f);
        }
    }
}
