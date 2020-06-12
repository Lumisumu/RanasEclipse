using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Player))]
public class PlayerInput : MonoBehaviour {

    SpriteRenderer SR;
    Animator anim;
    Player player;
    public JoystickHandler joystickHandler;
    public Button jumpButton;
    [HideInInspector]
    public Vector2 directionalInput, lastDirecInput, direcInput3;



    // Use this for initialization
    void Start () {
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        lastDirecInput = new Vector2(1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        
        directionalInput = joystickHandler.InputDirection;
        player.SetDirectionalInput(directionalInput);
        direcInput3 = directionalInput;

        //print("DirectionalInput: " + directionalInput.x);
        
        if (directionalInput.x == 0)
        {
            anim.SetBool("IsMoving", false);
          
        }
        else if (directionalInput.x < 0) 
        {
            SR.flipX = true;
            anim.SetBool("IsMoving", true);
        }
        else if (directionalInput.x > 0)
        {
            SR.flipX = false;
            anim.SetBool("IsMoving", true);
        }

        if (directionalInput.y != 0.0f && directionalInput.x != 0.0f)
        { lastDirecInput = directionalInput; }

        anim.SetFloat("dir_X", lastDirecInput.x);
        anim.SetFloat("dir_Y", lastDirecInput.y);

    }
}
