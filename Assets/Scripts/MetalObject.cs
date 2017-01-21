using UnityEngine;
using VRTK;

public class MetalObject : VRTK_InteractableObject {
	[Tooltip("How much the object will power up the microwave bye")]
	[SerializeField]
	float metalStrength = 1.0f;

	[Tooltip("Amount of time it takes for the metal objects to cause the micorwave to fire.")]
	[SerializeField]
	float chargeTime = 1.5f;

	[Tooltip("How long it causes the microwave to fire for.")]
	[SerializeField]
	float fireDuration = 1.0f;

	private void Start() {
		gameObject.tag = "MetalObject";
	}
	
	public float MetalStrength() {
		return metalStrength;
	}

	public float ChargeTime() {
		return chargeTime;
	}

	public float FireDuration() {
		return fireDuration;
	}
}
