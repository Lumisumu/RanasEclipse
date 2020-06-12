using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{

    public bool RedKey, BlueKey, GreenKey;

    public GameObject GreenKeyUI;
    public GameObject RedKeyUI;
    public GameObject BlueKeyUI;



    void Start()
    {
        GreenKeyUI.SetActive(false);
        RedKeyUI.SetActive(false);
        BlueKeyUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            if (other.GetComponent<KeyPickUp>().Red == true)
            {
                RedKeyUI.SetActive(true);
                RedKey = true;
            }
            if (other.GetComponent<KeyPickUp>().Blue == true)
            {
                BlueKeyUI.SetActive(true);
                BlueKey = true;
            }
            if (other.GetComponent<KeyPickUp>().Green == true)
            {
                GreenKeyUI.SetActive(true);
                GreenKey = true;
            }
            Destroy(other.gameObject);
        }
    }
}
