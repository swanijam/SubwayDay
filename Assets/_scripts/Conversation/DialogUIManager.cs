using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public struct ButtonData {
	public string value;
	public UnityEvent action;
}

public class DialogUIManager : MonoBehaviour
{
	public static DialogUIManager instance; 

	public GameObject mainTextPanel;
	public GameObject mainButtonsPanel;
	public GameObject buttonPrefab;

	// Use this for initialization
	void Start ()
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
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
//		clearDialogButtons ();
	}

	public void clearDialogButtons() {
		foreach (Transform childTransform in mainButtonsPanel.transform) Destroy(childTransform.gameObject);
	}
}

