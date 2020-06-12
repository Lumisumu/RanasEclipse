using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	//public GameObject player;
	//DamageManager damageMangr;

	public float baseDamage = 2;
	public float damageMultip;
	public float totalDamage;

    public float lifeTime = 0.5f;


    void Start () {
        //player = GameObject.FindGameObjectWithTag("Player");
        //damageMangr = player.GetComponent<DamageManager>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        DamageManager damageMangr = player.GetComponent<DamageManager>();

        damageMultip = damageMangr.damageMultiplier;
        totalDamage = damageMultip * baseDamage;

        Destroy(gameObject, lifeTime);
    }
	
	void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Osuma: " + other);
            other.GetComponent<EnemyHealth>().health -= totalDamage;
            Destroy(gameObject);
        }

        else if(other.CompareTag("Boss")){
            Debug.Log("Osuma: " + other);
            other.GetComponent<BossSpitter>().health -= totalDamage;
            Destroy(gameObject);
        }

        else if(other.CompareTag("BuddySpitterA")){
            Debug.Log("Osuma: " + other);
            other.GetComponent<BuddySpitterA>().health -= totalDamage;
            Destroy(gameObject);
        }

        else if(other.CompareTag("BuddySpitterB")){
            Debug.Log("Osuma: " + other);
            other.GetComponent<BuddySpitterB>().health -= totalDamage;
            Destroy(gameObject);
        }

        else if(other.CompareTag("BuddySpitterC")){
            Debug.Log("Osuma: " + other);
            other.GetComponent<BuddySpitterC>().health -= totalDamage;
            Destroy(gameObject);
        }

        else
        {
            Debug.Log("Osuma: " + other);
            Destroy(gameObject);
        }
	}
}
