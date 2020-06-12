using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour {

	public bool playerHasDied;
	
	void Start () {
		playerHasDied = false;
	}
	
	void Update () {
		if(playerHasDied == true){
			SceneManager.LoadScene("GameOverScreen");
		}
	}
}
