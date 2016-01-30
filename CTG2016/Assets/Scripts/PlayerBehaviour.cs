using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float maxHealth = 100;
	public float health = 100;

	public GameObject Red;
	public GameObject Green;
	public GameObject Blue;


	// Use this for initialization
	void Start () {
		
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

		UpdateHealthBar ();

		if (Input.GetKeyDown (KeyCode.H)) {
			
			health -= 1;
		}
	}

	public void OnHit(float damage)
	{
		health -= damage;

		if (health <= 0f)
		{
			print("TODO: game over");
		}
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
