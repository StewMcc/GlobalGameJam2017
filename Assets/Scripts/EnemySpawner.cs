using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Should always have a parent 1Unit cube to represent the spawn area.
public class EnemySpawner : MonoBehaviour {

	[SerializeField]
	Transform spawnArea =null;

	[SerializeField]
	float rateOfSpawn = 0.5f;
	
	// Update is called once per frame
	void Update () {
		
	}
}
