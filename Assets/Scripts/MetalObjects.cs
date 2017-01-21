using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VRTK;

public class MetalObjects : VRTK_InteractableObject {
	[Tooltip("How much the object will power up the microwave bye")]
	[SerializeField]
	float metalStrength = 1.0f;

	private void Start() {
		gameObject.tag = "MetalObject";
	}

	public float MetalStrength() {
		return metalStrength;
	}
}
