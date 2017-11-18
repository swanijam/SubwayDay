using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using XRInput = UnityEngine.XR.InputTracking;

public class GazeScript1 : MonoBehaviour {
	public Image reticle;
	public Camera gazeCam;
	public float secondsUntilGaze = 3f;
	public GameObject debugBall;
	public LayerMask _gazeLayerMask;
	public GraphicRaycaster gRaycaster;
	private GraphicRaycaster g;

	GazeResponder potential_gr;
	GazeResponder previous_gr;
	private float continuous_time = 0f;

	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		// do a Physics raycast directly forward from center of the camera. 
		// If it hits something in its mask:
		if (Physics.Raycast (gazeCam.transform.position, gazeCam.transform.forward, out hit, 100f, _gazeLayerMask)) {

			// Check that the object hit is a GazeResponder.
			potential_gr = hit.collider.gameObject.GetComponent<GazeResponder> ();
			if (!potential_gr) {
				potential_gr = hit.collider.gameObject.GetComponentInChildren<ConversationButton> ();
			}
			// If it is:
			if (potential_gr && !potential_gr.inactive) {
				// If we've been looking at this continuously:
				if (potential_gr == previous_gr) {
					continuous_time += Time.deltaTime;
					// If we have been looking at this long enough to qualify as a Gaze action:
					float scale = 1f + ((continuous_time/secondsUntilGaze) * 2f);
					reticle.transform.localScale = new Vector3(scale, scale, scale);
					if (continuous_time >= secondsUntilGaze) {
						reticle.transform.localScale = new Vector3(1f, 1f, 1f);
						Debug.Log ("Gaze Triggered on " + hit.collider.gameObject.name);
						// Notify the GazeResponder and tell it to, uh, respond.
						potential_gr.Invoke ();
						continuous_time = 0f;
					}
					// If we haven't been looking at this continuously: 
				} else {
					continuous_time = 0f;
					previous_gr = potential_gr;
					Debug.Log ("i see a gazresponder " + hit.collider.gameObject.name);
				}					
			} else {
				reticle.transform.localScale = new Vector3(1f, 1f, 1f);
				Debug.Log (hit.collider.gameObject.name);
			}
				

			if (hit.collider.gameObject.tag.Equals ("friend")) {
				reticle.color = Color.green;
			} else if (hit.collider.gameObject.tag.Equals ("dialogButton")) {
				reticle.color = Color.cyan;
			} else {
				reticle.transform.localScale = new Vector3(1f, 1f, 1f);
				reticle.color = Color.white;
			}
		// If it doesn't hit something:
		} else {
			reticle.color = Color.white;
		}

////		Debug.Log (results.Count);
//		foreach (RaycastResult r in results) {
//			if (r.gameObject.GetComponent<GazeResponder> ()) {
//			} else { 
//				Debug.Log ("Not a gaze responder " + r.gameObject.name);
//			}
//		}	
	}
}

