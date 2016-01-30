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

	public Combo(int size = 0)
	{
		Generate(size);
	}

	public Combo(List<Entry> entries)
	{
		this.entries = entries;
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

	public String GetDebugText()
	{
		String msg = "Combo: ";
		foreach(Entry e in entries)
		{
			msg += e.ToString() + ", ";
		}

		return msg;
	}

	public void Print()
	{
		Debug.Log(GetDebugText());
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

	public List<Entry> GetEntries()
	{
		return entries;
	}

	public void Reset()
	{
		entries.Clear();
	}

	public void AddEntry(Entry e)
	{
		entries.Add(e);
	}

	public int GetHash()
	{
		int total = 0;

		int numEntryTypes = Enum.GetNames(typeof(Entry)).Length;
		for (int i = 0; i < entries.Count; ++i)
		{
			total += i * numEntryTypes + (int)entries[i];
		}

		return total;
	}
}
