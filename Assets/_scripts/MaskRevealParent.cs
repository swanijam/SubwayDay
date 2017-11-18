using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskRevealParent : MonoBehaviour {
	public void RevealChildren() {
		MaskRevealButton[] buttons = gameObject.GetComponentsInChildren<MaskRevealButton> ();
		foreach (MaskRevealButton b in buttons) {
			b.Reveal ();
		}
	}

	public void HideChildren() {
		MaskRevealButton[] buttons = gameObject.GetComponentsInChildren<MaskRevealButton> ();
		foreach (MaskRevealButton b in buttons) {
			b.Hide ();
		}
	}
}
