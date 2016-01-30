using UnityEngine;
using System.Collections;

public class InvalidComboEffect : MonoBehaviour {

	public AudioSource misfire;

	public float frequency;
	float strength = 0.0f;

	public float maxStrenght = 10f;
	public float strengthFalloffTime = 0.9f;

	Vector3 startPosition;

	float time = 0f;
	// Use this for initialization
	void Start () {
		startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		transform.localPosition = startPosition + new Vector3(Mathf.Sin(time * 2f * Mathf.PI * frequency) * strength * maxStrenght, 0f, 0f);

		strength -= Time.deltaTime / strengthFalloffTime;
		if (strength < 0.0f)
		{
			strength = 0.0f;
		}
	}

	public void PlayEffect()
	{
		misfire.Play ();
		strength = 1.0f;
	}
}
