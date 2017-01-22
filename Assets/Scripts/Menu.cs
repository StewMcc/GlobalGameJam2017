using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
public class Menu : VRTK_DestinationMarker
{
    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text waveText;

    [SerializeField]
    private WaveController waveController;

	public VRTK_HeightAdjustTeleport playerArea;

	public Transform destination;
	private bool lastUsePressedState = false;

	private void Start()
    {
        GameOverScript gameOver =  FindObjectOfType<GameOverScript>();

        if(gameOver)
        {
            scoreText.text = gameOver.finalScore.ToString();
            waveText.text = gameOver.finalWave.ToString();
        }
    }
		private void OnTriggerStay(Collider collider) {
		var controller = (collider.GetComponent<VRTK_ControllerEvents>() ? collider.GetComponent<VRTK_ControllerEvents>() : collider.GetComponentInParent<VRTK_ControllerEvents>());
		if (controller) {
			if (lastUsePressedState == true && !controller.usePressed) {
				var distance = Vector3.Distance(transform.position, destination.position);
				var controllerIndex = VRTK_DeviceFinder.GetControllerIndex(controller.gameObject);
				OnDestinationMarkerSet(SetDestinationMarkerEvent(distance, destination, new RaycastHit(), destination.position, controllerIndex));
				playerArea.enabled = false;
			}
			lastUsePressedState = controller.usePressed;
		}
	}



}
