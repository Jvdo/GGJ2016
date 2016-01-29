using UnityEngine;
using System.Collections;

public class BulletMovementBlue : MonoBehaviour {

	public Transform target;
	private GameObject targetBlue;

	public float speed;

	// Use this for initialization
	void Start () {

		targetBlue = GameObject.FindWithTag ("EnemyBlue");
		target = targetBlue.transform;
	}

	// Update is called once per frame
	void Update () {

		transform.LookAt (target);		
		transform.Rotate (90, 0, 0);
		transform.Translate(new Vector3(0, -speed, 0)); 

	}
}
