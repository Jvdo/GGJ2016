using UnityEngine;
using System.Collections;

public class EnemySpawnPoint : MonoBehaviour {

	public bool occupied;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos()
	{
		if (occupied)
		{
			Gizmos.color = new Color(0.8f, 0.2f, 0.2f);
		}
		else
		{
			Gizmos.color = new Color(0.2f, 0.8f, 0.2f);
		}
		Gizmos.DrawWireSphere(transform.position, 1f);
	}
}
