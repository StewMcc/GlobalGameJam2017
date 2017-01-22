using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
public class TeleportUI : MonoBehaviour {

	[SerializeField]
	private Image telportStateImage;

	[SerializeField]
	private VRTK_BasePointer baseTelporter;


	// Update is called once per frame
	void Update () {

		if (baseTelporter.CanActivate()) {
			telportStateImage.color = Color.green;
		}else {
			telportStateImage.color = Color.red;

		}
	}
}
