using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

// It's important that ConversationStart Runs first (but still after ConversationManager), because it has to intialize some things. 
public class ConversationStart : ConversationElement {
	[Button ("SetChildrenForAllSpeaker", buttonSize:ButtonSizes.Medium)]
	public void SetAllChildren() {
		gameObject.BroadcastMessage ("SetSpeakerName", speakerName);
	}


	public GameObject firstStep;
	 void Start() {
		ConversationsManager.instance.addConversationForSpeaker(speakerName, gameObject);
		ConversationElement[] ces = GetComponentsInChildren<ConversationElement> ();
		foreach (ConversationElement ce in ces) {
			ce.speakerName = speakerName;
		}
//		Debug.Log ("ConversationStart Register done");
	}

	public void StartConversation(){
		firstStep.SetActive (true);
//		Debug.LogWarning ("StartConversation does run on " + firstStep.name);
	}
}