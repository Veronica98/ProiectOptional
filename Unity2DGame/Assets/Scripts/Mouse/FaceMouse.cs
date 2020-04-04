using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    void Update()
    {
        faceMouse();
    }

    void faceMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // Luam pozitia mouse-ului din joc

        difference.Normalize(); // Normalizam
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; // Calculam rotatia in grade
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
}