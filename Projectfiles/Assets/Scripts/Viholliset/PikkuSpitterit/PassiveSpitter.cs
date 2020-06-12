using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PassiveSpitter : MonoBehaviour
{

    public bool aggro;
    public float spitCountdown = 100;
    public float spitInterval;
    public GameObject SmallSpit;

    public AudioSource audioSource;
    public AudioMixer audioMixer;
    public AudioClip BabySpitterSplash;

    private Transform target;

    public GameObject prefabPE;

    void Start()
    {
        aggro = false;
        spitInterval = spitCountdown;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (target.position.x - transform.position.x < 20 && transform.position.x - target.position.x < 20)
        {
            if (target.position.y - transform.position.y < 20 && transform.position.y - target.position.y < 20)
            {
                aggro = true;
            }
        }
        else
        {
            aggro = false;
        }

        if (aggro == true)
        {
            if (spitInterval <= 0)
            {
                Debug.Log("Spittaa");
                //anim.Play("ANIMAATION NIMI"); //hyokkaysanimaatio
                audioSource.clip = BabySpitterSplash;
                audioSource.Play();
                Instantiate(SmallSpit, transform.position, Quaternion.identity);
                spitInterval = spitCountdown;
                //anim.Play("ANIMAATION NIMI"); //idle-animaatio
            }
            else
            {
                spitInterval--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("shot"))
        {
            GameObject cloneprefabPE = Instantiate(prefabPE, gameObject.transform.position, transform.rotation);
            Destroy(cloneprefabPE, 2);
        }
    }
}
