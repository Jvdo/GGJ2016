using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int id;
	public ComboIndicator comboIndicatorPrefab;
	public Vector3 comboIndicatorOffset = new Vector3(0f, 2f, 0f); 

	ComboIndicator comboIndicator;

	// Use this for initialization
	void Start () {
		comboIndicator = Instantiate(comboIndicatorPrefab) as ComboIndicator;
		comboIndicator.transform.SetParent(transform);
		comboIndicator.transform.localPosition = comboIndicatorOffset;

		comboIndicator.Initialize(id);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
