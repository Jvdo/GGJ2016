using UnityEngine;
using System.Collections;

public class CreditsMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}
	}
}
