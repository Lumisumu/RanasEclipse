using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController2D))]
//[RequireComponent(typeof(BoxCollider2D))]
public class EnemyPhysics : EnemyRaycastController
{


    Rigidbody2D enemyRB;
    Animator anim;

    /*
    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = 0.4f;
    
    float minJumpVelocity;
    float maxJumpVelocity;
   */

    public float gravity = 0;
    public float moveSpeed = 6;

    Vector3 velocity;

    EnemyController2D controller;
    //BoxCollider2D enemyBoxColl;
    

    public override void Start()
    {
        UpdateRaycastOrigins();
        enemyRB = GetComponent<Rigidbody2D>();
        //enemyBoxColl = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        controller = GetComponent<EnemyController2D>();
        
    }

    void Update()
    {
        velocity = enemyRB.velocity;
        velocity.y += gravity * Time.deltaTime;
        UpdateRaycastOrigins();
        controller.collisions.Reset();
        controller.collisions.velocityOld = enemyRB.velocity;
        if (velocity.x != 0)
        {
            controller.collisions.faceDirection = (int)Mathf.Sign(velocity.x);
        }

        if (velocity.y < 0)
        {
            controller.DescendSlope(ref velocity);
        }

        controller.HorizontalCollisions(ref velocity);

        if (velocity.y != 0)
        {
            controller.VerticalCollisions(ref velocity);
        }

        transform.Translate(velocity);

        enemyRB.velocity = transform.right * moveSpeed;
    }

}
