using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 7;
    private Rigidbody2D rb2d;

    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.3f;
    public LayerMask whatIsGround;
    public float jumpForce = 0f;
    SpriteRenderer sr;
    public Sprite jumpSprite;
    public Sprite Idle;
    public Sprite Run;
    private Vector2 touchOrigin = -Vector2.one;

    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        
    }
    
    void FixedUpdate()
    {
        if (grounded == true && rb2d.velocity.x == 0 && rb2d.velocity.y == 0)
        {
            //sr.sprite = Idle;
        }
        
       grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    
       float move = Input.GetAxis ("Horizontal");

       rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
   
    }

    void Update()
    {
        int horizontal = 0;
        int vertical = 0;

        if (grounded && Input.GetKey(KeyCode.Space))
        {
            //sr.sprite = jumpSprite;
            rb2d.AddForce(new Vector2(0, jumpForce));
        }

        //Debug.Log(grounded);
        
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
