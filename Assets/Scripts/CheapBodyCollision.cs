using UnityEngine;

public class CheapBodyCollision : MonoBehaviour {
	
	// dont kill me alan, to lazy to fix properly.
	void Update () {
		// Allows capsule collision to easily stay below and oriented properly to the head.
		transform.rotation = Quaternion.identity;
	}
}
