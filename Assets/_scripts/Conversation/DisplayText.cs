using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour {
	public float lingerTime = 5f;
	[TextArea]
	public string text = "...";
	public GameObject enableAfterLinger;

	void OnEnable() {
		DialogUIManager.instance.SetMainDialogText (text, true);
		StartCoroutine (HideText ());
	}

	private IEnumerator HideText (){
		yield return new WaitForSeconds (lingerTime);
		DialogUIManager.instance.SetMainTextActive (false);

		// this may need to be a in a separate class containing the general behavior of a conversation bit.
		// for now though it's just here.
		if(enableAfterLinger) {enableAfterLinger.SetActive (true);}
		this.gameObject.SetActive (false);
	}
}
