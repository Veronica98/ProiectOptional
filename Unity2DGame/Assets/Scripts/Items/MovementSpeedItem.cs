using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float movementSpeedChange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerStats>().setMovementSpeed(movementSpeedChange);
            Destroy(gameObject);
        }
    }
}
