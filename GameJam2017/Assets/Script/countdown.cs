using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour {

   public static float counterdown = 4;
	Text myText;
    // Use this for initialization
    void Start () {
		counterdown = 4;
        //初期値60を表示
        //float型からint型へCastし、String型に変換して表示
		myText = GetComponent<Text>();
		myText.text = ((int)counterdown).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        //1秒に1ずつ減らしていく
        counterdown -= Time.deltaTime;
        //マイナスは表示しない
		if (counterdown <= 1) {
			TimeSC.time_flg = true;
			StartCoroutine (GameStart ());
		} else {
			myText.text = ((int)counterdown).ToString ();
		}
    }

	IEnumerator GameStart(){
		myText.text = "Start!!";
		yield return new WaitForSeconds (0.5f);
		Destroy(this.gameObject);
	}
}
