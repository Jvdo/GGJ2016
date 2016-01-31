using UnityEngine;
using System.Collections;

public class EggEffect : MonoBehaviour {

	public Transform eggPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayEffect(Vector3 position)
	{
		Transform t = Instantiate(eggPrefab);
		t.position = position;
	}
}
