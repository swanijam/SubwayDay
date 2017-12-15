using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SPEAKER_STATE {
	IDLE,
	WAKING_UP,
	SPEAKING,
	LISTENING
}

public class ConversationsManager : MonoBehaviour {
	public Dictionary<string, List<GameObject>> conversationLists;
	public Dictionary<string, SPEAKER_STATE> speakerStates;
	public Dictionary<string, GameObject> theSpeakersThemselves;

	public static ConversationsManager instance;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			conversationLists = new Dictionary<string, List<GameObject>> ();
			speakerStates = new Dictionary<string, SPEAKER_STATE>();
			theSpeakersThemselves = new Dictionary<string, GameObject>();
			Debug.Log ("Registered new instance of Conversations Manager");
		} else if (instance == this) {
			Debug.Log ("Singleton instance of Conversations Manager already registered");
		} else {
			Destroy (gameObject);
			Debug.Log ("Destroyed extra instance of Conversations Manager");
		}
	}

	// Overloaded for use by the speaker object itself for the purposes of easily appending
	//  the ability to add 
	public void addSpeaker (string speaker, GameObject obj) {
		theSpeakersThemselves.Add (speaker, obj);
		addSpeaker (speaker);
	}
		
	public void addSpeaker (string speaker) {
		if (!speakerStates.ContainsKey(speaker)) {
			conversationLists.Add (speaker, new List<GameObject> ());
			speakerStates.Add (speaker, SPEAKER_STATE.IDLE);
			Debug.Log ("Initialized new conversation list for " + speaker);
		} else {
			Debug.Log ("Attempted to add speaker but speaker already exists");
		}
	}

	public void addConversationForSpeaker (string speaker, GameObject conversation) {
		if (conversationLists.ContainsKey(speaker)) {
			conversationLists [speaker].Add (conversation);
			Debug.Log ("Added conversaiton : " + conversation.name + " For speaker: " + speaker);
		} else {
			addSpeaker (speaker);
			conversationLists [speaker].Add (conversation);
			Debug.Log ("Adding speaker because it wasn't recognized: " + speaker); 
		}
	}

	public void setSpeakerState(string speaker, SPEAKER_STATE state) {
		if (speakerStates.ContainsKey(speaker)) {
			Debug.Log ("Speaker " + speaker + " exists. setting SpeakerState.");
			speakerStates [speaker] = state;
			Debug.Log ("Speaker " + speaker + " animtion state: " + speakerStates[speaker]);
		} else {
			addSpeaker (speaker);
			speakerStates [speaker] = state;
		}
	}
}
