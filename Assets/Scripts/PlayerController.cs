using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	Text scoreText = null;

	[SerializeField]
	Text healthText = null;

	[SerializeField]
	Image healthBar = null;

	[SerializeField]
	float initialHealth = 200.0f;

	private float score_ = 0.0f;
	private float health_;

	private void Start() {
		health_ = initialHealth;

		scoreText.text = "Score: " + score_.ToString("F0");
		healthText.text = "Health: " + health_.ToString("F0");

		EventManagerPlayer.OnPlayerScores += OnPlayerScore;
		EventManagerPlayer.OnEnemyAttack += OnEnemyAttack;
	}

	private void Update() {
		scoreText.text = "Score: " + score_.ToString("F0");
		healthText.text = "Health: " + health_.ToString("F0");
		healthBar.fillAmount = health_ / initialHealth;
	}

	void OnPlayerScore(float points) {
		score_ += points;
	}

	void OnEnemyAttack(float damage) {
		health_ -= damage;
		// TODO: check if 0 health and load end screen?
	}
}
