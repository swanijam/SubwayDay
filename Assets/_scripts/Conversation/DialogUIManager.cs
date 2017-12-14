using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public struct ButtonData {
	public string value;
	public UnityEvent action;
}

public class DialogUIManager : Singleton<DialogUIManager>
{
	public GameObject mainTextPanel;
	public GameObject mainButtonsPanel;
	public GameObject buttonPrefab;
	// Currently accessed directly by GazeScript, but not used in any DialogUIManager functions. (I wanted to make sure 
	//  everything UI related flows through here)
	public GameObject Reticle_parent;
	public GameObject Reticle_inner;

	// Use this for initialization
	void Start ()
	{
	}

	public void SetMainDialogText(string value, bool showImmediately) {
		mainTextPanel.GetComponentInChildren<Text> ().text = value;
		if (showImmediately) {
			SetMainTextActive (true);
		}
	}

	public void SetMainTextActive (bool active) {
		mainTextPanel.SetActive(active);
	}

	public void AddButton(ButtonData b) {
		GameObject button = Instantiate (buttonPrefab, mainButtonsPanel.transform);
		ConversationButton gr = button.GetComponentInChildren<ConversationButton> ();
		Logg.LogList (b.value, b.action != null, gr);
		gr.buttonText = b.value;
		gr.onGaze = b.action;

	}

	public void RevealDialogButtons() {
		mainButtonsPanel.BroadcastMessage ("Reveal");
	}

	public void HideDialogButtons(){
		mainButtonsPanel.BroadcastMessage ("Hide", null, SendMessageOptions.DontRequireReceiver);
		ClearDialogButtons ();
	}

	public void ClearDialogButtons() {
		foreach (Transform childTransform in mainButtonsPanel.transform) Destroy(childTransform.gameObject);
	}
}

