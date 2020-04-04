﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float maxHealthChange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Se cauta dupa tag player-ul
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerStats>().setMaxHealth(maxHealthChange); // Daca exista coliziune cu player-ul se apeleaza functia din PlayerStats pentru stat-ul respectiv si apoi se distruge obiectul instant
            Destroy(gameObject);
        }
    }
}