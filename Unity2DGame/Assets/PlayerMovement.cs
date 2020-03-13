using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Char controller taken from here : https://github.com/Brackeys/2D-Character-Controller
    public CharacterController2D control;
    float xMove = 0f;
    public float Speed = 50f;
    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal") * Speed;
    }
    void FixedUpdate()
    {
        control.Move(xMove * Time.fixedDeltaTime,false,false);
    }
}
