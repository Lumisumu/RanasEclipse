using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

    
    Rigidbody2D playerRB;
    Animator anim;
    public bool onAir = false;

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = 0.4f;
    public float accelerationTimeAirborne = 0.2f;
    public float accelerationTimeGrounded = 0.1f;
    public float moveSpeed = 6;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpHopOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    float timeToUnstick;

    float gravity;
    float minJumpVelocity;
    float maxJumpVelocity;

    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;

    Vector2 directionalInput;
    bool wallSliding;
    int wallDirX;
    
	void Start () {

        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        //print("Gravity: " + gravity + ", Jump velocity: " + maxJumpVelocity);
	}

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
       /* if (wallSliding)
        {
            if (wallDirX == directionalInput.x)
            {
                velocity.x = -wallDirX * wallJumpClimb.x;
                velocity.y = wallJumpClimb.y;
            }
            else if (directionalInput.x == 0)
            {
                velocity.x = -wallDirX * wallJumpHopOff.x;
                velocity.y = wallJumpHopOff.y;
            }
            else
            {
                velocity.x = -wallDirX * wallLeap.x;
                velocity.y = wallLeap.y;
            }
            // worthy defaults: ClimbX 7.5, ClimbY 16; HopOffX 8.5, HopOffY 7; LeapX 18, LeapY 17.
        }*/
        if (controller.collisions.below)
        {
            onAir = true;
            anim.SetBool("JumpBool", true);
            anim.SetBool("Grounded", false);
            velocity.y = maxJumpVelocity;
        }
    }
    
    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }

	void Update () {

        wallDirX = (controller.collisions.left) ? -1 : 1;

        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        //wallslide
       /* wallSliding = false;
        if((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (directionalInput.x != wallDirX && directionalInput.x != 0)
                {
                    timeToUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToUnstick = wallStickTime;
                }
            }
            else
            {
                timeToUnstick = wallStickTime;
            }
        }
        */
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime, directionalInput);

        if (controller.collisions.above || controller.collisions.below)
        {
            onAir = false;
            anim.SetBool("Grounded", true);
            anim.SetBool("JumpBool", false);
            velocity.y = 0;
        }

    }

}
