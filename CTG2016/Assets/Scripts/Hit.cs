using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	public AudioSource hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		hit.Play ();
		Destroy(other.gameObject);
		Invoke ("DestroyObject", 1f);

	}

	void DestroyObject(){		

		Destroy(gameObject); 
	}
}
