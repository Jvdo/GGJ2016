using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {

	int[] difficultyLevels = new int[3];
	// Use this for initialization
	void Start () {
		for (int i = 0; i < difficultyLevels.Length; ++i)
		{
			difficultyLevels[i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnemyDestroyed(Enemy enemy)
	{
		difficultyLevels[enemy.id]++;
	}

	public void OnDamageTake(Enemy enemy)
	{
		difficultyLevels[enemy.id] = 0;
	}
			
}
