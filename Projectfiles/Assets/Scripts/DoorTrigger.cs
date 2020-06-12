using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    public GameObject thePlayer;
    public bool Red, Blue, Green;
    public float doorSpeed;
    private bool BoolDoor = false;
    public float TravelDistance = 5;
    [HideInInspector]
    public Vector2 TargetPos2;


    public AudioSource audioSource;
    public AudioClip doorSound;
    public bool soundPlayed;

    // Use this for initialization
    void Start () {
        soundPlayed = false;
        TargetPos2 = new Vector2(transform.parent.position.x, transform.parent.position.y + TravelDistance);
    }
	
	// Update is called once per frame
	void Update () {

        if (BoolDoor == true)
        {
            OpenDoor();
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {  
            if (Red == true && thePlayer.GetComponent<KeyManager>().RedKey == true || Blue == true && thePlayer.GetComponent<KeyManager>().BlueKey == true || Green == true && thePlayer.GetComponent<KeyManager>().GreenKey == true)
            {
                BoolDoor = true;
            }
        }
    }


    void OpenDoor()
    {
        //audioSource.clip = doorSound;
        //audioSource.Play();
        if(soundPlayed == false)
        {
            Debug.Log("Door sound played!");
            soundPlayed = true;
            audioSource.PlayOneShot(doorSound, 0.5f);
        }

        float step = doorSpeed * Time.deltaTime;
        transform.parent.position = Vector2.MoveTowards(transform.parent.position, TargetPos2, step);
    }
}
