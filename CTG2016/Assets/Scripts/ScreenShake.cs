using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	float durationRemaining;

	public float fadeOutTime = 0.5f;

	float strength = 0.0f;
	public float intensity = 0.3f;
	public float frequency = 14.0f;

	float timeForNextUpdate = 0.0f;
	float updateTime = 0.0f;

	Vector3 targetPosition;
	Vector3 startPosition;
	Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.localPosition;
		lastPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		durationRemaining -= Time.deltaTime;

		if (durationRemaining <= fadeOutTime)
		{
			strength = durationRemaining / fadeOutTime;
		}
		else
		{
			strength = 1.0f;
		}

		strength = Mathf.Clamp01(strength);

		updateTime += Time.deltaTime;

		if (updateTime >= timeForNextUpdate)
		{
			float max = strength * intensity;
			lastPosition = targetPosition;
			targetPosition = new Vector3(Random.Range(-max, max), Random.Range(-max, max), Random.Range(-max, max));
			timeForNextUpdate = 1.0f / frequency;
		}

		Vector3 offset = Vector3.Lerp(lastPosition, targetPosition, updateTime / timeForNextUpdate);
		transform.localPosition = startPosition + offset;
	}

	public void AddScreenShake(float duration)
	{
		durationRemaining = duration;
		strength = 1.0f;
	}
}
