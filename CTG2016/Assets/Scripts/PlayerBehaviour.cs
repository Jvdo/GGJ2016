using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public int health;

	public GameObject Red;
	public GameObject Green;
	public GameObject Blue;


	// Use this for initialization
	void Start () {
		
		health = 100;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.H)) {
			
			health -= 1;
		}


	
	}
}
