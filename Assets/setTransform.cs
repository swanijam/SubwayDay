using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setTransform : MonoBehaviour {
	public Transform target;
	public Transform destination;

	public void swap() {
		target.position = destination.position;
		target.rotation = destination.rotation;
	}
}
