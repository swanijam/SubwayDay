﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazeResponder : MonoBehaviour {
	public UnityEvent onGaze;
	// by default, a gazeResponder should become inactive
	// after its onGaze is invoked.
	public bool inactive = false;

	public virtual void Invoke() {
		if (onGaze != null && !inactive) {
			DialogUIManager.instance.HideDialogButtons ();
			onGaze.Invoke ();
			this.inactive = true;
		} else {
			Debug.LogWarning ("Gaze Action not set on " + gameObject.name);
		}
	}
}
