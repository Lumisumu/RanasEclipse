using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	public Button goback;
    public LevelLoader loadingScript;
    public GameObject introUI;
    public GameObject loadingUI;

	void Start () {
        loadingUI.SetActive(false);
        introUI.SetActive(true);
		Button back = goback.GetComponent<Button>();

        back.onClick.AddListener(ToggleToMainMenu);
	}
	
	public void ToggleToMainMenu () {
        Debug.Log("Intro>SkipToGame");
        introUI.SetActive(false);
        loadingUI.SetActive(true);
        loadingScript.ActivateScene();
        //SceneManager.LoadScene("testScene_1");
    }
}
