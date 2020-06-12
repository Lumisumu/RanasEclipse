using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Credits : MonoBehaviour {

    public AudioClip UIClick;
    public AudioMixer audioMixer;

    public Button goback;
    public LevelLoader loadingScript;
    
    void Start()
    {
        Button back = goback.GetComponent<Button>();

        back.onClick.AddListener(ToggleToMainMenu);
    }

//Main Menu
    

    public void ToggleToMainMenu () {
        Debug.Log("EndCredits>MainMenu");
        AudioSource.PlayClipAtPoint(UIClick, new Vector3(0, 0, 0));
        loadingScript.ActivateScene();
        //SceneManager.LoadScene("MainMenu");
    }
}