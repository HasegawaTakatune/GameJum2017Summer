using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atumori_button : MonoBehaviour {

	shuuzou Shuuzou;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		Shuuzou = GameObject.Find ("shuuzou").GetComponent<shuuzou> ();
    }

  public void button_push(){
		Shuuzou.shuuzou_red ();
			audioSource.PlayOneShot(audioSource.clip);
    }
}