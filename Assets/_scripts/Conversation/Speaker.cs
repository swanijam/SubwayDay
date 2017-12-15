using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour {
	public string speakerName;
	private Animator animator;

	void Start() {
		animator = this.GetComponent<Animator> ();
		ConversationsManager.instance.addSpeaker (speakerName, gameObject);
	}

	// Update is called once per frame
	void Update () {
		animator.SetInteger ("Character_state", (int)ConversationsManager.instance.speakerStates [speakerName]);
	}

	public void randomConversation() {
		List<GameObject> convosForThisSpeaker = ConversationsManager.instance.conversationLists [speakerName];
		Debug.Log ("Num conversations found: " + convosForThisSpeaker.Count);
		foreach (GameObject convo in convosForThisSpeaker) {
			Debug.Log ("convo:" + convo.name);
		}
		int r = Random.Range (0, convosForThisSpeaker.Count);
		for (int i = 0; i < 20; i++) {
			Debug.Log (Random.Range (0, convosForThisSpeaker.Count));
		}
		convosForThisSpeaker [r].GetComponent<ConversationStart>().StartConversation();
	}
}
