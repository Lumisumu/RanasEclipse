using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleDeathEffect : MonoBehaviour {

    public GameObject ParticleEffect;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.K))
        {
            Instantiate(ParticleEffect, transform.position , Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
