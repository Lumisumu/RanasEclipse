using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Button resumeGame;
	public Button backToMainMenu;
	public LevelLoader loadingScript;
	public GameObject GameOverUI;
	public GameObject LoadingUI;

	void Start () {
		LoadingUI.SetActive(false);
		GameOverUI.SetActive(true);

		Button resume = resumeGame.GetComponent<Button>();
		Button back = backToMainMenu.GetComponent<Button>();

		resume.onClick.AddListener(Resume);
		back.onClick.AddListener(Back);

		loadingScript.StartLoading();
	}

	public void Resume () {
		Debug.Log("GameOver>Resume");
		GameOverUI.SetActive(false);
		LoadingUI.SetActive(true);
		loadingScript.ActivateScene();
		//SceneManager.LoadScene("testScene_1");
	}

	public void Back () {
		Debug.Log("GameOver>MainMenu");
		GameOverUI.SetActive(false);
		LoadingUI.SetActive(true);
		SceneManager.LoadScene("MainMenu");
	}
}
