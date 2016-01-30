using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComboCreator : MonoBehaviour {

	public ComboIndicator comboIndicator;

	Combo combo;
	// Use this for initialization
	void Start () {
		combo = new Combo();

		if (comboIndicator == null)
		{
			var gameObject = GameObject.FindWithTag("Player Combo Indicator");
			comboIndicator = gameObject.GetComponent<ComboIndicator>();
		}
		if (comboIndicator != null)
		{
			comboIndicator.SetCombo(combo);
		}
		else
		{
			Debug.LogWarning("Cannot find 'Player Combo Indicator'. Did you add a UI?");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Up"))
		{
			combo.AddEntry(Combo.Entry.Up);
		}
		if (Input.GetButtonDown("Down"))
		{
			combo.AddEntry(Combo.Entry.Down);
		}
		if (Input.GetButtonDown("Left"))
		{
			combo.AddEntry(Combo.Entry.Left);
		}
		if (Input.GetButtonDown("Right"))
		{
			combo.AddEntry(Combo.Entry.Right);
		}
		if (Input.GetButtonDown("Submit"))
		{
			combo.Print();
			combo.Reset();
		}
	}
}
