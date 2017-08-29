using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeSC : MonoBehaviour {

    public static float timecounter;
    public static bool time_flg;
    // Use this for initialization
    void Start () {
		timecounter = 60;
		time_flg = false;
        //初期値60を表示
        //float型からint型へCastし、String型に変換して表示
        GetComponent<Text>().text = ((int)timecounter).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (time_flg == true)
        {
            //1秒に1ずつ減らしていく
            timecounter -= Time.deltaTime;
            //マイナスは表示しない
            if (timecounter < 0)
            {
                timecounter = 0;
                SceneManager.LoadScene("Result");
            }
            GetComponent<Text>().text = ((int)timecounter).ToString();
        }
    }
}
