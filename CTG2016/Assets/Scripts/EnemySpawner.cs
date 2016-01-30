using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	class Wave
	{
		public Wave(float delay, int enemyType, int count)
		{
			this.delay = delay;
			this.enemyType = enemyType;
			this.count = count;
			this.started = false;
		}

		public float delay;
		public int enemyType;
		public int count;
		public bool started;
	}

	public TextAsset waveConfig;
	public Enemy redEnemyPrefab;
	public Enemy greenEnemyPrefab;
	public Enemy blueEnemyPrefab;

	List<Wave> waves = new List<Wave>();

	float time = 0.0f;
	int waveNum = 0;

	// Use this for initialization
	void Start () {
		Parse();
	}

	void Parse()
	{
		string msg = waveConfig.text;

		string[] lines = msg.Split('\n');
		for (int i = 0; i < lines.Length; ++i)
		{
			string line = lines[i];
			if (line.StartsWith("#"))
			{
				continue;
			}

			if (line.Length == 0)
			{
				continue;
			}

			string[] words = line.Split(' ');
			if (words.Length != 3)
			{
				Debug.LogError(string.Format("invalid formatting in spawning script: {0}. Line {1} has {2} words instead of the expected 3!", waveConfig.name, i+1, words.Length));
				continue;
			}

			bool success = true;
			for (int j = 0; j < words.Length; ++j)
			{
				if (words[j].Length == 0)
				{
					Debug.LogError(string.Format("invalid formatting in spawning script: {0}. Line {1} has an empty word!", waveConfig.name, i+1));
					success = false;
					continue;
				}
			}

			if (!success)
			{
				continue;
			}

			float delay = float.Parse(words[0]);

			string enemyTypeStr = words[1];
			int enemyType = -1;
			if (enemyTypeStr == "red")
			{
				enemyType = 0;
			}
			else if (enemyTypeStr == "green")
			{
				enemyType = 1;
			}
			else if (enemyTypeStr == "blue")
			{
				enemyType = 2;
			}
			else
			{
				Debug.LogError(string.Format("unkown enemy type: {0} on line: {1}", enemyTypeStr, line));
				continue;
			}

			int count = int.Parse(words[2]);

			waves.Add(new Wave(delay, enemyType, count));
		}
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		for (int i = 0; i < waves.Count; ++i)
		{
			Wave wave = waves[i];
			if (!wave.started)
			{
				if (time >= wave.delay)
				{
					Spawn(wave);
				}
			}
		}
	}

	void Spawn(Wave wave)
	{
		wave.started = true;

		for (int i = 0; i < wave.count; ++i)
		{
			Enemy enemy = null;
			switch(wave.enemyType)
			{
			case 0:
				enemy = Instantiate(redEnemyPrefab) as Enemy;
				break;
			case 1:
				enemy = Instantiate(greenEnemyPrefab) as Enemy;
				break;
			case 2:
				enemy = Instantiate(blueEnemyPrefab) as Enemy;
				break;
			}

			enemy.transform.position = transform.position + new Vector3(2f * waveNum, 0f, 0f);
		}

		waveNum++;
	}
}
