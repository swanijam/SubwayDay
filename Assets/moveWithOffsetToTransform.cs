using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithOffsetToTransform : MonoBehaviour {
//	public Transform capsuleGuy;
//	public Transform replacementGuy;
	// Use this for initialization
	Vector3 difference;

	public void setToSameOffset(Transform original_anchor, Transform new_anchor) {
		Debug.Log ("What even");
		difference = original_anchor.position - transform.position;
		transform.position = new_anchor.position += difference;
	}
}
