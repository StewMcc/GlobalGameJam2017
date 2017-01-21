using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	[Tooltip("Amount of damage the enemy will deal to the player.")]
	[SerializeField]
	float enemyDamage =1.0f;

	[Tooltip("Number of points gained for killing mob.")]
	[SerializeField]
	float scoreValue = 1.0f;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "DamagingMicroWave") {
			// start animation or wooble? then death, fire off animator state?
			Destroy(gameObject);
			EventManagerPlayer.PlayerScored(scoreValue);
		}
		else if (other.gameObject.tag == "MainCamera") {
			// start animation or wooble? then death, fire off animator state?
			Destroy(gameObject);
			EventManagerPlayer.EnemyAttacked(enemyDamage);
		}
	}
}
