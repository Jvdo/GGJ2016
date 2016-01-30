using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveCompletedEffect : MonoBehaviour {

	Text uiText;
	RectTransform rectTransform;

	float timeForNextShake = 0.0f;
	float shakeTime = 0.0f;
	public float shakeIntervalMin = 0.1f;
	public float shakeIntervalMax = 0.2f;
	public Vector3 shakeIntensity;

	Vector3 targetPosition = Vector3.zero;
	Vector3 lastPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		uiText = GetComponent<Text>();
		rectTransform = GetComponent<RectTransform>();
		Color c = uiText.color;
		c.a = 0.0f;
		uiText.color = c;
	}
	
	// Update is called once per frame
	void Update () {
		shakeTime += Time.deltaTime;

		if (shakeTime >= timeForNextShake)
		{
			shakeTime -= timeForNextShake;
			timeForNextShake = Random.Range(shakeIntervalMin, shakeIntervalMax);
			lastPosition = targetPosition;
			targetPosition = new Vector3(Random.Range(-shakeIntensity.x, shakeIntensity.x), Random.Range(-shakeIntensity.y, shakeIntensity.y), 0);
		}

		rectTransform.anchoredPosition3D = Vector3.Lerp(lastPosition, targetPosition, shakeTime / timeForNextShake);
	}

	public void PlayEffect(int stageNum)
	{
		uiText.text = string.Format("Stage {0} Completed!", stageNum);
		StartCoroutine(EffectRoutine());
	}

	IEnumerator EffectRoutine()
	{
		float time = 0f;
		float fadeInTime = 0.7f;

		while(time <= fadeInTime)
		{
			time += Time.deltaTime;
			Color c = uiText.color;
			c.a = time / fadeInTime;
			uiText.color = c;
			yield return null;
		}

		yield return new WaitForSeconds(1.5f);

		float fadeOutTime = 0.7f;
		time = 0.0f;
		while(time <= fadeOutTime)
		{
			time += Time.deltaTime;
			Color c = uiText.color;
			c.a = 1.0f - time / fadeInTime;
			uiText.color = c;
			yield return null;
		}

		{
			Color c = uiText.color;
			c.a = 0.0f;
			uiText.color = c;
		}
	}
}
