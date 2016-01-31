using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInEffect : MonoBehaviour {

	Image img;

	public float fadeInTime = 1.0f;
	float time = 0f;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
		img.enabled = false;

		PlayEffect();
	}

	// Update is called once per frame
	void Update () {
		if (img.enabled)
		{
			time += Time.deltaTime;

			float alpha = 1.0f - (time / fadeInTime);
			Color c = img.color;
			c.a = alpha;
			img.color = c;

			if (time >= fadeInTime)
			{
				img.enabled = false;
			}
		}
	}

	public void PlayEffect()
	{
		if (img.enabled == false)
		{
			img.enabled = true;
		}
	}
}
