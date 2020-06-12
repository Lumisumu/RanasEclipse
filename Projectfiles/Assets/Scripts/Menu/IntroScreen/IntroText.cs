using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour {

	private float speed = 0.45f;
	//public float autoStartGame;
	public LevelLoader loadingScript;

	private float countDown;

	void Start () {
		loadingScript.StartLoading();
		StartCoroutine(StartCounter());
	}

	private IEnumerator StartCounter () {
		countDown = 82f;
		for(int i=0; i < 1000; i++){
			while(countDown >= 0){
				Debug.Log(i++);
				Debug.Log(Time.smoothDeltaTime);
				transform.position += Vector3.up * speed * Time.smoothDeltaTime;
				countDown -= Time.smoothDeltaTime;
				yield return null;
			}
			Debug.Log("Intro>Automatically To Game");
			loadingScript.ActivateScene();
		}
			//Debug.Log("Intro>Automatically To Game");
			//loadingScript.ActivateScene();
	}
	
	/*void Start () {
		loadingScript.StartLoading();
	}

	void Update () {
        Debug.Log(transform.position);
        Debug.Log(speed);
        Debug.Log(Time.deltaTime);
		if (autoStartGame >= 270){
			transform.position += Vector3.up * speed * Time.fixedDeltaTime;
		}

        autoStartGame--;

        if (autoStartGame <= 0){
			Debug.Log("Intro>Automatically To Game");
			loadingScript.ActivateScene();
			//SceneManager.LoadScene("testScene_1");
		}
	}*/
}