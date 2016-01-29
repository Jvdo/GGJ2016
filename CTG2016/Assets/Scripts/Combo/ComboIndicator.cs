using UnityEngine;
using System.Collections;

public class ComboIndicator : MonoBehaviour {

	Combo combo;
	public int comboId = 0; // should enemy set this?


	// Debug functionality
	public TextMesh debugText;

	// Use this for initialization
	void Start () {
		Initialize(comboId);
	}

	public void Initialize(int id)
	{
		ComboDatabase comboDb = FindObjectOfType<ComboDatabase>();
		combo = comboDb.GetCombo(id);

		debugText.text = combo.GetDebugText();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
