using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spyderphysics : MonoBehaviour {

    Animator anim;
    Rigidbody2D spyderrigi;
    public float speed;
    private Vector2 suunta, suunta2;
    public GameObject prefabPE;
    AudioSource audioSource;


    // Use this for initialization
    void Start () {
        
        anim = GetComponent<Animator>();
        spyderrigi = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        suunta = Vector2.left;
        anim.SetBool("Walkinks", true);
    }
	
	// Update is called once per frame
	void Update () {

        spyderrigi.transform.Translate(suunta * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("MoveLeft"))
        {
            audioSource.mute = true;
            suunta = Vector2.zero;
            // Tähän koodi jolla Animaation vaihto idleen
            StartCoroutine(Wait_Left());
            
        }

        if (collision.gameObject.CompareTag("MoveRight"))
        {
            audioSource.mute = true;
            suunta = Vector2.zero;
            //Tähän koodi jolla Animaation vaihto idleen
            StartCoroutine(Wait_Right());
            
        }

        if (collision.gameObject.CompareTag("shot"))
        {
            GameObject cloneprefabPE = Instantiate(prefabPE, gameObject.transform.position, transform.rotation);
            Destroy(cloneprefabPE, 2);
        }

        if (collision.gameObject.CompareTag("Player") && suunta != Vector2.zero)
        {
            audioSource.mute = true;
            suunta2 = suunta;
            suunta = Vector2.zero;
            StartCoroutine(JustWaitASec());
            
        }
    }


    IEnumerator Wait_Left()
    {
        anim.SetBool("Walkinks", false);
        yield return new WaitForSeconds(2);
        anim.SetBool("Walkinks", true);
        audioSource.mute = false;
        //Animaation vaihto liikkumiseen
        //Tähän koodi joka kääntää spriten
        transform.localScale = new Vector3(2, 2, 1);
        suunta = Vector2.left;
    }

    IEnumerator Wait_Right()
    {
        anim.SetBool("Walkinks", false);
        yield return new WaitForSeconds(2);
        anim.SetBool("Walkinks", true);
        audioSource.mute = false;
        //Tähän koodi joka kääntää spriten 
        //Animaation vaihto liikkumiseen
        transform.localScale = new Vector3(-2, 2, 1);
        suunta = Vector2.right;
    }

    IEnumerator JustWaitASec()
    {
        anim.SetBool("Walkinks", false);
        yield return new WaitForSeconds(2);
        anim.SetBool("Walkinks", true);
        suunta = suunta2;
        audioSource.mute = false;
    }
}
