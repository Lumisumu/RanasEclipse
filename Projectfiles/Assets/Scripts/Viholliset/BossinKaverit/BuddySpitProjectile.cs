using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddySpitProjectile : MonoBehaviour {

	public float destroyTimer;

	void Update () {
		if(destroyTimer <= 0){
			Destroy(gameObject);
		}
		destroyTimer--;
	}
}