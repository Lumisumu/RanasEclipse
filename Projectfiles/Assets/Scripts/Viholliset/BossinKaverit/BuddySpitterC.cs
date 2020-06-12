using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BuddySpitterC : MonoBehaviour {

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

	GameObject spawnerC;
	BuddySpawnerC BuddySpawnerC;

	void Start () {
		aggro = false;
		atAttackPosition = false;
		spitInterval = spitCountdown;

		spawnPoint = GameObject.FindGameObjectWithTag("spawnerC").GetComponent<Transform>();
		spitPoint = GameObject.FindGameObjectWithTag("SpitPointC").GetComponent<Transform>();
		destination = new Vector2(spitPoint.position.x, spitPoint.position.y);

		spawnerC = GameObject.FindGameObjectWithTag("spawnerC");
		BuddySpawnerC = spawnerC.GetComponent<BuddySpawnerC>();
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
            BuddySpawnerC.spitterCOlemassa = false;
            Destroy(gameObject);
        }
    }
}
