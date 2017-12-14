using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskRevealButton : MonoBehaviour {
	public float animTime = 3f;
	public RectTransform mask;
	public RectTransform button;
	public Text label;


	private float currentTime = 0f;
	private bool revealing = false;
	private bool hiding = false;

	Watch_Linear wl;

	// Use this for initialization
	void Start () {
		wl = new Watch_Linear(new TimeCurve_Linear(.5f, 0f));
	}
	
	// Update is called once per frame
	void Update () {
		
		if (revealing) {
			Debug.Log ("whatchu doin");
			float x = Mathf.Min ((currentTime / animTime), 1f);
			currentTime += Time.deltaTime;
			button.SetParent (transform);
			mask.anchorMax = new Vector2 (x, mask.anchorMax.y);
			button.SetParent (mask.transform);
			if (currentTime >= animTime) {
				mask.anchorMax = new Vector2 (1f, mask.anchorMax.y);
				currentTime = 0f;
				revealing = false;
			}
		} else if (hiding) {
			float x = Mathf.Max ((1f - (currentTime / animTime)), 0f);
			currentTime += Time.deltaTime;
			button.SetParent (transform);
			mask.anchorMax = new Vector2 (x, mask.anchorMax.y);
			button.SetParent (mask.transform);
			if (currentTime >= animTime) {
				mask.anchorMax = new Vector2 (0f, mask.anchorMax.y);
				currentTime = 0f;
				hiding = false;
				gameObject.SetActive (false);
			}
		}
	}

	public void Reveal() {
		revealing = true;
		currentTime = 0f;
		hiding = false;
	}

	public void Hide() {
		revealing = false;
		currentTime = 0f;
		hiding = true;
	}
}
