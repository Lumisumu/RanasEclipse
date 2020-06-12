using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

	public string levelName;
	AsyncOperation async;

	public void StartLoading () {
		StartCoroutine("load");
	}

	IEnumerator load () {
		Debug.LogWarning("ASYNC LOAD STARTED -" + "DO NOT EXIT PLAY MODE OR UNITY CRASHES");
		async = Application.LoadLevelAsync(levelName);
		async.allowSceneActivation = false;
		yield return async;
	}

	public void ActivateScene () {
		async.allowSceneActivation = true;
	}

	void OnColliderEnter (Collider2D other){
		StartLoading();
	}
}
