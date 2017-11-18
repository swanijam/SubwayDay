using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AwaitButtonInput : MonoBehaviour {

	public ButtonData[] buttons;

	// Use this for initialization
	void Start () {
		foreach (ButtonData b in buttons) {
			DialogUIManager.instance.AddButton (b);
		}
		DialogUIManager.instance.RevealDialogButtons ();
	}

	void OnDisable() {
		DialogUIManager.instance.HideDialogButtons ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
