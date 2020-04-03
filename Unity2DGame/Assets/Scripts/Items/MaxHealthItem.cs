using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float maxHealthChange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerStats>().setMaxHealth(maxHealthChange);
            Destroy(gameObject);
        }
    }
}
