using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AgressiveSpitter : MonoBehaviour {

	public bool aggro;
	public float spitCountdown = 100;
	public float spitInterval;
	public GameObject SmallSpit;

	public AudioSource audioSource;
	public AudioMixer audioMixer;
	public AudioClip BabySpitterSplash;

	void Start () {
		aggro = false;
		spitInterval = spitCountdown;
	}
	
	void Update () {
		if(aggro == true){
			if (spitInterval <= 0){
				Debug.Log("Spittaa");
                    //anim.Play("ANIMAATION NIMI"); //hyokkaysanimaatio
					audioSource.clip = BabySpitterSplash;
					audioSource.Play();
                    Instantiate(SmallSpit, transform.position, Quaternion.identity);
                    spitInterval = spitCountdown;
                    //anim.Play("ANIMAATION NIMI"); //idle-animaatio
			}
			else {
                spitInterval--;
			}
		}
	}
}
