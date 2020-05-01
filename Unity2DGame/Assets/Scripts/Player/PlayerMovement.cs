using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed; // Viteza de miscare
    [SerializeField] private float jumpForce = 25;
    private float moveInput;
    private int extraJumps;
    [SerializeField] private int extraJumpsValue; 

    private Rigidbody2D rb; // RigidBody-ul playerului

    private bool isGrounded; // Bool daca playerul este pe pamant sau nu
    public Transform groundCheck; // Pozitia de unde verifica daca suntem pe ceva de pe care se poate sari sau nu
    public float checkRadius; // Raza prin care verifica daca suntem pe ceva de pe care se poate sari sau nu
    public LayerMask whatIsGround; // De pe ce obiecte se poate sari
    public bool isSwinging; // Bool pentru a vedea daca esti in grappling hook sau nu

    private bool facingRight = true; // Verificare daca playerul este cu fata in stanga sau in dreapta

    void Start()
    {
        speed = gameObject.GetComponent<PlayerStats>().getMovementSpeed(); // Preluam staturile din playerStats
        extraJumpsValue = gameObject.GetComponent<PlayerStats>().getExtraJumps();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //Crearea cercului de verificare

        moveInput = Input.GetAxisRaw    ("Horizontal"); // Input de miscare A D sau Sageata stanga sau Sageata dreapta
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // Adaugare forta de miscare
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true) // Verificam daca player-ul este pe pamanat
        {
            extraJumps = extraJumpsValue;
        }

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps > 0) // Jump in aer
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps == 0 && isGrounded ==true) // Jump pe pamant
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "DisappearingTile") && (isGrounded == true))
        {

            Destroy(collision.gameObject);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    //Setters

    public void setExtraJumps(int newExtraJumps)
    {
        extraJumpsValue = newExtraJumps;
    }

    public void setMovementSpeed(float newMovementSpeed)
    {
        speed = newMovementSpeed;
    }


    //Getters

    public int getExtraJumps()
    {
        return extraJumpsValue;
    }

    public float getMovementSpeed()
    {
        return speed;
    }
}
