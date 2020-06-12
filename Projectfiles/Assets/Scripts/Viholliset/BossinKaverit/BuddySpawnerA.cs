using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddySpawnerA : MonoBehaviour {

	public bool spitterAOlemassa = false;
	public bool aggro;
	public GameObject MinispitterA;

	private Transform player;
	private BossSpitter BossSpitter;

	void Start () {
		aggro = false;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update () {
		if(aggro == true && spitterAOlemassa == false){
			SpawnSpitterA();
		}
	}

	void SpawnSpitterA () {
		Instantiate(MinispitterA, transform.position, Quaternion.identity);
		spitterAOlemassa = true;
	}
}
