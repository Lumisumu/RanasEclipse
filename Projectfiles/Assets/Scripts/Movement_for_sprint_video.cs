using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_for_sprint_video : MonoBehaviour {

    public float maxSpeed = 20;
    Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float move = Input.GetAxisRaw("Horizontal");
        float move2 = Input.GetAxisRaw("Vertical");

        rigidbody.velocity = new Vector2(move * maxSpeed, move2 * maxSpeed);
        

    }
}
