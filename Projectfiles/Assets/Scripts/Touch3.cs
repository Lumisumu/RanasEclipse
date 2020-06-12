using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Touch3 : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    public GameObject Player;
    Vector2 swipeSuuntaVektori, startPos, endPos;
    float kulmaRad = 0;
    int liike;

    public Text m_Text, m_Text2;

    float touchDistance = 3;
    float distance = 0;

    bool HasPlayerTouchedChara = false;
    bool inOut = false;
    bool doesPlayerMove = false;

    //boolit updatelle
    bool move = false;
    bool stop = true;


    // Use this for initialization
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        m_Text.text = "" + touchDistance;
        //m_Text2.text = "" + HasPlayerTouchedChara;

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            Vector2 clickedPosition = Camera.main.ScreenToWorldPoint(touch.position);
           

            //laskee kosketuksen kulmaa
            swipeSuuntaVektori = startPos - touch.position;
            kulmaRad = Mathf.Atan2(swipeSuuntaVektori.x, swipeSuuntaVektori.y);
            float kulma = kulmaRad * Mathf.Rad2Deg;

            if (kulma < 0)
            {
                kulma = 360 + kulma;
            }

            TouchIntoEvent(kulma);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    touchChara(touch);
                    isTouchInOrOut(touch);

                    if (inOut == false)
                    {
                        shoottinks();
                    }

                    touchChara(touch);
                    if (inOut == true)
                    {
                        stop = true;
                        move = false;
                    }
                    break;

                case TouchPhase.Moved:
                    stop = false;
                    move = true;
                    break;

                case TouchPhase.Stationary:
                    stop = false;
                    move = true;
                    break;

                case TouchPhase.Canceled:
                    stop = false;
                    move = true;
                    break;

                case TouchPhase.Ended:


                    break;
            }      
        }
    }


    void FixedUpdate()
    {
        if (stop == true) { stopChara(); }

        if (move == true) { moveChara(); }

    }

    void moveChara()
    {
        if (HasPlayerTouchedChara == true && swipeSuuntaVektori.magnitude >= 40.0f) ;

        if (liike == 4)
        {
            rbPlayer.velocity = Vector2.right * (swipeSuuntaVektori.magnitude / 50.0f);
        }
        if (liike == 2)
        {
            rbPlayer.velocity = Vector2.left * (swipeSuuntaVektori.magnitude / 50.0f);
        }

    }


    void stopChara()
    {
        rbPlayer.velocity = Vector2.zero;

    }

    void liikkuukopelaaja()
    {
        if (rbPlayer.velocity.magnitude >= 0)
            doesPlayerMove = true;
    }

   
    void shoottinks()
    {
        Debug.Log("Pum! Pum!");
    }

    void jumpings()
    {
        Debug.Log("Jump! Jump!");
    }

    void touchChara(Touch touch)
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

    void isTouchInOrOut(Touch touch)
    {
        if (distance <= touchDistance)
        {
            inOut = true;
            startPos = touch.position;
        }
        else
        {
            inOut = false;
        }

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
}
