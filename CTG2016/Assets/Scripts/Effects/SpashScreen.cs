using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpashScreen : MonoBehaviour {

	Image img;

	public float fadeTime = 1.0f;
	float time = 0f;

	public float startTime = 0.0f;
	public float endTime = 5.0f;

	float fadeInBegin;
	float fadeInEnd;

	float fadeOutBegin;
	float fadeOutEnd;

	float alpha = 0.0f;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
		img.enabled = false;

		fadeInBegin = startTime;
		fadeInEnd = startTime + fadeTime;

		fadeOutBegin = endTime - fadeTime;
		fadeOutEnd = endTime;
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		bool effectActive = time >= startTime && time <= endTime;
		img.enabled = effectActive;

		if (effectActive)
		{
			if (time >= fadeInBegin && time <= fadeInEnd)
			{
				alpha = Mathf.InverseLerp(fadeInBegin, fadeInEnd, time);
			}
			else if (time >= fadeOutBegin && time <= fadeOutEnd)
			{
				alpha = 1.0f - Mathf.InverseLerp(fadeOutBegin, fadeOutEnd, time);
			}
			else if (time > fadeInEnd)
			{
				alpha = 1.0f;
			}
		}

		Color c = img.color;
		c.a = alpha;
		img.color = c;
	}
}
