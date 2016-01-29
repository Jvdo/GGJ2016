using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComboCreator : MonoBehaviour {


	List<Combo.Entry> currentEntries = new List<Combo.Entry>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Up"))
		{
			currentEntries.Add(Combo.Entry.Up);
		}
		if (Input.GetButtonDown("Down"))
		{
			currentEntries.Add(Combo.Entry.Down);
		}
		if (Input.GetButtonDown("Left"))
		{
			currentEntries.Add(Combo.Entry.Left);
		}
		if (Input.GetButtonDown("Right"))
		{
			currentEntries.Add(Combo.Entry.Right);
		}
		if (Input.GetButtonDown("Submit"))
		{
			Combo c = new Combo(currentEntries);
			c.Print();
			currentEntries.Clear();
		}
	}
}
