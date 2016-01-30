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
		}

		float delay;
		int enemyType;
		int count;
	}

	public TextAsset waveConfig;

	List<Wave> waves = new List<Wave>();

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
	
	}
}
