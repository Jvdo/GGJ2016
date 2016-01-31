using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VictoryMenu : MonoBehaviour {

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
			OnReplayButtonClicked();
		}
		else if (WillyInput.IsJoystickButtonPressed(WillyInput.JoystickButton.B))
		{
			OnMainMenuButtonClicked();
		}
	}

	public void OnReplayButtonClicked()
	{
		audioSource.PlayOneShot(buttonSfx);
		UnityEngine.SceneManagement.SceneManager.LoadScene("Remco");
	}

	public void OnMainMenuButtonClicked()
	{
		audioSource.PlayOneShot(buttonSfx);
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}
}
