using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraJumpsItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] int extraJumpsChange = 1;
    private float limitExtraJumps = 5;
    private float currentExtraJumps;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Se cauta dupa tag player-ul
        currentExtraJumps = player.GetComponent<PlayerStats>().getExtraJumps();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (currentExtraJumps + extraJumpsChange <= limitExtraJumps)
            {
                player.GetComponent<PlayerStats>().setExtraJumps(extraJumpsChange); // Daca exista coliziune cu player-ul se apeleaza functia din PlayerStats pentru stat-ul respectiv si apoi se distruge obiectul instant 
            }
            Destroy(gameObject, 2f);
        }
    }
}
