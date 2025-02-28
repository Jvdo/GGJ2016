﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int id;
	public ComboIndicator comboIndicatorPrefab;
	public Vector3 comboIndicatorOffset = new Vector3(0f, 2f, 0f);

	public EnemyCastIndicator castIndicatorPrefab;
	public Vector3 castIndicatorOffset = new Vector3(0f, 0f, 0f);

	public EnemySpawnPoint spawnPoint;

	public EnemyProjectile projectilePrefab;

	ComboIndicator comboIndicator;
	EnemyCastIndicator castIndicator;
	ParticleSpawner particleSpawner;
	ParticleSpawner fireSpawner;
	EggEffect eggEffect;

	public float castTimeMin = 4.0f;
	public float castTimeMax = 6.0f;
	public float castDelayMin = 3.0f;
	public float castDelayMax = 8.0f;

	public AudioSource Unicorn;

	float castSpeed;
	float castFactor;
	float castDelay;

	public bool hasBeenFiredAt;

	enum State
	{
		Startup,
		Casting,
		Dying,
	}

	State currentState;

	// Use this for initialization
	void Start () {
		comboIndicator = Instantiate(comboIndicatorPrefab) as ComboIndicator;
		comboIndicator.transform.SetParent(transform);
		comboIndicator.transform.localPosition = comboIndicatorOffset;

		comboIndicator.Initialize(id);

		if (castIndicatorPrefab != null)
		{
			castIndicator = Instantiate(castIndicatorPrefab) as EnemyCastIndicator;
			castIndicator.transform.SetParent(transform);
			castIndicator.transform.localPosition = castIndicatorOffset;

			castIndicator.gameObject.SetActive(false);
		}

		if (spawnPoint != null)
		{
			spawnPoint.occupied = true;
		}

		castSpeed = RandomCastSpeed();
		castFactor = 0.0f;

		castDelay = Random.Range(castDelayMin, castDelayMax);

		hasBeenFiredAt = false;
		currentState = State.Startup;

		particleSpawner = FindObjectOfType<ParticleSpawner>();
		eggEffect = FindObjectOfType<EggEffect>();
	}
	
	// Update is called once per frame
	void Update () {

		switch(currentState)
		{
		case State.Startup:
			{
				castIndicator.gameObject.SetActive(false);
				castDelay -= Time.deltaTime;

				if (castDelay <= 0f)
				{
					currentState = State.Casting;
				}
			}
			break;
		case State.Casting:
			{
				castIndicator.gameObject.SetActive(true);
				castFactor += castSpeed * Time.deltaTime;

				if (castFactor >= 1.0f)
				{
					castFactor -= 1.0f;
					castSpeed = RandomCastSpeed();

					Unicorn.Play ();
					EnemyProjectile proj = Instantiate(projectilePrefab) as EnemyProjectile;
					proj.transform.position = transform.position;
				}

				if (castIndicator != null)
				{
					castIndicator.SetFactor(castFactor);
				}
			}
			break;
		case State.Dying:
			// Don't do anything!?
			castIndicator.gameObject.SetActive(false);
			break;
		}
	}

	void OnDestroy()
	{
		if (spawnPoint != null)
		{
			spawnPoint.occupied = false;
		}
	}

	float RandomCastSpeed()
	{
		return 1.0f / Random.Range(castTimeMin, castTimeMax);
	}

	public void StartDie()
	{
		currentState = State.Dying;

		switch(id)
		{
		case 0:
			//TODO
			break;
		case 1:
			particleSpawner.SpawnBeesParticles(transform.position);
			break;
		case 2:
			eggEffect.PlayEffect(transform.position);
			break;
		}
	}
}
