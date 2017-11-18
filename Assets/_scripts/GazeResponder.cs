using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazeResponder : MonoBehaviour {
	public UnityEvent onGaze;

	public virtual void Invoke() {
		if (onGaze != null) {
			DialogUIManager.instance.HideDialogButtons ();
			onGaze.Invoke ();
			this.enabled = false; // turn off the gaze responder if this has already been triggered
		} else {
			Debug.LogWarning ("Gaze Action not set on " + gameObject.name);
		}
	}
}
