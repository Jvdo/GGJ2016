using UnityEngine;
using System.Collections;

public class EnemyCastIndicator : MonoBehaviour {

	public float factor = 0.5f;

	public Transform fgTransform;
	public MeshRenderer fgRenderer;
	Material fgMaterial;

	// Use this for initialization
	void Start () {
		if (fgRenderer != null)
		{
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fgTransform != null)
		{
			Vector3 localScale = fgTransform.localScale;
			localScale.x = factor;
			fgTransform.localScale = localScale;
		}

		if (fgRenderer != null)
		{
			fgRenderer.material.mainTextureScale = new Vector2(factor, 1.0f);
		}
	}
}
