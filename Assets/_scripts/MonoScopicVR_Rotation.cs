using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

using XRInput = UnityEngine.XR.InputTracking;


// This script accesses the GoogleVR's rotational input and applies it to this gameObject,
//     without rendering the camera in stereo mode.
// 
// Attach this script to the main camera and turn off VR in the PlayerSettings/XR.
//
public class MonoScopicVR_Rotation : MonoBehaviour {

	public float _turnRate = 10f;
	private float x = 0f;
	private float y = 0f;


	void Start() {
		XRSettings.enabled = false;
		XRInput.disablePositionalTracking = true;
		y = transform.rotation.eulerAngles.x;
		x = transform.rotation.eulerAngles.y;
	}

	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) {
			x += (Input.GetAxis("Mouse X") * _turnRate * Time.deltaTime);
			y -= (Input.GetAxis("Mouse Y") * _turnRate * Time.deltaTime);
			Quaternion rotation = Quaternion.Euler (y, x, 0f);
//			transform.position = rotation * transform.position;
			transform.rotation = rotation;
		}
		#else
		transform.localRotation = XRInput.GetLocalRotation(XRNode.CenterEye);
		Debug.Log (XRInput.GetLocalRotation(XRNode.CenterEye));
		#endif
	}
}