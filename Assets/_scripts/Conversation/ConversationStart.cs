using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// It's important that ConversationStart Runs first (but still after ConversationManager), because it has to intialize some things. 
public class ConversationStart : ConversationElement {
	public GameObject firstStep;
	void  Start() {
		ConversationsManager.instance.addConversationForSpeaker(speakerName, gameObject);
		ConversationElement[] ces = GetComponentsInChildren<ConversationElement> ();
		foreach (ConversationElement ce in ces) {
			ce.speakerName = speakerName;
		}
		Debug.Log ("ConversationStart Register done");
	}

	public void StartConversation(){
		firstStep.SetActive (true);
	}
}