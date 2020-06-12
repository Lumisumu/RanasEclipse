using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Touch4 : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    public GameObject Player;
    public Transform groundCheck;

    Vector2 swipeSuuntaVektori;
    Vector2 startPos;
    Vector2 endPos;
    Vector2 clickedPosition;

    public float touchDistance;
    public float maxSpeed = 100f;
    float distance = 0;

    float distance2 = 0;

    public Text m_Text;
    public Text m_Text2;

    float kulmaRad = 0;
    int liike;

    bool move = false;
    bool HasPlayerTouchedChara = false;
    bool DoesPlayerMove = false;
    bool boolstop = true;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (DoesPlayerMove == true)
        {
            move = true;
        }

        //m_Text2.text = " " + distance;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            clickedPosition = Camera.main.ScreenToWorldPoint(touch.position);
            distance = Vector2.Distance(clickedPosition, transform.position);
            //m_Text2.text = "" + distance;

            //laskee kosketuksen kulmaa
            swipeSuuntaVektori = startPos - touch.position;
            kulmaRad = Mathf.Atan2(swipeSuuntaVektori.x, swipeSuuntaVektori.y);
            float kulma = kulmaRad * Mathf.Rad2Deg;

            if (kulma < 0)
            {
                kulma = 360 + kulma;
            }

            TouchIntoEvent(kulma);


            m_Text.text = "tX: " + clickedPosition.x;
            m_Text2.text = "tY: " + clickedPosition.y;
            //m_Text.text = "Mag: " + swipeSuuntaVektori.magnitude;


            switch (touch.phase)
            {

                case TouchPhase.Began:
                    touchplayer(touch);
                    if (HasPlayerTouchedChara == false)
                    {
                        shoot();
                    }
                    if (HasPlayerTouchedChara == true)
                    {
                        boolstop = true;
                    }

                    break;

                case TouchPhase.Moved:
                    if (HasPlayerTouchedChara == true)
                    {
                        distance2 = Vector2.Distance(clickedPosition, transform.position);
                        move = true;
                    }
                    break;

                case TouchPhase.Stationary:

                    break;

                case TouchPhase.Ended:
                    if (HasPlayerTouchedChara == true)
                    {
                        distance2 = Vector2.Distance(clickedPosition, transform.position);
                    }
                    HasPlayerTouchedChara = false;
                    break;

                case TouchPhase.Canceled:

                    break;


            }
            //m_Text2.text = "" + distance2;
            //m_Text.text = "" + HasPlayerTouchedChara;
        }
    }

    void FixedUpdate()
    {

        if (boolstop == true)
        {
            stop();
        }

        if (move == true)
        {
            liikuta();
        }

    }

    void liikuta()
    {

        if (swipeSuuntaVektori.magnitude >= 40.0f)
        {

            if (liike == 4)
            {
                rbPlayer.velocity = Vector2.right * (distance2);
            }
            if (rbPlayer.velocity.magnitude > maxSpeed)
            {
                rbPlayer.velocity = rbPlayer.velocity.normalized * maxSpeed;
            }
            if (liike == 2)
            {
                rbPlayer.velocity = Vector2.left * (distance2);
            }
        }
    }

    void shoot()
    {

    }

    void TouchIntoEvent(float suunta)
    {

        if (suunta > 315 || suunta <= 45)
        {
            liike = 1; //alas
        }

        if (suunta > 45 && suunta <= 135)
        {
            liike = 2; //vasen
        }

        if (suunta > 135 && suunta <= 225)
        {
            liike = 3;//ylös
        }

        if (suunta > 225 && suunta <= 315)
        {
            liike = 4; //oikea
        }
    }

    void liikkuukopelaaja()
    {
        //tarkista liikkuuko pelaaja
        if (rbPlayer.velocity.magnitude >= 0)
            DoesPlayerMove = true;
    }

    void stop()
    {
        rbPlayer.velocity = Vector2.zero;
        DoesPlayerMove = false;
    }

    void touchplayer(Touch touch)
    {

        //jos kosketus on hahmon kosketusalueen sisällä
        if (clickedPosition.y - transform.position.y <= touchDistance && clickedPosition.y - transform.position.y >= -touchDistance && clickedPosition.x - transform.position.x <= touchDistance && clickedPosition.x - transform.position.x >= -touchDistance)
        {
            HasPlayerTouchedChara = true;
            startPos = touch.position;
        }
        else
        {
            HasPlayerTouchedChara = false;
        }
    }


}
