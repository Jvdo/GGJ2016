using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour {

	AudioSource audioSource;

	public AudioClip buttonSfx;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
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
		audioSource.PlayOneShot(buttonSfx);
		UnityEngine.SceneManagement.SceneManager.LoadScene("Remco");
	}

	public void OnCreditsButtonClicked()
	{
		audioSource.PlayOneShot(buttonSfx);
		UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
	}

	public void OnQuitButtonClicked()
	{
		audioSource.PlayOneShot(buttonSfx);
		Application.Quit();
	}
}
