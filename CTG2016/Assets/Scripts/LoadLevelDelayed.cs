﻿using UnityEngine;
using System.Collections;

public class LoadLevelDelayed : MonoBehaviour {

	public float targetTime = 21.0f;
	public string levelName;
	float time = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time >= targetTime)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
		}
	}
}
