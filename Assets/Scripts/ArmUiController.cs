using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ArmUiController : MonoBehaviour {

	[SerializeField]
	Canvas armUi = null;
	// Use this for initialization
	void Start () {
		GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadTouch);
	}

	private void DoTouchpadTouch(object sender, ControllerInteractionEventArgs e) {
		if (armUi.gameObject.activeSelf) {
			armUi.gameObject.SetActive(false);
		} else {
			armUi.gameObject.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
