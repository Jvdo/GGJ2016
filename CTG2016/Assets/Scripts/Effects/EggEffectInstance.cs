using UnityEngine;
using System.Collections;

public class EggEffectInstance : MonoBehaviour {

	public float lifeTime = 1.0f;

	public SpriteRenderer spriteRenderer;

	float time = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time >= lifeTime)
		{
			Destroy(gameObject);
		}

		float alpha = 1.0f - time / lifeTime;
		Color c = spriteRenderer.color;
		c.a = alpha;
		spriteRenderer.color = c;

		transform.Translate(new Vector3(0.0f, -0.1f * Time.deltaTime, 0.0f));
	}
}
