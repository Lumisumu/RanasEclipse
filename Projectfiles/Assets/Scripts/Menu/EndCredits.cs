using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour {

	public float speed = 0.5f;
	public float autoStartGame = 5000;
	public LevelLoader loadingScript;

	void Start () {
		loadingScript.StartLoading();
	}

	void Update () {
		if(autoStartGame <= 0){
			Debug.Log("EndCredits>MainMenu");
			loadingScript.ActivateScene();
			//SceneManager.LoadScene("MainMenu");
		}
		transform.position += Vector3.up * speed * Time.deltaTime;
		autoStartGame--;
	}
}