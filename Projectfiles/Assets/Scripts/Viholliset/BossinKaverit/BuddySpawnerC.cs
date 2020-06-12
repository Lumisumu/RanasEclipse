using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddySpawnerC : MonoBehaviour {

	public bool spitterCOlemassa = false;
	public bool aggro;
	public GameObject MinispitterC;

	private Transform player;
	private BossSpitter BossSpitter;

	void Start () {
		aggro = false;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update () {
		if(aggro == true && spitterCOlemassa == false){
			SpawnSpitterC();
		}
	}

	void SpawnSpitterC () {
		Instantiate(MinispitterC, transform.position, Quaternion.identity);
		spitterCOlemassa = true;
	}
}
