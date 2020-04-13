using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float fireRateChange;
    private float limitFireRate =0.005f;
    private float currentFireRate;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Se cauta dupa tag player-ul
        currentFireRate = player.GetComponent<PlayerStats>().getFireRate();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (currentFireRate + fireRateChange >= limitFireRate)
            {
                player.GetComponent<PlayerStats>().setFireRate(fireRateChange); // Daca exista coliziune cu player-ul se apeleaza functia din PlayerStats pentru stat-ul respectiv si apoi se distruge obiectul instant
            }
            Destroy(gameObject);
        }
    }
}
