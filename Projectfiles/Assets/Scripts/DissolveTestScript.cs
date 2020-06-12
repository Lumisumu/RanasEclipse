using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveTestScript : MonoBehaviour {

    // Use this for initialization
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("MyShaders/dissolve2D");
    }
	
	// Update is called once per frame
	void Update () {
		
            float tre = Mathf.PingPong(Time.time, 1.0f);
            rend.material.SetFloat("_Threshold", tre);

        
	}
}
