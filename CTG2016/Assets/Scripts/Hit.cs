using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	public AudioSource hit;

	Enemy enemy;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (enemy)
		{
			enemy.StartDie();
		}

		hit.Play ();
		Destroy(other.gameObject);
		Invoke ("DestroyObject", 1f);

	}

	void DestroyObject(){		

		Destroy(gameObject); 
	}
}
