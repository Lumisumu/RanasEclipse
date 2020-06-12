using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        TouchManager.OnSwipe += SwipenKuuntelija;
    }

    void OnDisable()
    {
        TouchManager.OnSwipe -= SwipenKuuntelija;
    }

    void SwipenKuuntelija(string suunta)
    {
        Debug.Log("SwipeListener called " + suunta);
    }
}
