using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComboIndicator : MonoBehaviour {

	Combo combo;
	public int comboId = 0; // should enemy set this?

	public ComboIndicatorEntry indicatorPrefab;
	public Vector3 offset = new Vector3(-5f, 0f, 0f);
	public Vector3 distanceBetweenEntries = new Vector3(2.5f, 0f, 0f);

	// Debug functionality
	public TextMesh debugText;

	List<ComboIndicatorEntry> indicatorEntries = new List<ComboIndicatorEntry>();

	// Use this for initialization
	void Start () {
		Initialize(comboId);
	}

	public void Initialize(int id)
	{
		ComboDatabase comboDb = FindObjectOfType<ComboDatabase>();
		combo = comboDb.GetCombo(id);

		debugText.text = combo.GetDebugText();

		var entries = combo.GetEntries();
		for(int i = 0; i < entries.Count; ++i)
		{
			ComboIndicatorEntry indicatorEntry = Instantiate(indicatorPrefab) as ComboIndicatorEntry;
			indicatorEntry.transform.SetParent(transform);
			indicatorEntry.SetGraphics(entries[i]);
			indicatorEntries.Add(indicatorEntry);
			indicatorEntry.transform.localPosition = offset + distanceBetweenEntries * (float)i;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
