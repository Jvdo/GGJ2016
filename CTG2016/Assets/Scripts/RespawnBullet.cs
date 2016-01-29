using UnityEngine;
using System.Collections;

public class RespawnBullet : MonoBehaviour
{
	public GameObject green;
	public GameObject red;
	public GameObject blue;
	public Vector3 spawnValues;

	void Start ()
	{
		
        
        
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.G)) {
			Instantiate (green);
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Instantiate (red);
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			Instantiate (blue);
		}

	}

}