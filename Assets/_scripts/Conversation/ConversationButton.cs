using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConversationButton : GazeResponder {
	private string btnText; // This is the backing field
	public string buttonText// This is your property
	{
		get {
			return btnText;
		}
		set {
			btnText = value;
			GetComponentInChildren<Text> ().text = value;
		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public override void  Invoke() {
		base.Invoke ();
		Debug.Log ("this happened");
		DialogUIManager.instance.HideDialogButtons ();
	}
}
