using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveDialogUIButtonsAndLookAtPlayer : MonoBehaviour {
	public Transform buttonsPositionPivot;
	public Transform moveToPoint;

	public void SetDialogButtonsPositionTo(){
//		if (buttonsPositionPivot != null) {
//			buttonsPositionPivot = DialogUIManager.instance.mainButtonsPanel.transform.parent;
//		}
//		if (moveToPoint != null) {
//			buttonsPositionPivot.position = moveToPoint.position;
//		} else {
//			buttonsPositionPivot.position = transform.position;
//	}
		buttonsPositionPivot.position = moveToPoint.position;
		buttonsPositionPivot.LookAt (Camera.main.transform.position);
	}
}
