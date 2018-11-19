using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	// Holds Meteor prefabs
	public GameObject[] meteors;

	float spawnDistance = 10f;

	float medMeteorRateLow = 3f;
	float medMeteorRateHigh = 6f;  // Exclusive
	float bigMeteorRateLow = 4f;
	float bigMeteorRateHigh = 8f;  // Exclusive

	float nextMedMeteor = 2f;
	float nextBigMeteor = 4f;

	float screenRatio;
	float widthOrtho;

	void Update() {
		screenRatio = (float)Screen.width / (float)Screen.height;  // WARNING! Might be weird/glitchy b.c. of Integers
		widthOrtho = Camera.main.orthographicSize * screenRatio;

		nextMedMeteor -= Time.deltaTime;
		nextBigMeteor -= Time.deltaTime;

		if (nextMedMeteor <= 0) {
			// Set a random interval
			nextMedMeteor = Random.Range(medMeteorRateLow, medMeteorRateHigh);
			
			// Spawn a medium-sized meteor
			Vector3 offset = Random.onUnitSphere;
			offset.z = 0;  // z-offset needs to be 0 for 2D
			offset.y = 5;
			offset.x = Random.Range (-widthOrtho, widthOrtho);
			offset = offset.normalized * spawnDistance;

			Instantiate (meteors [(int)Random.Range (0, 2)], transform.position + offset, Quaternion.identity);
		}

		if (nextBigMeteor <= 0) {
			// Set a random interval
			nextBigMeteor = Random.Range(bigMeteorRateLow, bigMeteorRateHigh);

			// Spawn a big-sized meteor
			Vector3 offset = Random.onUnitSphere;
			offset.z = 0;  // z-offset needs to be 0 for 2D
			offset.y = 5;
			offset.x = Random.Range (-widthOrtho, widthOrtho);
			offset = offset.normalized * spawnDistance;

			Instantiate (meteors [(int)Random.Range (2, 4)], transform.position + offset, Quaternion.identity);
		}

	}
}
