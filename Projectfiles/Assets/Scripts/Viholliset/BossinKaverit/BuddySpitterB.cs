﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BuddySpitterB : MonoBehaviour {

	public bool aggro;
	public bool atAttackPosition;
	public float health;
	public int speed;
	public float spitCountdown = 100;
	public float spitInterval;
	public GameObject SmallSpit;

	public AudioSource audioSource;
	public AudioMixer audioMixer;
	public AudioClip BabySpitterSplash;

	private Transform spawnPoint;
	private Transform spitPoint;
	private Vector2 destination;

	GameObject spawnerB;
	BuddySpawnerB BuddySpawnerB;

	void Start () {
		aggro = false;
		atAttackPosition = false;
		spitInterval = spitCountdown;

		spawnPoint = GameObject.FindGameObjectWithTag("spawnerB").GetComponent<Transform>();
		spitPoint = GameObject.FindGameObjectWithTag("SpitPointB").GetComponent<Transform>();
		destination = new Vector2(spitPoint.position.x, spitPoint.position.y);

		spawnerB = GameObject.FindGameObjectWithTag("spawnerB");
		BuddySpawnerB = spawnerB.GetComponent<BuddySpawnerB>();
	}
	
	void Update () {
		SurviveCheck();

		//menee hyokkayspaikalle
		if (transform.position.y - spitPoint.position.y < 1)
        {
            atAttackPosition = true;
        }
		else{
			transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
		}

		//hyokkaaminen
		if(atAttackPosition == true){
			if (spitInterval <= 0){
				Debug.Log("Spittaa");
                audioSource.clip = BabySpitterSplash;
				audioSource.Play();
                Instantiate(SmallSpit, transform.position, Quaternion.identity);
                spitInterval = spitCountdown;
			}
			else {
                spitInterval--;
			}
		}
	}

	public void SurviveCheck(){
        if (health <= 0){
            BuddySpawnerB.spitterBOlemassa = false;
            Destroy(gameObject);
        }
    }
}