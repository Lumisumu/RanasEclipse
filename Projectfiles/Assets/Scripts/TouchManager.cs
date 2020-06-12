using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{

    Vector2 TouchStart;
    Vector2 TouchEnd;
    Vector2 previousPosition;
    Vector2 currentPosition;
    Vector2 nextMovement;
    Touch myTouch;
    float kulmaRad = 0;
    Rigidbody2D rb2d;
    public Vector2 Velocity { get; protected set; }
    public float maxSpeed = 100.0f;
    public float maxJump = 400f;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.3f;
    public LayerMask whatIsGround;
    private bool touchcontinuation = false;

    public delegate void SwipeGesture(string suunta);
    public static event SwipeGesture OnSwipe;

    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        currentPosition = rb2d.position;
        previousPosition = rb2d.position;
    }

    void FixedUpdate()
    {

        if (touchcontinuation)
        {
            previousPosition = rb2d.position;
            currentPosition = previousPosition + nextMovement;
            Velocity = (currentPosition - previousPosition) / Time.deltaTime;

            //myTouch = Input.touches[0];
            //Application.Quit();
            TouchStart = myTouch.position;
            //Debug.Log("alku : " + TouchStart);
            if (myTouch.position.x >= 1440 && myTouch.position.y < 800)
            {
                rb2d.AddForce(new Vector2(100, 0));

                if (rb2d.velocity.magnitude > maxSpeed)
                {
                    rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
                }
            }
            else if (myTouch.position.x <= 480 && myTouch.position.y < 800)
            {
                rb2d.AddForce(new Vector2(-100, 0));

                if (rb2d.velocity.magnitude > maxSpeed)
                {
                    rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
                }
            }
            else if (myTouch.position.y >= 800 && grounded)
            {
                rb2d.AddForce(new Vector2(0, 400));
                if (rb2d.velocity.magnitude > maxJump)
                {
                    rb2d.velocity = rb2d.velocity.normalized * maxJump;
                }
            }

            //Yllä oleva toimii, joten touchin tunnistamisessa ei pitäisi olla ongelmaa. Saattaapi olla rigidbodyn ongelma se liikkumattomuus


            /*if(myTouch.position.x > 960 && myTouch.position.y < 600 && myTouch.phase == TouchPhase.Stationary)
            {

                rb2d.AddForce(new Vector2(100, 0));
            }
            if (rb2d.velocity.magnitude > maxSpeed)
            {
                rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
            }

            if(myTouch.position.x <= 960 && myTouch.position.y < 600 && myTouch.phase == TouchPhase.Stationary)
            {
                rb2d.AddForce(new Vector2(100, 0));
            }
            if (rb2d.velocity.magnitude > maxSpeed)
            {
                rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
            }*/
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
        /*if (Input.touchCount == 0 && myTouch.phase == TouchPhase.Ended)
        {
            Debug.LogError("end");
            TouchEnd = myTouch.position;
            //Debug.Log("loppu : " + TouchEnd);

            Vector2 suuntavektori = TouchEnd - TouchStart;
            //Debug.Log("jeah " + suuntavektori);

            kulmaRad = Mathf.Atan2(suuntavektori.x, suuntavektori.y);
            //Debug.Log("kulma " + kulmaRad);

            float kulma = kulmaRad * Mathf.Rad2Deg;
            //Debug.Log("degrees " + kulma);

            if (kulma < 0)
            {
                kulma = 360 + kulma;
            }

            //Debug.Log("Kulma " + kulma);

            TouchIntoEvent(kulma);

            if (suuntavektori.x > 0)
            {
                rb2d.AddForce(new Vector2(100, 0));
            }
            else if (suuntavektori.x < 0)
            {
                rb2d.AddForce(new Vector2(-100, 0));
            }
            else if (suuntavektori.y > suuntavektori.x)
            {
                rb2d.AddForce(new Vector2(0, 100));
            }

        }*/
    }

    public void Move (Vector2 movement)
    {
        nextMovement += movement;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            myTouch = Input.touches[0];
            touchcontinuation = true;
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchcontinuation = false;
        }

        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TouchStart = Input.GetTouch(0).position;
            //Debug.Log("alku : " + TouchStart);
        }
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            TouchEnd = Input.GetTouch(0).position;
            //Debug.Log("loppu : " + TouchEnd);

            Vector2 suuntavektori = TouchEnd - TouchStart;
            //Debug.Log("jeah " + suuntavektori);

            kulmaRad = Mathf.Atan2(suuntavektori.x, suuntavektori.y);
            //Debug.Log("kulma " + kulmaRad);

            float kulma = kulmaRad * Mathf.Rad2Deg;
            //Debug.Log("degrees " + kulma);

            if (kulma < 0)
            {
                kulma = 360 + kulma;
            }

            //Debug.Log("Kulma " + kulma);

            //TouchIntoEvent(kulma);
            
            if(suuntavektori.x > 0)
            {
                float move = Input.GetAxis("Horizontal");
                rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
            }
            else if(suuntavektori.x < 0)
            {
                float move = Input.GetAxis("Horizontal");
                rb2d.velocity = new Vector2(move * maxSpeed, -rb2d.velocity.y);
            }

        }
    }

    /*void TouchIntoEvent(float suunta)
    {
        if (suunta > 315 || suunta <= 45)
        {
            Debug.Log("N");
            OnSwipe("N");
        }
        
        if (suunta > 45 && suunta <= 135)
        {
            Debug.Log("E");
            OnSwipe("E");
        }
        
        if (suunta > 135 && suunta <= 225)
        {
            Debug.Log("S");
            OnSwipe("S");
        }
        
        if (suunta > 225 && suunta <= 315)
        {
            Debug.Log("W");
            OnSwipe("W");
        } 
    }*/
}
