using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class data : MonoBehaviour {

	int ScoreData = 0;
	int CountData = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = "SCORE:" + ScoreData.ToString ("00000");
		GetComponent<Text> ().text = "COUNT:" + CountData.ToString ("000");
	}

	void ScoreUp(){
		if (CountData > 50 && CountData < 151) {
			ScoreData += 100;
		}
	}

	void CountUp(){
		CountData += 10;
	}

}
