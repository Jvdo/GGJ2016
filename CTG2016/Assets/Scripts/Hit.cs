using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	public AudioSource hit;
	public GameObject quad;
	Enemy enemy;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy>();
		if (quad)
		{
			quad.GetComponent<Renderer>().enabled = false;
		}

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
		if (quad)
		{
			quad.GetComponent<Renderer> ().enabled = true;
		}
	}

	void DestroyObject(){		

		Destroy(gameObject); 
	}
}
