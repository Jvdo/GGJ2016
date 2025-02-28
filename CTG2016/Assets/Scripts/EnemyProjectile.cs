﻿using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	PlayerBehaviour player;

	public float velocity = 1.0f;
	public float damage = 1.0f;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerBehaviour>() as PlayerBehaviour;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 diff = player.transform.position - transform.position;

		Vector3 dir = diff.normalized * velocity * Time.deltaTime;
		if (dir.sqrMagnitude > diff.sqrMagnitude)
		{
			dir = diff;
		}

		transform.position = transform.position + dir;

		if (dir.magnitude <= 0.1f)
		{
			player.OnHit(damage);
			Destroy(gameObject);
		}
	}
}
