using UnityEngine;
using System.Collections;

public class RespawnBullet : MonoBehaviour
{
	public BulletMovement green;
	public BulletMovement red;
	public BulletMovement blue;

	public AudioSource sparkles;

	public GameObject Emitter;

	void Start ()
	{
		
        
        
	}

	void Update() {
		/*
		if (Input.GetKeyDown (KeyCode.G)) {
			Instantiate (green);
			green.transform.position = Emitter.transform.position;

		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Instantiate (red);
			red.transform.position = Emitter.transform.position;
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			Instantiate (blue);
			blue.transform.position = Emitter.transform.position;
		}
		*/
	}

	public void Fire(Enemy enemy)
	{
		Debug.Log("firing at: " + enemy.id);
		enemy.hasBeenFiredAt = true;

		BulletMovement bullet = null;

		switch(enemy.id)
		{
		case 0:
			bullet = Instantiate (red) as BulletMovement;
			sparkles.Play ();
			break;
		case 1:
			bullet = Instantiate(green) as BulletMovement;
			sparkles.Play ();
			break;
		case 2:
			bullet = Instantiate(blue) as BulletMovement;
			sparkles.Play ();
			break;
		default:
			Debug.LogWarning("invalid selector in RespawnBullet.Fire!");
			break;
		}

		bullet.SetTarget(enemy.transform);
	}

}