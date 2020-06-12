using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

	public AudioSource audioSource;
	public int currentMusic;

	public AudioClip firstOverworld; //nro 1
	public AudioClip secondOverworld; //nro 2
	public AudioClip firstCave; //nro 3
	public AudioClip secondCave; //nro 4
	public AudioClip bossMusic; //nro 5
	public AudioClip secretRuins; //nro 6
	public AudioClip deepestCave; //nro 7
	public AudioClip poisonPool; // nro 8
	

	void Start () {
		audioSource.clip = firstOverworld;
		audioSource.Play();
		currentMusic = 1;
	}

	void Update () { 
		//Alun overworld alue
		if(transform.position.x < 305 && transform.position.y > -30){
			if(currentMusic != 1){
				Debug.Log("MUSIC-CHANGE: 1st overworld");
				currentMusic = 1;
				audioSource.clip = firstOverworld;
				audioSource.Play();
			}
		}

		//Toinen overworld alue
		if(transform.position.x > 305 && transform.position.y > -52){
			if(currentMusic != 2){
				Debug.Log("MUSIC-CHANGE: 2nd overworld");
				currentMusic = 2;
				audioSource.clip = secondOverworld;
				audioSource.Play();
			}
		}

		//Luolan vasen osa
		if(transform.position.x < 308 && transform.position.y < -35){
			if(transform.position.x > -87 && transform.position.y > -107){
				if(currentMusic != 3){
					Debug.Log("MUSIC-CHANGE: cave-leftside");
					currentMusic = 3;
					audioSource.clip = firstCave;
					audioSource.Play();
				}
			}
		}

		//Luolan oikea osa
		if(transform.position.x > 308 && transform.position.y < -60){
			if(currentMusic != 4){
				Debug.Log("MUSIC-CHANGE: cave-rightside");
				currentMusic = 4;
				audioSource.clip = secondCave;
				audioSource.Play();
			}
		}

		//Bossialue
		if(transform.position.x > 198 && transform.position.y < -240){
			if(currentMusic != 5){
				Debug.Log("MUSIC-CHANGE: bossroom");
				currentMusic = 5;
				audioSource.clip = bossMusic;
				audioSource.Play();
			}
		}

		//Secret ruins alue vasemmalla
		if(transform.position.x < -85 && transform.position.y > -119){
			if(transform.position.x < -92 && transform.position.y < -40){
				if(currentMusic != 6){
					Debug.Log("MUSIC-CHANGE: secret ruins");
					currentMusic = 6;
					audioSource.clip = secretRuins;
					audioSource.Play();
				}
			}
		}

		//Luolan syvin kohta
		if(transform.position.x > -145 && transform.position.y < -147){
			if(transform.position.x < 136){
				if(currentMusic != 7){
					Debug.Log("MUSIC-CHANGE: deepest part");
					currentMusic = 7;
					audioSource.clip = deepestCave;
					audioSource.Play();
				}
			}
		}

		//Myrkky altaat
		if(transform.position.x > 136 && transform.position.y > -195){
			if(transform.position.x < 350 && transform.position.y < -131){
				if(currentMusic != 8){
					Debug.Log("MUSIC-CHANGE: poison pools");
					currentMusic = 8;
					audioSource.clip = poisonPool;
					audioSource.Play();
				}
			}
		}
	}
	
	
}

//ASETA MAIN CAMERALLE

//Musiikki vaihtuu alueen trigger-colliderin mukaan
	/*void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("overworldMusicTrigger")) {
			if(currentMusic != 1){
				audioSource.Pause();
				audioSource.clip = overworldMusic;
				audioSource.Play();
				currentMusic = 1;
			}
		}

		if(other.CompareTag("caveMusicTrigger")) {
			if(currentMusic != 2){
				audioSource.Pause();
				audioSource.clip = caveMusic;
				audioSource.Play();
				currentMusic = 2;
			}
		}

		if(other.CompareTag("bossMusicTrigger")) {
			if(currentMusic != 3){
				audioSource.Pause();
				audioSource.clip = bossMusic;
				audioSource.Play();
				currentMusic = 3;
			}
		}*/
