﻿using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour {

	private Transform target_ =null;
	private NavMeshAgent agent_ = null;

	SimpleTimer retargetTimer_ = new SimpleTimer();

	void Start() {
		agent_ = GetComponent<NavMeshAgent>();
		target_ = GameObject.FindWithTag("MainCamera").transform;
		agent_.destination = target_.position;
		retargetTimer_.SetTimer(Random.Range(0, 10));
		retargetTimer_.StartTimer();
	}
	private void Update() {
		retargetTimer_.Update();
		// If it gets close enough to be hitting, force it to double check the player is still their. 
		// Other wise check if to much time has passed and update target.
		if (agent_.remainingDistance <= float.Epsilon || retargetTimer_.IsFinished()) {
			// TODO: Advance this to allow ray traveling, so continues after reaching point for some time?
			agent_.destination = target_.position;
		}
	}
}
