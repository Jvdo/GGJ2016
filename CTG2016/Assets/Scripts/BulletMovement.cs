using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	private Transform target;

	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		transform.LookAt (target);		
		transform.Rotate (55, 0, 0);
		transform.Translate(new Vector3(0, -speed, 0)); 
	
	}

	public void SetTarget(Transform t)
	{
		target = t;
	}
}
