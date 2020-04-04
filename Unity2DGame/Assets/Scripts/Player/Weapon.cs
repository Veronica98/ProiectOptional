using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint; // De unde se trage
    [SerializeField] private GameObject bulletPrefab; // Prefab-ul pentru glont
    [SerializeField] private float fireRate; // Cat de repede trage
    [SerializeField] private float nextFire; // Variabila folosita pentru a limita cat de repede tragi



    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")) // Se trage folosind click stanga
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Shooting logic
        if(Time.time > nextFire)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextFire = Time.time + fireRate;
        }

    }


    //Setters

    public void setFireRate(float newFireRate)
    {
        fireRate = newFireRate;
    }




}
