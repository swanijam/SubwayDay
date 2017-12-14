using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AwaitButtonInput : ConversationElement {
	public ButtonData[] buttons;

	// Use this for initialization
	void Start () {
		DialogUIManager.instance.ClearDialogButtons ();
		foreach (ButtonData b in buttons) {
			DialogUIManager.instance.AddButton (b);
		}
		DialogUIManager.instance.RevealDialogButtons ();
		ConversationsManager.instance.setSpeakerState (speakerName, SPEAKER_STATE.LISTENING);
	}
	void OnDisable() {
		if (DialogUIManager.instance == null) {
			Debug.Log ("uh oh");
		}
		DialogUIManager.instance.HideDialogButtons ();
	}
}
