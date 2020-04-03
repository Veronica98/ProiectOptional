using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleRangeDamageItem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float rangeDamageChange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<Weapon>().setDoubleRangeDamage();
            Destroy(gameObject);
        }
    }
}
