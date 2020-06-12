using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour {

	public float health;
	public GameObject healthOrb;
	public int loot;

	void Start () {
		loot = Random.Range(0, 4);
	}

	void Update () {
		if(health <= 0){
			Debug.Log("Small enemy died!");
			DropLoot();
			Die();
		}
	}

	void DropLoot () {
		if(loot == 0){
			return;
		}
		else if(loot == 1){
			SpawnHealthOrb();
		}
		else if(loot == 2){
			SpawnHealthOrb();
		}
		else if(loot == 3){
			SpawnHealthOrb();
		}
		else if(loot == 4){
			SpawnHealthOrb();
			SpawnHealthOrb();
		}
		else{
			Debug.Log("Arvottu loottiluku alueen ulkopuolella.");
		}
	}

	void SpawnHealthOrb () {
		Instantiate(healthOrb, transform.position, Quaternion.identity);
	}

	void Die () {
		Destroy(gameObject);
	}
}