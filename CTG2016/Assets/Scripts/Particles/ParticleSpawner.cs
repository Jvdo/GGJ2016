using UnityEngine;
using System.Collections;

public class ParticleSpawner : MonoBehaviour {

	public Transform beesParticle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnBeesParticles(Vector3 position)
	{
		Transform t = Instantiate(beesParticle);
		t.position = position;
	}
}
