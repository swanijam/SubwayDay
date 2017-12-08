using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransformTo : MonoBehaviour {
	public Transform objToMove;
	public Transform destination;
	public Transform lookAtTarget;
	public Transform DialogUIButtonPanel;

	public void Move() {
		objToMove.position = destination.position;
		objToMove.rotation = destination.rotation;

//		DialogUIButtonPanel = DialogUIManager.instance.mainButtonsPanel.transform;
//		float offset = Mathf.Cos (Mathf.Deg2Rad * (objToMove.gameObject.GetComponent<Camera> ().fieldOfView) / 2f) * Vector3.Distance (lookAtTarget.position, objToMove.position);
//		Debug.Log (offset);
//		DialogUIButtonPanel.transform.position = lookAtTarget.position + destination.right * offset * .5f;
//		DialogUIButtonPanel.LookAt (destination.position);
//		DialogUIButtonPanel.Rotate (0f, 180f, 0f);
//		DialogUIButtonPanel.localScale = new Vector3((.3f + .06f * offset), (.3f + .06f * offset), (.3f + .06f * offset));
		objToMove.gameObject.GetComponent<MonoScopicVR_Rotation> ().ResetOffsets ();
	}
}
