using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int id;
	public ComboIndicator comboIndicatorPrefab;
	public Vector3 comboIndicatorOffset = new Vector3(0f, 2f, 0f);

	public EnemySpawnPoint spawnPoint;

	ComboIndicator comboIndicator;

	// Use this for initialization
	void Start () {
		comboIndicator = Instantiate(comboIndicatorPrefab) as ComboIndicator;
		comboIndicator.transform.SetParent(transform);
		comboIndicator.transform.localPosition = comboIndicatorOffset;

		comboIndicator.Initialize(id);

		if (spawnPoint != null)
		{
			spawnPoint.occupied = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy()
	{
		if (spawnPoint != null)
		{
			spawnPoint.occupied = false;
		}
	}
}
