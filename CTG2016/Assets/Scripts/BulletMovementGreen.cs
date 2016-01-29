using UnityEngine;
using System.Collections;

public class BulletMovementGreen : MonoBehaviour {

	public Transform target;
	private GameObject targetGreen;

	public float speed;

	// Use this for initialization
	void Start () {

		targetGreen = GameObject.FindWithTag ("EnemyGreen");
		target = targetGreen.transform;
	}

	// Update is called once per frame
	void Update () {

		transform.LookAt (target);		
		transform.Rotate (90, 0, 0);
		transform.Translate(new Vector3(0, -speed, 0)); 

	}
}
