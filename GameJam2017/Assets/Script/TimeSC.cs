using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeSC : MonoBehaviour {
	Text timerText;
	int timer;
    public static bool time_flg;

    // Use this for initialization
    void Start () {
		timer = 60;
		time_flg = false;
		timerText = GetComponent<Text> ();
		timerText.text = timer.ToString ();

		StartCoroutine (GameTimer());
    }

	IEnumerator GameTimer(){
		while (true) {
			if (time_flg) {
				timer--;
				timerText.text = timer.ToString ();
				if (timer < 0)
					GameEnd ();
			}
			yield return new WaitForSeconds (1f);
		}
	}
	void GameEnd(){
		timer = 0;
		SceneManager.LoadScene ("Result");
	}
}
