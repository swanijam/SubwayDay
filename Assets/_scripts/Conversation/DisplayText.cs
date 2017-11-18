using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour {
	public float lingerTime = 5f;
	[TextArea]
	public string text = "...";
	public GameObject enableAfterLinger;
	public Animator speaker; // Dialogue must come from a speaker, which must have an animator
								// containing the Character_state property.

	void OnEnable() {
		DialogUIManager.instance.SetMainDialogText (text, true);
		// 1 represents the character is speaking
		speaker.SetInteger ("Character_state", 1);
		StartCoroutine (HideText ());
	}

	private IEnumerator HideText (){
		yield return new WaitForSeconds (lingerTime);
		DialogUIManager.instance.SetMainTextActive (false);
		if (!enableAfterLinger || !enableAfterLinger.GetComponent<DisplayText> ()) {
			speaker.SetInteger ("Character_state", 0);
		}

		// this may need to be a in a separate class containing the general behavior of a conversation bit.
		// for now though it's just here.
		if(enableAfterLinger) {enableAfterLinger.SetActive (true);}
		this.gameObject.SetActive (false);
	}
}
