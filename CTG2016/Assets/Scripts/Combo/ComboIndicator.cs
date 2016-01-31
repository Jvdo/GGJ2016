using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComboIndicator : MonoBehaviour {

	Combo combo = null;
	public int comboId = 0; // should enemy set this?

	public ComboIndicatorEntry indicatorPrefab;
	public Vector3 offset = new Vector3(-5f, 0f, 0f);
	public Vector3 distanceBetweenEntries = new Vector3(2.5f, 0f, 0f);

	// Debug functionality
	public TextMesh debugText;

	int lastHash = 0;

	List<ComboIndicatorEntry> indicatorEntries = new List<ComboIndicatorEntry>();

	// Use this for initialization
	void Start () {
		if (combo == null)
		{
			Initialize(comboId);
		}
	}

	public void Initialize(int id)
	{
		comboId = id;
		ComboDatabase comboDb = FindObjectOfType<ComboDatabase>();
		combo = comboDb.GetCombo(comboId);

		SetCombo(combo);

		debugText.text = combo.GetDebugText();
	}

	public void SetCombo(Combo c)
	{
		combo = c;
		UpdateGraphics();
		lastHash = combo.GetHash();
	}

	void Update()
	{
		int currentHash = combo.GetHash();
		if (currentHash != lastHash)
		{
			lastHash = currentHash;
			UpdateGraphics();
		}
	}

	void UpdateGraphics()
	{
		for (int i = 0; i < indicatorEntries.Count; ++i)
		{
			Destroy(indicatorEntries[i].gameObject);
		}
		indicatorEntries.Clear();

		var entries = combo.GetEntries();

		for(int i = 0; i < entries.Count; ++i)
		{
			ComboIndicatorEntry indicatorEntry = Instantiate(indicatorPrefab) as ComboIndicatorEntry;
			Vector3 initialScale = indicatorEntry.transform.localScale;
			indicatorEntry.transform.SetParent(transform);
			indicatorEntry.SetGraphics(entries[i]);
			indicatorEntries.Add(indicatorEntry);
			indicatorEntry.transform.localPosition = offset + distanceBetweenEntries * (float)i;
			indicatorEntry.transform.localScale = initialScale;

			foreach (Transform trans in gameObject.GetComponentsInChildren<Transform>(true))
			{
				trans.gameObject.layer = gameObject.layer;
			}
		}
	}
}
