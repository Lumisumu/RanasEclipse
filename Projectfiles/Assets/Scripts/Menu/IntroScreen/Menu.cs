using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour {

    public AudioClip UIClick;
    public AudioMixer audioMixer;
    public LevelLoader loadingScript;
    public GameObject MainUI;
    public GameObject SettingsUI;
    public GameObject LoadingScreenUI;

    public Button begin;
    public Button settings;
    public Button quit;
    public Button extr;
    public Button goback;
    
    void Start()
    {
        MainUI.SetActive(true);
        SettingsUI.SetActive(false);
        LoadingScreenUI.SetActive(false);

        //Main Menu ja Settings
        Button gamestart = begin.GetComponent<Button>();
        Button options = settings.GetComponent<Button>();
        Button exit = quit.GetComponent<Button>();
        Button extras = extr.GetComponent<Button>();
        Button back = goback.GetComponent<Button>();

        gamestart.onClick.AddListener(StartGame);
        exit.onClick.AddListener(QuitGame);
        options.onClick.AddListener(ToggleToSettings);
        extras.onClick.AddListener(Extras);
        back.onClick.AddListener(ToggleToMainMenu);

        loadingScript.StartLoading();
    }

//Main Menu
    public void StartGame(){
        Debug.Log("MainMenu>StartGame");
        MainUI.SetActive(false);
        SettingsUI.SetActive(false);
        LoadingScreenUI.SetActive(true);
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame(){
        Debug.Log("MainMenu>QuitGame");
        Application.Quit();
    }

    public void ToggleToSettings(){
        AudioSource.PlayClipAtPoint(UIClick, new Vector3(0, 0, 0));
        MainUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void Extras(){
        Debug.Log("MainMenu>Extras");
        AudioSource.PlayClipAtPoint(UIClick, new Vector3(0, 0, 0));
        loadingScript.ActivateScene();
        //SceneManager.LoadScene("Extras");
    }

//Settings
	public void SetMasterVolume (float volume){
		audioMixer.SetFloat("mastervolume", volume);
	}

	public void SetMusicVolume (float volume){
		audioMixer.SetFloat("musicvolume", volume);
	}

	public void SetEffectsVolume (float volume){
		audioMixer.SetFloat("effectsvolume", volume);
	}

	public void SetQuality (int qualityIndex){
		QualitySettings.SetQualityLevel(qualityIndex);
	}

    public void ToggleToMainMenu () {
        AudioSource.PlayClipAtPoint(UIClick, new Vector3(0, 0, 0));
        MainUI.SetActive(true);
        SettingsUI.SetActive(false);
    }
}