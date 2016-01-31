using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayButtonClicked()
	{
		Application.LoadLevel (1);
	}

	public void OnCreditsButtonClicked()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
	}
}
