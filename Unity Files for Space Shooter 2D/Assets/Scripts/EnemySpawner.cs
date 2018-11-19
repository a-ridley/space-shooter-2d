﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

	public GameObject enemyPrefab;  // TODO: Make an array of enemy prefabs
	public GameObject bossPrefab;


	// Private boss vars
	GameObject bossInstance;
	bool bossSpawned = false;
	float bossSpawnDelay = 5f;

	// Private enemy vars
	float spawnDistance = 10f;
	float enemyRate = 5f;
	float nextEnemy = 1f;

	// TODO: Test
	public float timeUntilBoss = 10f;
	
	// Update is called once per frame
	void Update ()
	{
		if (timeUntilBoss >= 0) {
			nextEnemy -= Time.deltaTime;
			timeUntilBoss -= Time.deltaTime;

			if (nextEnemy <= 0) {
				// Spawn an enemy

				nextEnemy = enemyRate;  // Set nextEnemy timer to enemyRate
				enemyRate *= 0.9f;      // Reduce enemyRate by 10%

				if (enemyRate <= 1) {
					enemyRate = 1.25f;
				}

				Vector3 offset = Random.onUnitSphere;
				offset.z = 0;  // Z-offset is very important for 2D
				offset.y = 5;
				offset = offset.normalized * spawnDistance;
				Instantiate (enemyPrefab, transform.position + offset, Quaternion.identity);
			}

		} else if (!bossSpawned) {

			bossSpawnDelay -= Time.deltaTime;

			if (bossSpawnDelay <= 0 && !bossSpawned) {
				bossSpawned = true;

				Vector3 offset = Random.onUnitSphere;
				offset.z = 0;
				offset.y = 5;
				offset = offset.normalized * spawnDistance;
				bossInstance = (GameObject)Instantiate (bossPrefab, transform.position + offset, Quaternion.identity);
			}
		} else {
			// Boss has spawned

			if (bossInstance == null) {
				Debug.Log ("Boss died?");
			}
		}
	}
}
