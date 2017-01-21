using UnityEngine;
using VRTK;

public class ArmUiController : MonoBehaviour {

	[Tooltip("THe Canvas the Arm Ui is being rendered on.")]
	[SerializeField]
	Canvas armUi = null;
	
	void Start () {
		// Add the event listener for if the touchpad is pressed, to control whent he UI is visible.
		GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadTouch);
	}
	
	private void DoTouchpadTouch(object sender, ControllerInteractionEventArgs e) {

		if (armUi.gameObject.activeSelf) {
			armUi.gameObject.SetActive(false);
		} else {
			armUi.gameObject.SetActive(true);
		}
	}
}
