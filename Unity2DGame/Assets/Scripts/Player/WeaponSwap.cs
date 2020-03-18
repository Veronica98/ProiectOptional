using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMeleeAtack>().enabled && !player.GetComponent<Weapon>().enabled)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player.GetComponent<Weapon>().enabled = true;
                player.GetComponent<PlayerMeleeAtack>().enabled = false;
            }
        }
        else if (!player.GetComponent<PlayerMeleeAtack>().enabled && player.GetComponent<Weapon>().enabled)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player.GetComponent<Weapon>().enabled = false;
                player.GetComponent<PlayerMeleeAtack>().enabled = true;
            }
        }
    }
}
