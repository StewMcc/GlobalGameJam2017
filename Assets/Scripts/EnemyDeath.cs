using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
		
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "DamagingMicroWave") {
			// start animation or wooble? then death, fire off animator state?
			Destroy(gameObject);
		}
	}
}
