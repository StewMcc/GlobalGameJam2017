
using System;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class MicroWave : VRTK_InteractableObject {

	[Tooltip("Text to show number countdown of timer.")]
	[SerializeField]
	private Text countdownText = null;

	[Tooltip("Image used radial fill for countdown.")]
	[SerializeField]
	private Image countDownImage =null;

	[Tooltip("Used when microwave fires.")]
	[SerializeField]
	private GameObject waveEffect = null;

	[SerializeField]
	private float damageAmount = 10.0f;

	float chargeTime_ = 6.0f;
	float timeRemaining_ = 0.0f;
	bool isCharging_ =false;
		
	protected override void Awake() {
		base.Awake();
		timeRemaining_ = chargeTime_;
		ResetClock();
	}

	protected void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "MetalObject") {
			isCharging_ = true;
			collision.gameObject.GetComponent<MetalObjects>().MetalStrength();
			// Augment the Microwave Fire Dimensions.
			Destroy(collision.gameObject);
			waveEffect.SetActive(false);
		}
	}
		
	protected override void Update() {
		base.Update();
		// check if it can charge
		if (isCharging_) {
			// run countdown
			timeRemaining_ -= Time.deltaTime;
			if (timeRemaining_ < 0) {
				timeRemaining_ = chargeTime_;
				isCharging_ = false;
				FireMicroWave();
				ResetClock();
			}
			else {				
				countdownText.text = timeRemaining_.ToString("F1");
				countDownImage.fillAmount = timeRemaining_ / chargeTime_;
			}
		}
	}
		
	private void FireMicroWave() {
		waveEffect.SetActive(true);
	}
	private void ResetClock() {
		countdownText.text = "00:00";
		countDownImage.fillAmount = 0.0f;
	}
}
