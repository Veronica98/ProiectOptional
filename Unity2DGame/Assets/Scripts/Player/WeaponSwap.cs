using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject meleeWeapon;
    [SerializeField] private GameObject rangedWeapon;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        meleeWeapon = GameObject.Find("MeleeWeapon");
        rangedWeapon = GameObject.Find("Gun");

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMeleeAtack>().enabled && !player.GetComponent<Weapon>().enabled) // Daca suntem in meeleAttack
        {
            if (Input.GetKeyDown(KeyCode.Q)) // Apasam Q
            {
                player.GetComponent<Weapon>().enabled = true; // Dam enable la scriptul de range
                rangedWeapon.GetComponent<SpriteRenderer>().enabled = true; // Dam enable la sprite pentru arma range
                player.GetComponent<PlayerMeleeAtack>().enabled = false; // Dam disable la scriptul de melee
                meleeWeapon.GetComponent<SpriteRenderer>().enabled = false; // Dam disable la sprite-ul armei melee
            }
        }
        else if (!player.GetComponent<PlayerMeleeAtack>().enabled && player.GetComponent<Weapon>().enabled) // Daca suntem in rangeAttack
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player.GetComponent<Weapon>().enabled = false;
                rangedWeapon.GetComponent<SpriteRenderer>().enabled = false;
                player.GetComponent<PlayerMeleeAtack>().enabled = true;
                meleeWeapon.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
