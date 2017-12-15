using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
	public List<AudioClip> bg_music;
	// Use this for initialization
	void Start () {
		RandomSong ();
		StartCoroutine(SwitchSongsWhenDonePlaying());
	}
	
	public void RandomSong(){
		gameObject.GetComponent<AudioSource> ().Stop ();
		gameObject.GetComponent<AudioSource> ().clip = bg_music [Random.Range (0, bg_music.Count - 1)];
		gameObject.GetComponent<AudioSource> ().Play ();
	}

	IEnumerator SwitchSongsWhenDonePlaying(){
		yield return new WaitForSeconds (5f);
		if (!gameObject.GetComponent<AudioSource> ().isPlaying) {
			RandomSong ();
		}
	}
}
