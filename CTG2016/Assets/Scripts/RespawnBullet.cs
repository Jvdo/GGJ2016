using UnityEngine;
using System.Collections;

public class RespawnBullet : MonoBehaviour
{
	public GameObject green;
	public GameObject red;
	public GameObject blue;

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

	public void Fire(int enemyId)
	{
		Debug.Log("firing at: " + enemyId);
		switch(enemyId)
		{
		case 0:
			Instantiate(red);
			break;
		case 1:
			Instantiate(green);
			break;
		case 2:
			Instantiate(blue);
			break;
		default:
			Debug.LogWarning("invalid selector in RespawnBullet.Fire!");
			break;
		}
	}
}