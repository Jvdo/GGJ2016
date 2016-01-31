using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (WillyInput.IsJoystickButtonPressed(WillyInput.JoystickButton.A))
		{
			OnPlayButtonClicked();
		}
		else if (WillyInput.IsJoystickButtonPressed(WillyInput.JoystickButton.Y))
		{
			OnCreditsButtonClicked();
		}
		else if (WillyInput.IsJoystickButtonPressed(WillyInput.JoystickButton.B))
		{
			OnQuitButtonClicked();
		}
	}

	public void OnPlayButtonClicked()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Remco");
	}

	public void OnCreditsButtonClicked()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
	}

	public void OnQuitButtonClicked()
	{
		Application.Quit();
	}
}
