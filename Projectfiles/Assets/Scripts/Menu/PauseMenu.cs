using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused;

    public GameObject gameUI;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuButtons;
    public GameObject wantToQuit;

    public Button pauseButton;
    public AudioMixer audioMixer;
	public Button mainMenu;
	public Button resume;
    public Button yesQuit;
    public Button dontQuit;

    private float currentVolume;

    void Start () {
        Resume();

        Button resu = resume.GetComponent<Button>();
        Button pause = pauseButton.GetComponent<Button>();
        Button yes = yesQuit.GetComponent<Button>();
        Button no = dontQuit.GetComponent<Button>();

        pause.onClick.AddListener(Pause);
        resu.onClick.AddListener(Resume);
        yes.onClick.AddListener(Quit);
        no.onClick.AddListener(NoQuit);
    }

   void Resume () {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        audioMixer.SetFloat("mastervolume", currentVolume);
        GameIsPaused = false;
    }

    void Pause () {
        gameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        pauseMenuButtons.SetActive(true);
        wantToQuit.SetActive(false);
        Time.timeScale = 0f;
        audioMixer.SetFloat("mastervolume", -80f);
        GameIsPaused = true;
    }

    public void Quit ()
    {
        Debug.Log("PauseMenu: Back");
        audioMixer.SetFloat("mastervolume", 0f);
        SceneManager.LoadScene("MainMenu");
    }

    public void NoQuit ()
    {
        pauseMenuButtons.SetActive(true);
        wantToQuit.SetActive(false);
    }

    public void GoBack () {
        pauseMenuButtons.SetActive(false);
        wantToQuit.SetActive(true);
    }
	
	public void SetMasterVolume (float volume){
		audioMixer.SetFloat("mastervolume", volume);
        Debug.Log("Säädetään ääntä pausemenussa");
        currentVolume = volume;
        audioMixer.SetFloat("mastervolume", -80f);
	}

}
