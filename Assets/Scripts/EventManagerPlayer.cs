using UnityEngine;

public class EventManagerPlayer : MonoBehaviour {

	public delegate void EventHandlerPlayer(float value);
	
	public static event EventHandlerPlayer OnEnemyAttack;

	
	public static event EventHandlerPlayer OnPlayerScores;

		
	public static void EnemyAttacked(float value) {
		// notify all listeners to event.
		if (OnEnemyAttack != null) {
			OnEnemyAttack(value);
		}
	}

	public static void PlayerScored(float value) {
		// notify all listeners to event.
		if (OnPlayerScores != null) {
			OnPlayerScores(value);
		}
	}
}
