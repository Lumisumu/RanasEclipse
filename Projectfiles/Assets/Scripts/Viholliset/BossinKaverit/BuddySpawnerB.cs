using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddySpawnerB : MonoBehaviour {

	public bool spitterBOlemassa = false;
	public bool aggro;
	public GameObject MinispitterB;

	private Transform player;
	private BossSpitter BossSpitter;

	void Start () {
		aggro = false;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update () {
		if(aggro == true && spitterBOlemassa == false){
			SpawnSpitterB();
		}
	}

	void SpawnSpitterB () {
		Instantiate(MinispitterB, transform.position, Quaternion.identity);
		spitterBOlemassa = true;
	}
}
