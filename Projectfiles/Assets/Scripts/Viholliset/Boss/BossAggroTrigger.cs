using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAggroTrigger : MonoBehaviour {

	GameObject boss;
	BossSpitter bossScript;

	GameObject spawnerA;
	GameObject spawnerB;
	GameObject spawnerC;
	BuddySpawnerA BuddySpawnerA;
	BuddySpawnerB BuddySpawnerB;
	BuddySpawnerC BuddySpawnerC;

	void Start () {
		boss = GameObject.FindGameObjectWithTag("Boss");
		bossScript = boss.GetComponent<BossSpitter>();

		spawnerA = GameObject.FindGameObjectWithTag("spawnerA");
		spawnerB = GameObject.FindGameObjectWithTag("spawnerB");
		spawnerC = GameObject.FindGameObjectWithTag("spawnerC");
		BuddySpawnerA = spawnerA.GetComponent<BuddySpawnerA>();
		BuddySpawnerB = spawnerB.GetComponent<BuddySpawnerB>();
		BuddySpawnerC = spawnerC.GetComponent<BuddySpawnerC>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("BossAggro")){
			Debug.Log("Boss Trigger Successful!");
			bossScript.aggro = true;
			BuddySpawnerA.aggro = true;
			BuddySpawnerB.aggro = true;
			BuddySpawnerC.aggro = true;
            Destroy(other.gameObject);
		}
		else{
			Debug.Log("VIRHE BOSS TRIGGERISSA");
		}
	}
}
