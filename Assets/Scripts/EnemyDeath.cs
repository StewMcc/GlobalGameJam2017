using UnityEngine;
using VRTK;

public class EnemyDeath : MonoBehaviour {

	[Tooltip("Amount of damage the enemy will deal to the player.")]
	public float enemyDamage =1.0f;

	[Tooltip("Number of points gained for killing mob.")]
	public	float scoreValue = 1.0f;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "DamagingMicroWave") {
			// start animation or wooble? then death, fire off animator state?
			Destroy(gameObject);
			EventManagerPlayer.PlayerScored(scoreValue);
			WaveController.numberOfEnemiesLeft--;

		}
		else if (other.gameObject.tag == "MainCamera") {
			// start animation or wooble? then death, fire off animator state?
			Destroy(gameObject);
			EventManagerPlayer.EnemyAttacked(enemyDamage);
			WaveController.numberOfEnemiesLeft--;
		}
		else {
			VRTK_InteractableObject hitObject = other.GetComponent<VRTK_InteractableObject>();
			if (hitObject != null) {
				if (hitObject.IsGrabbed()) {
					//KillEnemy();
				}
			}			
		}
	}

	private void KillEnemy() {
		// start animation or wooble? then death, fire off animator state?
		gameObject.SetActive(false);
		Destroy(gameObject);		
		WaveController.numberOfEnemiesLeft--;
	}
}
