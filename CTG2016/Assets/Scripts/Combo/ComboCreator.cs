using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComboCreator : MonoBehaviour {

	public ComboIndicator comboIndicator;
	RespawnBullet bulletSpawner;
	ComboDatabase comboDb;

	Combo combo;

	InvalidComboEffect invalidComboEffect;

	public AudioSource input;

	bool inputEnabled = true;
	public float totalTimeDisabled = 0.2f;
	float timeInputDiabled = 0.0f;


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

		bulletSpawner = GetComponent<RespawnBullet>();
		comboDb = FindObjectOfType<ComboDatabase>();

		invalidComboEffect = FindObjectOfType<InvalidComboEffect>();

		string[] joystickNames = Input.GetJoystickNames();

		foreach (string str in joystickNames)
		{
			print("Joystick:" + str);
		}
	}

	bool IsButtonAccepted(string buttonName)
	{
		return combo.GetEntries().Count < 4 && Input.GetButtonDown(buttonName);
	}
	
	// Update is called once per frame
	void Update () {

		#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
		if (Input.GetKeyDown("joystick button 19"))
		{
			combo.AddEntry(Combo.Entry.Up);
			input.Play ();
		}
		if (Input.GetKeyDown("joystick button 16"))
		{
			combo.AddEntry(Combo.Entry.Down);
			input.Play ();
		}
		if (Input.GetKeyDown("joystick button 18"))
		{
			combo.AddEntry(Combo.Entry.Left);
			input.Play ();
		}
		if (Input.GetKeyDown("joystick button 17"))
		{
			combo.AddEntry(Combo.Entry.Right);
			input.Play ();
		}
		#else
		if (Input.GetKeyDown("joystick button 3"))
		{
			combo.AddEntry(Combo.Entry.Up);
			input.Play ();
		}
		if (Input.GetKeyDown("joystick button 0"))
		{
			combo.AddEntry(Combo.Entry.Down);
			input.Play ();
		}
		if (Input.GetKeyDown("joystick button 2"))
		{
			combo.AddEntry(Combo.Entry.Left);
			input.Play ();
		}
		if (Input.GetKeyDown("joystick button 1"))
		{
			combo.AddEntry(Combo.Entry.Right);
			input.Play ();
		}
		#endif

		if (inputEnabled)
		{
			if (IsButtonAccepted("Up"))
			{
				combo.AddEntry(Combo.Entry.Up);
			}
			if (IsButtonAccepted("Down"))
			{
				combo.AddEntry(Combo.Entry.Down);
			}
			if (IsButtonAccepted("Left"))
			{
				combo.AddEntry(Combo.Entry.Left);
			}
			if (IsButtonAccepted("Right"))
			{
				combo.AddEntry(Combo.Entry.Right);
			}
		}
		else
		{
			timeInputDiabled += Time.deltaTime;
		}
		if (combo.GetEntries().Count >= 4)
		{
			inputEnabled = false;
		}

		if (timeInputDiabled >= totalTimeDisabled)
		{
			//combo.Print();
			Enemy enemy = GetClosestEnemyForCombo(combo);
			if (enemy != null)
			{
				bulletSpawner.Fire(enemy);
			}
			else if (combo.GetEntries().Count > 0)
			{
				invalidComboEffect.PlayEffect();
			}
			combo.Reset();

			timeInputDiabled = 0.0f;
			inputEnabled = true;
		}
	}

	Enemy GetClosestEnemyForCombo(Combo c)
	{
		List<Enemy> enemies = FindEnemiesForCombo(c);

		print("enemies found: " + enemies.Count);

		float closestSqDistance = float.MaxValue;
		Enemy closestEnemy = null;
		Vector3 currentPosition = transform.position;

		for (int i = 0; i < enemies.Count; ++i)
		{
			Enemy target = enemies[i];
			Vector3 diff = target.transform.position - currentPosition;
			float sqDist = diff.sqrMagnitude;
			if (sqDist < closestSqDistance)
			{
				closestSqDistance = sqDist;
				closestEnemy = target;
			}
		}

		return closestEnemy;
	}

	List<Enemy> FindEnemiesForCombo(Combo c)
	{
		int comboId = -1;
		if (comboDb.ContainsCombo(c))
		{
			comboId = comboDb.GetId(c);
			print("we've found a matching comboId: " + comboId);
		}
		if (comboId == -1)
		{
			print("no matching comboId!");

			// return emtpy list
			return new List<Enemy>();
		}

		Enemy[] enemies = FindObjectsOfType<Enemy>();

		List<Enemy> correctEnemies = new List<Enemy>();

		for (int i = 0; i < enemies.Length; ++i)
		{
			Enemy enemy = enemies[i];
			if (!enemy.hasBeenFiredAt && enemy.id == comboId)
			{
				correctEnemies.Add(enemy);
			}
		}
		return correctEnemies;
	}
}
