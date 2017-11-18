using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillateY : MonoBehaviour {
	public float velocityCoefficient = 0f;
	public float amplitude = 0f;

	private float starty;
	// Use this for initialization
	void Start () {
		starty = transform.position.y;
	}
	 
	// Update is called once per frame
	void Update () {
		float y = Mathf.Sin (Time.time * velocityCoefficient) * amplitude + starty;
		Vector3 temp = transform.position;
		temp.y = y;
		transform.position = temp;
	}
}
