using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float maxHealth;
    private int extraJumps;
    private float movementSpeed;
    private float meleeDamage;
    private float rangeDamage;
    private float fireRate;
    private GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void setMaxHealth(float maxHealthChange)
    {
        maxHealth = player.GetComponent<PlayerLife>().getCurrentLife();
        player.GetComponent<PlayerLife>().changeMaxHealth(maxHealth + maxHealthChange);
    }

    public void setExtraJumps (int extraJumpsChange)
    {
        extraJumps = player.GetComponent<PlayerMovement>().getExtraJumps();
        player.GetComponent<PlayerMovement>().setExtraJumps(extraJumps + extraJumpsChange);
    }

    public void setMovementSpeed (float movementSpeedChange)
    {
        movementSpeed = player.GetComponent<PlayerMovement>().getMovementSpeed();
        player.GetComponent<PlayerMovement>().setMovementSpeed(movementSpeed + movementSpeedChange);
    }

    public void setMeleeDamage (float meleeDamageChange)
    {
        meleeDamage = player.GetComponent<PlayerMeleeAtack>().getMeleeDamage();
        player.GetComponent<PlayerMeleeAtack>().setMeleeDamage(meleeDamage + meleeDamageChange);
    }

    public void setRangeDamage (float rangeDamageChange)
    {
        rangeDamage = player.GetComponent<Weapon>().getRangeDamage();
        player.GetComponent<Weapon>().setRangeDamage(rangeDamage + rangeDamageChange);
    }

    public void setFireRate(float fireRateChange)
    {
        fireRate = player.GetComponent<Weapon>().getFireRate();
        player.GetComponent<Weapon>().setFireRate(fireRate + fireRateChange);
    }




}
