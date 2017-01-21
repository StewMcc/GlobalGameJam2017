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

	private float damageAmount_ = 10.0f;
	
	private bool isCharging_ =false;
	private bool isFiring_ =false;

	SimpleTimer chargingTimer_ = new SimpleTimer();
	SimpleTimer fireTimer_ = new SimpleTimer();

	protected override void Awake() {
		base.Awake();		
		ResetDisplay();
	}

	protected void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "MetalObject" && !(isFiring_ || isCharging_)) {
			isCharging_ = true;
			MetalObject metalObject = collision.gameObject.GetComponent<MetalObject>();

			chargingTimer_.SetTimer(metalObject.ChargeTime());
			chargingTimer_.StartTimer();
			fireTimer_.SetTimer(metalObject.FireDuration());
			damageAmount_ = metalObject.MetalStrength();

			// Augment the Microwave Fire Dimensions.
			Destroy(collision.gameObject);			
		}
	}

	protected override void Update() {
		base.Update();
		// check if it can charge
		if (isCharging_) {
			chargingTimer_.Update();
			// run countdown			
			if (chargingTimer_.IsFinished()) {
				isCharging_ = false;
				FireMicroWave();
				ResetDisplay();
			}
			else {
				countdownText.text = chargingTimer_.TimeRemaining().ToString("F1");
				countDownImage.fillAmount = chargingTimer_.TimeRemaining() / chargingTimer_.Duration();
			}
		}
		if (isFiring_) {
			fireTimer_.Update();
			if (fireTimer_.IsFinished()) {
				StopFiring();
			}
		}
	}

	private void FireMicroWave() {
		// TODO: Start particle effect or animation.
		waveEffect.SetActive(true);
		isFiring_ = true;
		fireTimer_.StartTimer();
	}

	private void StopFiring() {
		// TODO: stop the animation or particle efffect that needs added.
		waveEffect.SetActive(false);
		isFiring_ = false;
	}

	private void ResetDisplay() {
		countdownText.text = "00:00";
		countDownImage.fillAmount = 0.0f;
	}
}
