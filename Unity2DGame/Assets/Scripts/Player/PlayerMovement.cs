using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private int extraJumps;
    public int extraJumpsValue; 

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }




    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw    ("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true)
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

        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps == 0 && isGrounded ==true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name == "jungle_pack_39 (1)") && (isGrounded == true))
        {
            
            yield return new WaitForSeconds(1);   //asteapta 1 secunda si distruge platforma
            Destroy(collision.gameObject);
        }
        if ((collision.gameObject.name == "SinglePlatform (1)") && (isGrounded == true))
        {
            yield return new WaitForSeconds(1);   //asteapta 1 secunda si distruge platforma
            Destroy(collision.gameObject);

        }
        if ((collision.gameObject.name == "SinglePlatform (2)") && (isGrounded == true))
        {
            yield return new WaitForSeconds(1);   //asteapta 1 secunda si distruge platforma
            Destroy(collision.gameObject);

        }

        if ((collision.gameObject.name == "SinglePlatform(4)") && (isGrounded == true))
        {
            yield return new WaitForSeconds(1);   //asteapta 1 secunda si distruge platforma
            Destroy(collision.gameObject);

        }
    
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
