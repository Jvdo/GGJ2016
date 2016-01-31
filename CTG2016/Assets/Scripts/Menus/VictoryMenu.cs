using UnityEngine;
using System.Collections;

public class VictoryMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnReplayButtonClicked()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Remco");
	}

	public void OnMainMenuButtonClicked()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}
}
