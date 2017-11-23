using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour {
	public string speakerName;
	private Animator animator;

	void Start() {
		animator = this.GetComponent<Animator> ();
		ConversationsManager.instance.addSpeaker (speakerName);
	}

	// Update is called once per frame
	void Update () {
		animator.SetInteger ("Character_state", (int)ConversationsManager.instance.speakerStates [speakerName]);
	}

	public void randomConversation() {
		List<GameObject> convosForThisSpeaker = ConversationsManager.instance.conversationLists [speakerName];
		Debug.Log (convosForThisSpeaker.Count);
		foreach (GameObject convo in convosForThisSpeaker) {
			Debug.Log ("convo:");
			Debug.Log (convo.name);
		}
		int r = Random.Range (0, convosForThisSpeaker.Count-1);
		convosForThisSpeaker [r].GetComponent<ConversationStart>().StartConversation();
	}
}
