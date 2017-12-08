using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eject : MonoBehaviour {
	bool moving = false;
	float endTime = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			transform.position = new Vector3 ((transform.position.x + 5f * Time.deltaTime), transform.position.y, transform.position.z);
			Camera.main.transform.RotateAround (Camera.main.transform.position, Camera.main.transform.forward, 180f * Time.deltaTime);
		}
	}

	public void trainEject() {
		moving = true;
		StartCoroutine (EndGame ());
	}

	public IEnumerator EndGame() {
		yield return new WaitForSeconds (endTime);
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
