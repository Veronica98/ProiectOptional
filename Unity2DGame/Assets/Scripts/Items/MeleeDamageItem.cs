using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamageItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float meleeDamageChange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerStats>().setMeleeDamage(meleeDamageChange);
            Destroy(gameObject);
        }
    }
}
