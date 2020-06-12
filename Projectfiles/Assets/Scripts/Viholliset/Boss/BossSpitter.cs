using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class BossSpitter : MonoBehaviour {

	public bool aggro;
    public float health;
    public float spitInterval;
	public float spitCountdown;
	public float growlInterval;
	public float growlCountdown;

	public GameObject Spitball;
	public int firstRoar;
    public bool deathRoar;

    Animator anim;
    public AudioSource audioSource;
	public AudioMixer audioMixer;
	public AudioClip SpitterRoar;
	public AudioClip SpitterGrowl;
	public AudioClip SpitterSpits;

    public Vector3 spitSpawn;
    private Transform target;


	void Start () {
        deathRoar = false;
		firstRoar = 0;
		aggro = false;
        //canSpit = true;
		spitInterval = spitCountdown;
		growlInterval = growlCountdown;
        anim = GetComponent<Animator>();
    }

    void Update () {
        if(health <= 0){
            StartCoroutine(Die());
        }

		if(aggro == true && firstRoar != 1){
			audioSource.clip = SpitterRoar;
			audioSource.Play();
			firstRoar = 1;
		}

		if(aggro == true){
                if (spitInterval <= 0){
                    Debug.Log("Spittaa");
                    StartCoroutine(Hyokkaa());
                    spitInterval = spitCountdown;
                }
				else if(growlInterval <= 0){
					Debug.Log("Growlaa");
					audioSource.clip = SpitterGrowl;
					audioSource.Play();
					growlInterval = growlCountdown;
				}
                else {
					Debug.Log("Ei spittaa, ei growlaa");
                    spitInterval -= Time.deltaTime;
                	spitInterval--;
					growlInterval--;
                }
		}
	}

    IEnumerator Hyokkaa ()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.65f);
        audioSource.clip = SpitterSpits;
        audioSource.Play();
        Instantiate(Spitball, spitSpawn, Quaternion.identity);
        anim.SetBool("Attack", false);
    }

    IEnumerator Die ()
    {
        Debug.Log("Boss died!");
        if(deathRoar == false){
            audioSource.clip = SpitterRoar;
            audioSource.Play();
            deathRoar = true;
        }
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(3.1f);
        anim.SetBool("Dead", false);
        SceneManager.LoadScene("RollCredits");
    }
}
