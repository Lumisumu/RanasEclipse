using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSmallspitProjectile : MonoBehaviour {

	public float destroyTimer;
	public float speed;
	public float goDown;

	private Transform player;
	private Vector2 target;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		target = new Vector2(player.position.x, player.position.y);
	}

	void Update () {
		if(destroyTimer <= 0){
			Destroy(gameObject);
		}
		if(transform.position.x != target.x && transform.position.y != target.y){
			transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
		}

		destroyTimer--;
	}
}