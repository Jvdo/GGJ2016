using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float maxHealth = 100;
	public float health = 100;

	public GameObject Red;
	public GameObject Green;
	public GameObject Blue;


	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.H)) {
			
			health -= 1;
		}
	}

	public void OnHit(float damage)
	{
		health -= damage;

		if (health <= 0f)
		{
			print("TODO: game over");
		}
	}
}
