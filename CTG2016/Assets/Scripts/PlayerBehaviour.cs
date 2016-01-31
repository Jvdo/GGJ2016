using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float maxHealth = 100;
	public float health = 100;

	public GameObject Red;
	public GameObject Green;
	public GameObject Blue;

	public ScreenShake screenShake;
	GameOverEffect gameOverEffect;

	// Use this for initialization
	void Start () {
		
		health = maxHealth;
		gameOverEffect = FindObjectOfType<GameOverEffect>();
	}
	
	// Update is called once per frame
	void Update () {

		UpdateHealthBar ();
	}

	public void OnHit(float damage)
	{
		health -= damage;

		if (health <= 0f)
		{
			gameOverEffect.PlayEffect();
		}

		screenShake.AddScreenShake(0.6f);
	}

	public float factor = 0.5f;

	public Transform fgTransform;
	public MeshRenderer fgRenderer;
	Material fgMaterial;



	// Update is called once per frame
	void UpdateHealthBar () {

		factor = health / 100f;
		Vector3 localScale = fgTransform.localScale;
		localScale.x = factor;
		fgTransform.localScale = localScale;


		if (fgRenderer != null)
		{
			fgRenderer.material.mainTextureScale = new Vector2(factor, 1.0f);
		}
	}

	public void SetFactor(float f)
	{
		factor = Mathf.Clamp01(f);
	}
}
