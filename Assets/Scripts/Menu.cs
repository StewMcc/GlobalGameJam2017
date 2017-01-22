using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class Menu : VRTK_DestinationMarker
{

    [SerializeField]
    private WaveController waveController;

    private bool lastUsePressedState = false;

    private void OnTriggerStay(Collider collider)
    {
        var controller = (collider.GetComponent<VRTK_ControllerEvents>() ? collider.GetComponent<VRTK_ControllerEvents>() : collider.GetComponentInParent<VRTK_ControllerEvents>());
        if (controller)
        {
            if (lastUsePressedState == true && !controller.usePressed)
            {
                var distance = Vector3.Distance(transform.position, waveController.startPos.position);
                var controllerIndex = VRTK_DeviceFinder.GetControllerIndex(controller.gameObject);
                OnDestinationMarkerSet(SetDestinationMarkerEvent(distance, waveController.startPos, new RaycastHit(), waveController.startPos.position, controllerIndex));
                waveController.RestartGame();
                waveController.StartGame();
            }
            lastUsePressedState = controller.usePressed;
        }
    }

 


}
