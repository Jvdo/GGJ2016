using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverEffect : MonoBehaviour {

	Image img;

	public float fadeOutTime = 1.0f;
	float time = 0f;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
		img.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (img.enabled)
		{
			time += Time.deltaTime;

			float alpha = time / fadeOutTime;
			Color c = img.color;
			c.a = alpha;
			img.color = c;

			if (time >= fadeOutTime)
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene("Defeat");
			}
		}
	}

	public void PlayEffect()
	{
		img.enabled = true;
	}
}
