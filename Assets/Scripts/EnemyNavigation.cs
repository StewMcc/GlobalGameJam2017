using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour {

	private Transform target_ =null;
	private NavMeshAgent agent_ = null;
	void Start() {
		agent_ = GetComponent<NavMeshAgent>();
		target_ = GameObject.FindWithTag("MainCamera").transform;
		agent_.destination = target_.position;		
	}
	private void Update() {
		if (agent_.remainingDistance <= float.Epsilon) {
			agent_.destination = target_.position;
		}
	}
}
