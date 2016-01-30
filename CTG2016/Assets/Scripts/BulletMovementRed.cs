using UnityEngine;
using System.Collections;

public class BulletMovementRed : MonoBehaviour {

	public Transform target;
	private GameObject targetRed;

	public float speed;

	// Use this for initialization
	void Start () {
		
		targetRed = GameObject.FindWithTag ("EnemyRed");
		target = targetRed.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.LookAt (target);		
		transform.Rotate (90, 0, 0);
		transform.Translate(new Vector3(0, -speed, 0)); 
	
	}


}
