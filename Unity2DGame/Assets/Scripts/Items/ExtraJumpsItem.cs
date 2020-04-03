using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraJumpsItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] int extraJumpsChange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerStats>().setExtraJumps(extraJumpsChange);
            Destroy(gameObject);
        }
    }
}
