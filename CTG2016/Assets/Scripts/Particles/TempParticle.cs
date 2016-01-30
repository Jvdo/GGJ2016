using UnityEngine;
using System.Collections;

public class TempParticle : MonoBehaviour {

	public float lifeTime = 2.0f;

	float timeAlive = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeAlive += Time.deltaTime;

		if (timeAlive >= lifeTime)
		{
			Destroy(gameObject);
		}
	}
}
