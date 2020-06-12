using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PowerUp : MonoBehaviour {
	private GameObject player;
    private GameObject UI;
	HealthManager healthMangr;
	DamageManager damageMangr;
    HealthBar healthBar;

    public GameObject gameUI;
	public GameObject powerUpUI;
	public Button chooseHealth;
	public Button chooseDamage;
	public bool choiceMade;
    bool imHit = false;

	void Start () {
		powerUpUI.SetActive(false);
		choiceMade = false;
		player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("HealthBarUI");
		healthMangr = player.GetComponent<HealthManager>();
		damageMangr = player.GetComponent<DamageManager>();
        healthBar = UI.GetComponent<HealthBar>();

		//Button health = chooseHealth.GetComponent<Button>();
		//Button damage = chooseDamage.GetComponent<Button>();
		//health.onClick.AddListener(HealthChosen);
		//damage.onClick.AddListener(DamageChosen);

	}
	
	void Update () {
		if(choiceMade == true && imHit == true) {
            Destroy(gameObject);
        }
	}

	void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("PowerUp collided");
		if(other.CompareTag("Player")) {
            Button health = chooseHealth.GetComponent<Button>();
            Button damage = chooseDamage.GetComponent<Button>();
            health.onClick.AddListener(HealthChosen);
            damage.onClick.AddListener(DamageChosen);
            imHit = true;
            gameUI.SetActive(false);
            powerUpUI.SetActive(true);
			Time.timeScale = 0f;
		}
	}

	public void HealthChosen () {
        choiceMade = true;
        healthMangr.maxHp += 25;
        healthBar.maxHP += 25;
		healthMangr.currentHp = healthMangr.maxHp;
		Time.timeScale = 1f;
		powerUpUI.SetActive(false);
        gameUI.SetActive(true);
        PlayerUIManager.Instance.UpdatePlayerHpBar(healthMangr.currentHp);
    }

	public void DamageChosen () {
        choiceMade = true;
        damageMangr.damageMultiplier += 1;
        healthMangr.currentHp = healthMangr.maxHp;
        Time.timeScale = 1f;
		powerUpUI.SetActive(false);
        gameUI.SetActive(true);
    }


}
