using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AwaitButtonInput : ConversationElement {
	public ButtonData[] buttons;

	// Use this for initialization
	void Start () {
		foreach (ButtonData b in buttons) {
			DialogUIManager.instance.AddButton (b);
		}
		DialogUIManager.instance.RevealDialogButtons ();
		ConversationsManager.instance.setSpeakerState (speakerName, SPEAKER_STATE.LISTENING);
	}
	void OnDisable() {
		DialogUIManager.instance.HideDialogButtons ();
	}
}
