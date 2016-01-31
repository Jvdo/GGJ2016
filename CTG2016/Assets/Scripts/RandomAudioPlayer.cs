using UnityEngine;
using System.Collections;

public class RandomAudioPlayer : MonoBehaviour {

	public AudioClip[] audioClips;

	public float randomIntervalMin = 10.0f;
	public float randomIntervalMax = 20.0f;

	float timeUntilNext;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();

		timeUntilNext = Random.Range(randomIntervalMin, randomIntervalMax);
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilNext -= Time.deltaTime;

		if (timeUntilNext <= 0.0f)
		{
			int idx = Random.Range(0, audioClips.Length);
			AudioClip randomClip = audioClips[idx];
			print("now playing: " + randomClip.name);
			audioSource.PlayOneShot(randomClip);

			timeUntilNext = Random.Range(randomIntervalMin, randomIntervalMax);
		}
	}
}
