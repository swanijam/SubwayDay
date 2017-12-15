using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DisplayText : ConversationElement {
	[InfoBox("Recommend 3-8 seconds")]
	public float lingerTime = 5f;
	[TextArea]
	public string text = "...";
	public GameObject enableAfterLinger;
	[InfoBox("If this is set to NONE, speaker will use the default speaking sound")]
	public AudioClip overrideSound;
	[InfoBox("If this is set to NONE, speaker will use 'SPEAKING'")]
	public SPEAKER_STATE overrideCharacterState = SPEAKER_STATE.NONE;

	void OnEnable() {
		ConversationsManager.instance.mostRecentSpeaker = ConversationsManager.instance.theSpeakersThemselves [speakerName];
		DialogUIManager.instance.SetMainDialogText (text, true);
		// 1 represents the character is speaking
		if (overrideCharacterState != null) {
			ConversationsManager.instance.setSpeakerState (speakerName, overrideCharacterState);
		} else {
			ConversationsManager.instance.setSpeakerState (speakerName, SPEAKER_STATE.SPEAKING);
		}
		if (overrideSound != null) {
			ConversationsManager.instance.theSpeakersThemselves [speakerName].GetComponent<AudioSource> ().clip = overrideSound;
		}
		ConversationsManager.instance.theSpeakersThemselves [speakerName].GetComponent<AudioSource> ().Play ();
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
