using UnityEngine;
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

	public float castTimeMin = 4.0f;
	public float castTimeMax = 6.0f;
	public float castDelayMin = 3.0f;
	public float castDelayMax = 8.0f;

	public AudioSource Unicorn;

	float castSpeed;
	float castFactor;
	float castDelay;

	public bool hasBeenFiredAt;

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
		}

		if (spawnPoint != null)
		{
			spawnPoint.occupied = true;
		}

		castSpeed = RandomCastSpeed();
		castFactor = 0.0f;

		castDelay = Random.Range(castDelayMin, castDelayMax);

		hasBeenFiredAt = false;
	}
	
	// Update is called once per frame
	void Update () {

		castDelay -= Time.deltaTime;

		if (castDelay <= 0f)
		{
			castFactor += castSpeed * Time.deltaTime;
		}

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
}
