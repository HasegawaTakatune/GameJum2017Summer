﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	Text scoreText;

	// Use this for initialization
	void Start () {
		GameMaster.score = 0;
		scoreText = gameObject.GetComponent<Text> ();
		StartCoroutine ("ScoreCount");
	}

	IEnumerator ScoreCount(){
		while (true) {
			scoreText.text = GameMaster.score + "円";
			yield return new WaitForSeconds (0.5f);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}