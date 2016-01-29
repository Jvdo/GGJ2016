using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Combo {

	public enum Entry
	{
		Up,
		Down,
		Left,
		Right,
	}

	static Entry GetRandomEntry()
	{
		Array values = Enum.GetValues(typeof(Entry));
		return (Entry)values.GetValue(UnityEngine.Random.Range(0, values.Length));
	}

	List<Entry> entries = new List<Entry>();

	public Combo(int size = 4)
	{
		Generate(size);
	}

	public void Generate(int size)
	{
		const int threshold = 2;

		entries.Clear();

		for (int i = 0; i < size; ++i)
		{
			int existingCount = 0;
			do
			{
				Entry entry = GetRandomEntry();
				existingCount = CountEntry(entry);

				if (existingCount < threshold)
				{
					entries.Add(entry);
				}
			} while (existingCount >= threshold);
		}
	}

	public bool Equals(Combo c)
	{
		return entries == c.entries;
	}

	public void Print()
	{
		String msg = "Combo: ";
		foreach(Entry e in entries)
		{
			msg += e.ToString() + ", ";
		}

		Debug.Log(msg);
	}

	public int CountEntry(Entry e)
	{
		int count = 0;
		for (int i = 0; i < entries.Count; ++i)
		{
			if (entries[i] == e)
			{
				++count;
			}
		}

		return count;
	}
}
