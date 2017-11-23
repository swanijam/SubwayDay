using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatAtoB : MonoBehaviour {
	public Transform pointA;
	public Transform pointB;
	public float velocity = 0f;

	// Use this for initialization
	void Start () {
		transform.position = pointA.position;
	}
	 
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, pointB.position, (velocity * Time.deltaTime));
		if (Vector3.Distance (transform.position, pointB.position) < .1f) {
			transform.position = pointA.position;
		}
	}
}
