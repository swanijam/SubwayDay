using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : ConversationElement {
	public float lingerTime = 5f;
	[TextArea]
	public string text = "...";
	public GameObject enableAfterLinger;

	void OnEnable() {
		DialogUIManager.instance.SetMainDialogText (text, true);
		// 1 represents the character is speaking
		ConversationsManager.instance.setSpeakerState(speakerName, SPEAKER_STATE.SPEAKING);
		StartCoroutine (HideText ());
	}

	private IEnumerator HideText (){
		yield return new WaitForSeconds (lingerTime);
		DialogUIManager.instance.SetMainTextActive (false);
		if (!enableAfterLinger || !enableAfterLinger.GetComponent<DisplayText> ()) {
			ConversationsManager.instance.setSpeakerState(speakerName, SPEAKER_STATE.IDLE);
		}

		// this may need to be a in a separate class containing the general behavior of a conversation bit.
		// for now though it's just here.
		if(enableAfterLinger) {enableAfterLinger.SetActive (true);}
		this.gameObject.SetActive (false);
	}
}
