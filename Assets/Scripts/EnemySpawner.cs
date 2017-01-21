using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour {

	[SerializeField]
	GameObject objectToSpawn =null;

	[SerializeField]
	float sizeOfSpawnArea = 1.0f;

	[SerializeField]
	float minTimeToSpawn =0.0f;

	[SerializeField]
	float maxTimeToSpawn = 1.0f;

	[SerializeField]
	float baseEnemySpeed = 1.5f;

	[SerializeField]
	int baseSpawnNumber = 0;

	WaveSettings currentWaveSettings = null;

	SimpleTimer spawnTimer = new SimpleTimer();

	bool isSpawning =false;
	int numSpawned = 0;
	private void Update() {
		if (isSpawning) {
			spawnTimer.Update();
			if (spawnTimer.IsFinished()) {
				spawnTimer.SetTimer(SelecteRandomTimeToSpawn(minTimeToSpawn, maxTimeToSpawn));
				spawnTimer.StartTimer();
				SpawnEnemy();
			}
		}	
	}
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, sizeOfSpawnArea);
	}

	public int StartNewWave(WaveSettings newSettings) {
		currentWaveSettings = newSettings;
		spawnTimer.SetTimer(SelecteRandomTimeToSpawn(minTimeToSpawn, maxTimeToSpawn));
		spawnTimer.StartTimer();
		isSpawning = true;
		return baseSpawnNumber + currentWaveSettings.increaseOfEnemies;
	}

	public float SelecteRandomTimeToSpawn(float minTime, float maxTime) {
		return Random.Range(minTime, maxTime);
	}

	public Vector3 SelectRandomPosition(float sizeOfZone) {
		Vector2 newPos = Random.insideUnitCircle * sizeOfZone;

		return transform.position + new Vector3(newPos.x, 0, newPos.y);
	}

	void SpawnEnemy() {
		numSpawned++;
		GameObject enemy = Instantiate(objectToSpawn, SelectRandomPosition(sizeOfSpawnArea), Quaternion.identity) as GameObject;
		enemy.GetComponent<EnemyDeath>().scoreValue *= currentWaveSettings.enemyScoreMultiplier;
		enemy.GetComponent<EnemyDeath>().enemyDamage *= currentWaveSettings.enemyDamageMultiplier;
		enemy.GetComponent<NavMeshAgent>().speed = baseEnemySpeed * currentWaveSettings.enemySpeedMultiplier;
		if (numSpawned > (baseSpawnNumber + currentWaveSettings.increaseOfEnemies)) {
			isSpawning = false;
		}
	}
}
