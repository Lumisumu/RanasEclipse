using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Extras : MonoBehaviour {

	public AudioClip UIClick;
	public LevelLoader loadingScript;
	public GameObject ExtrasMain;
    public GameObject DatabankPage;
	public GameObject SubPages;
	public GameObject menuPart;

	public Button ToDatabank;
    public Button ToCredits;
    public Button BackToMainMenu;
	public Button BackFromDatabank;

	void Start () {
		DatabankPage.SetActive(false);
		SubPages.SetActive(false);
		ExtrasMain.SetActive(true);
		menuPart.SetActive(true);

		//Main
		Button databank = ToDatabank.GetComponent<Button>();
		Button credits = ToCredits.GetComponent<Button>();
		Button mainMenu = BackToMainMenu.GetComponent<Button>();
		Button backA = BackFromDatabank.GetComponent<Button>();

		databank.onClick.AddListener(Databank);
		credits.onClick.AddListener(Credits);
		mainMenu.onClick.AddListener(MainMenu);
		backA.onClick.AddListener(Back);

		loadingScript.StartLoading();
	}

	public void Databank () {
		Debug.Log("Databank>Extras");
		PlayClick();

		DisableView();
		SubPages.SetActive(true);
		DatabankPage.SetActive(true);
	}

	public void Credits () {
		Debug.Log("Extras>Credits");
		PlayClick();
		SceneManager.LoadScene("RollCredits");
	}

	public void MainMenu () {
		Debug.Log("Extras>MainMenu");
		PlayClick();
		loadingScript.ActivateScene();
		//SceneManager.LoadScene("MainMenu");
	}

	public void Back () {
		Debug.Log("SubMenu>Extras");
		PlayClick();

		DisableView();
		ExtrasMain.SetActive(true);
	}

	public void DisableView () {
		DatabankPage.SetActive(false);
		SubPages.SetActive(false);
		ExtrasMain.SetActive(false);
	}

	public void PlayClick () {
		AudioSource.PlayClipAtPoint(UIClick, new Vector3(0, 0, 0));
	}
}
