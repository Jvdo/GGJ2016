using UnityEngine;
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
		Vector3 direction = player.transform.position - transform.position;

		transform.position = transform.position + direction.normalized * velocity * Time.deltaTime;

		if (direction.magnitude <= 0.1f)
		{
			player.OnHit(damage);
			Destroy(gameObject);
		}
	}
}
