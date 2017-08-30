using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyuzoSE : MonoBehaviour {

	int score = GameMaster.score;

	[SerializeField] AudioSource audioSource;
	[SerializeField] AudioClip[] audioClip = new AudioClip[4];

    // Use this for initialization
	void Start () {
		if (audioClip == null)
			audioSource = gameObject.GetComponent<AudioSource> ();
		
		if (score >= 0 && score <= 1000)
			audioSource.PlayOneShot (audioClip [0]);
		else if (score > 1000 && score <= 2000)
			audioSource.PlayOneShot (audioClip [1]);
		else if (score > 2000 && score <= 3000)
			audioSource.PlayOneShot (audioClip [2]);
		else
			audioSource.PlayOneShot (audioClip [3]);
	}

	public void OnClick(){
		int i = Random.Range (0, audioClip.Length);
		audioSource.PlayOneShot (audioClip [i]);
	}
}
