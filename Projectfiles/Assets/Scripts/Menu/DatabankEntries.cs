using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class DatabankEntries : MonoBehaviour {

	public AudioClip UIClick;

	public GameObject DataEntry0;
	public GameObject DataEntry1;
	public GameObject DataEntry2;
	public GameObject DataEntry3;
	public GameObject DataEntry4;
	public GameObject DataEntry5;
	public GameObject DataEntry6;
	public GameObject DataEntry7;
	public GameObject DataEntry8;
	public GameObject DataEntry9;
	public GameObject DataEntry10;
	public GameObject DataEntry11;

	public Button DataButton1;
	public Button DataButton2;
	public Button DataButton3;
	public Button DataButton4;
	public Button DataButton5;
	public Button DataButton6;
	public Button DataButton7;
	public Button DataButton8;
	public Button DataButton9;
	public Button DataButton10;
	public Button DataButton11;

	public Button backbutton;

	void Start () {
		HideAllEntries();
		DataEntry0.SetActive(true);

		Button entry1 = DataButton1.GetComponent<Button>();
		Button entry2 = DataButton2.GetComponent<Button>();
		Button entry3 = DataButton3.GetComponent<Button>();
		Button entry4 = DataButton4.GetComponent<Button>();
		Button entry5 = DataButton5.GetComponent<Button>();
		Button entry6 = DataButton6.GetComponent<Button>();
		Button entry7 = DataButton7.GetComponent<Button>();
		Button entry8 = DataButton8.GetComponent<Button>();
		Button entry9 = DataButton9.GetComponent<Button>();
		Button entry10 = DataButton10.GetComponent<Button>();
		Button entry11 = DataButton11.GetComponent<Button>();
		Button back = backbutton.GetComponent<Button>();

		entry1.onClick.AddListener(Entry1);
		entry2.onClick.AddListener(Entry2);
		entry3.onClick.AddListener(Entry3);
		entry4.onClick.AddListener(Entry4);
		entry5.onClick.AddListener(Entry5);
		entry6.onClick.AddListener(Entry6);
		entry7.onClick.AddListener(Entry7);
		entry8.onClick.AddListener(Entry8);
		entry9.onClick.AddListener(Entry9);
		entry10.onClick.AddListener(Entry10);
		entry11.onClick.AddListener(Entry11);
		back.onClick.AddListener(ToggleBack);
	}

	//Entry-funktiot, jotka asettavat sisallon nakyviin
	public void Entry1 () { HideAllEntries(); PlayClick(); DataEntry1.SetActive(true); }
	public void Entry2 () { HideAllEntries(); PlayClick(); DataEntry2.SetActive(true); }
	public void Entry3 () { HideAllEntries(); PlayClick(); DataEntry3.SetActive(true); }
	public void Entry4 () { HideAllEntries(); PlayClick(); DataEntry4.SetActive(true); }
	public void Entry5 () { HideAllEntries(); PlayClick(); DataEntry5.SetActive(true); }
	public void Entry6 () { HideAllEntries(); PlayClick(); DataEntry6.SetActive(true); }
	public void Entry7 () { HideAllEntries(); PlayClick(); DataEntry7.SetActive(true); }
	public void Entry8 () { HideAllEntries(); PlayClick(); DataEntry8.SetActive(true); }
	public void Entry9 () { HideAllEntries(); PlayClick(); DataEntry9.SetActive(true); }
	public void Entry10 () { HideAllEntries(); PlayClick(); DataEntry10.SetActive(true); }
	public void Entry11 () { HideAllEntries(); PlayClick(); DataEntry11.SetActive(true); }
	
	public void HideAllEntries () {
		DataEntry0.SetActive(false);
		DataEntry1.SetActive(false);
		DataEntry2.SetActive(false);
		DataEntry3.SetActive(false);
		DataEntry4.SetActive(false);
		DataEntry5.SetActive(false);
		DataEntry6.SetActive(false);
		DataEntry7.SetActive(false);
		DataEntry8.SetActive(false);
		DataEntry9.SetActive(false);
		DataEntry10.SetActive(false);
		DataEntry11.SetActive(false);
	}

	public void PlayClick () { 
		AudioSource.PlayClipAtPoint(UIClick, new Vector3(0, 0, 0)); 
	}

	public void ToggleBack () {
		HideAllEntries();
		DataEntry0.SetActive(true);
	}
}
