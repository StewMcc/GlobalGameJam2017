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

		healthText.text = "Score: " + score_.ToString("F0");
		healthText.text = "Health: " + health_.ToString("F0");
	}

	private void Update() {
		healthText.text = "Score: " + score_.ToString("F0");
		healthText.text = "Health: " + health_.ToString("F0");
		healthBar.fillAmount = health_ / initialHealth;
	}

}
