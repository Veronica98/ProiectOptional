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
        if (player.GetComponent<PlayerMeleeAtack>().enabled && !player.GetComponent<Weapon>().enabled)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player.GetComponent<Weapon>().enabled = true;
                rangedWeapon.GetComponent<SpriteRenderer>().enabled = true;
                player.GetComponent<PlayerMeleeAtack>().enabled = false;
                meleeWeapon.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else if (!player.GetComponent<PlayerMeleeAtack>().enabled && player.GetComponent<Weapon>().enabled)
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
