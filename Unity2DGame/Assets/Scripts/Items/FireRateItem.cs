using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float fireRateChange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerStats>().setFireRate(fireRateChange);
            Destroy(gameObject);
        }
    }
}
