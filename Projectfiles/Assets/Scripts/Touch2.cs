using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Touch2 : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    public GameObject Player;
    public Transform groundCheck;
    public LayerMask WhatIsGround;

    Vector2 swipeSuuntaVektori;
    Vector2 startPos;
    Vector2 endPos;
    Vector2 dir;

    float varaMagnitude;

    float touchDistance = 3;
    public float maxXSpeed = 12f;
    public float jumpForce;
    float distance = 0;
    float distance2 = 0;
    float groundRadius = 0.3f;

    float kulmaRad;
    float kulma;



    public Text m_Text;
    public Text m_Text2;

    int liike;
    int liike2;

    public bool move = false;
    public bool HasPlayerTouchedChara = false;
    public bool DoesPlayerMove = false;
    public bool boolstop = true;
    public bool grounded = true;
    public bool hyppybool = false;



    LineRenderer lr;
    public float lr_velocity;
    public float lr_angle;
    public int lr_resolution = 15;

    float lr_g;
    float lr_radianAngle;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
        lr_g = Mathf.Abs(Physics2D.gravity.y);
    }

    private void OnValidate()
    {
        if (lr != null && Application.isPlaying)
        {
            RenderArch();
        }

    }

    void Start()
    {
        
    }

    void Update()
    {
        //m_Text.text = "" + swipeSuuntaVektori.magnitude;
        //m_Text2.text = "" + liike2;
        
        m_Text.text = "" + kulma;
       


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 clickedPosition = Camera.main.ScreenToWorldPoint(touch.position);
            distance = Vector2.Distance(clickedPosition, transform.position);


            //laskee kosketuksen kulmaa
            TouchIntoEvent(kulma);
            
            swipeSuuntaVektori = startPos - touch.position;
            kulmaRad = Mathf.Atan2(swipeSuuntaVektori.x, swipeSuuntaVektori.y);
            kulma = kulmaRad * Mathf.Rad2Deg;   

            if (kulma < 0)
            {
                kulma = 360 + kulma;
            }

            

            switch (touch.phase)
            {

                case TouchPhase.Began:
                    touchplayer(touch);
                    if (HasPlayerTouchedChara == false) {
                        shoot();
                    }
                    
                    break;

                case TouchPhase.Moved:


                    if (HasPlayerTouchedChara == true)
                    {
                        distance2 = Vector2.Distance(clickedPosition, transform.position);
                        move = true;
                        liike2 = liike;
                        boolstop = false;
                    }

                    if (liike2 == 3)
                    {
                        RenderArch();
                    }

                    break;
                    
                case TouchPhase.Stationary:
                   
                    break;

                case TouchPhase.Ended:

                    touchplayer(touch);
                    if (DoesPlayerMove == true && HasPlayerTouchedChara == true)
                    {
                        boolstop = false;
                        distance2 = Vector2.Distance(clickedPosition, transform.position);
                        liike2 = liike;
                    }
                    if (HasPlayerTouchedChara == true )
                    {
                        boolstop = true;
                    }

                    if (liike2 == 3)
                    {
                        RenderArch();
                        Hyppy();
                    }

                    HasPlayerTouchedChara = false;
                    break;

                case TouchPhase.Canceled:
                    break;   
            }
        }    
    }

    void FixedUpdate()
    {
       liikkuukopelaaja();

        if (boolstop == true)
        {

            stop();
        }

        if (move == true)
        {
            Liikuta();
        }


        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);

       
    }

    void Liikuta()
    {

        if (DoesPlayerMove == true)
        {
            Vector3 moveVector = Vector3.zero;
            if (liike2 == 4)
            {
                moveVector.x = distance2/2f;
                moveVector.y = -9.81f;
                rbPlayer.velocity = moveVector;


                //rbPlayer.velocity = Vector2.right * distance2 ;
            }
            if (liike2 == 2)
            {
                moveVector.x = -distance2/2f;
                moveVector.y = -9.81f;
                rbPlayer.velocity = moveVector;

                //rbPlayer.velocity = Vector2.left * distance2 ;
            }

        }
    }

    void Hyppy()
    {
        grounded = false;
        rbPlayer.AddForce(-swipeSuuntaVektori.normalized * jumpForce);
    }

    void shoot()
    {

    }

    void TouchIntoEvent(float suunta)
    {

        if (suunta > 340 || suunta <= 20)
        {
            liike = 1; //alas
        }

        if (suunta > 20 && suunta <= 110) //alkuperäiset 20 ja 160
        {
            liike = 2; //vasen
        }

        if (suunta > 110 && suunta <= 250) //alkuperäiset 160 ja 200
        {
            liike = 3;//ylös
        }

        if (suunta > 250 && suunta <= 340)//alkuperäiset 200 ja 340
        {
            liike = 4; //oikea
        }
    }

    void liikkuukopelaaja()
    {
        //tarkista liikkuuko pelaaja
        if (rbPlayer.transform.hasChanged)
        {
            DoesPlayerMove = true;
            move = true;
            
        }
        if (rbPlayer.transform.hasChanged == false)
        {
            DoesPlayerMove = false;
            move = false;
            boolstop = true;
        }
    }

    void stop()
    {
        rbPlayer.velocity = Vector2.zero;
        DoesPlayerMove = false;
        move = false;
    }

    void touchplayer(Touch touch)
    {

        //jos kosketus on hahmon kosketusalueen sisällä
        if (distance <= touchDistance)
        {
            HasPlayerTouchedChara = true;
            startPos = touch.position;
        }
        else
        {
            HasPlayerTouchedChara = false;
        }
    }

    void RenderArch() {
            lr.positionCount = lr_resolution;
            lr.SetPositions(CalculateArcArray());

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
        }
    }

    Vector3[] CalculateArcArray()
    {
       // lr_angle = kulma;
        Vector3[] arcArray = new Vector3[lr_resolution + 1];

        lr_radianAngle = Mathf.Deg2Rad * lr_angle;
        float maxDistance = (lr_velocity * lr_velocity * Mathf.Sin(2 * lr_radianAngle)) / lr_g;

        for (int i = 0; i <= lr_resolution; i++) {
            float t = (float)i / (float)lr_resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);

        }
        return arcArray;

    }

    Vector3 CalculateArcPoint(float t, float maxDistance) {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(lr_radianAngle) - ((lr_g * x * x) / (2 * lr_velocity * lr_velocity * Mathf.Cos(lr_radianAngle) * Mathf.Cos(lr_radianAngle)));
        return new Vector3(x, y);
    }
}


