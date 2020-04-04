﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float maxHealth = 50;
    private int extraJumps = 1;
    private float movementSpeed = 10;
    private float meleeDamage = 20;
    private float rangeDamage = 20;
    private float fireRate = 0.5f;
    private float critChance = 10f;
    private float critDamage = 50f;
    private GameObject player;

    //Singleton
    public static PlayerStats Instance { get; private set; }

    
    private void Awake()
    {
        if (Instance== null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }


        player = GameObject.FindGameObjectWithTag("Player");

       

    }

    //End of singleton


    /*Fiecare functie primeste ca argument schimbarea pe care o va suferi stat-ul respectiv al playerului
     * Se actualizeaza mai intai stat-ul respectiv in acest script
     * Apoi se actualizeaza statu-l respectiv in scripturile in care se va folosi mai departe pentru a nu se face schimbarea in update in acele scripturi care ar costa foarte multe resurse
    */
    public void setMaxHealth(float maxHealthChange)
    {
        maxHealth += maxHealthChange;
        player.GetComponent<PlayerLife>().changeMaxHealth(maxHealth);
    }

    public void setExtraJumps (int extraJumpsChange)
    {
        extraJumps += extraJumpsChange;
        player.GetComponent<PlayerMovement>().setExtraJumps(extraJumps);
    }

    public void setMovementSpeed (float movementSpeedChange)
    {
        movementSpeed += movementSpeedChange;
        player.GetComponent<PlayerMovement>().setMovementSpeed(movementSpeed);
    }

    public void setMeleeDamage (float meleeDamageChange)
    {
        meleeDamage += meleeDamageChange;
        player.GetComponent<PlayerMeleeAtack>().setMeleeDamage(meleeDamage);
    }

    public void setRangeDamage (float rangeDamageChange)
    {
        rangeDamage += rangeDamageChange;
    }

    public void setFireRate(float fireRateChange)
    {
        fireRate += fireRateChange;
        player.GetComponent<Weapon>().setFireRate(fireRate);
    }


    public void setDoubleRangeDamage()
    {
        rangeDamage *= 2;
    }

    public void setCritChance(float critChanceChange)
    {
        critChance += critChanceChange;
        player.GetComponent<PlayerMeleeAtack>().setCritChance(critChance);
    }

    public void setCritDamage(float critDamageChange)
    {
        critDamage += critDamageChange;
        player.GetComponent<PlayerMeleeAtack>().setCritDamage(critDamage);
    }



    //Getters
    public float getMaxHealth()
    {
        return maxHealth;
    }

    public int getExtraJumps()
    {
        return extraJumps;
    }

    public float getMovementSpeed()
    {
        return movementSpeed;
    }

    public float getMeleeDamage()
    {
        return meleeDamage;
    }

    public float getRangeDamage()
    {
        return rangeDamage;
    }

    public float getFireRate()
    {
        return fireRate;
    }

    public float getCritChance()
    {
        return critChance;
    }

    public float getCritDamage()
    {
        return critDamage;
    }



}