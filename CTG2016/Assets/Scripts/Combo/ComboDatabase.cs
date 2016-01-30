using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComboDatabase : MonoBehaviour {

	List<Combo> combos = new List<Combo>();

	public int comboLength = 4;

	// Use this for initialization
	void Start () {

		// Debug code...
		InitializeCombos(5);
		Print();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitializeCombos(int numCombos)
	{
		for (int i = 0; i < numCombos; ++i)
		{
			Combo c = new Combo(comboLength);
			while (ContainsCombo(c))
			{
				c.Generate(comboLength);
			}
			combos.Add(c);
		}
	}

	public bool ContainsCombo(Combo c)
	{
		foreach (var combo in combos)
		{
			if (combo.Equals(c))
			{
				return true;
			}
		}
		return false;
	}

	public int GetId(Combo c)
	{
		for (int i = 0; i < combos.Count; ++i)
		{
			if (combos[i].Equals(c))
			{
				return i;
			}
		}
		return -1;
	}

	public void Print()
	{
		foreach(Combo c in combos)
		{
			c.Print();
		}
	}

	public Combo GetCombo(int id)
	{
		return combos[id];
	}
}
