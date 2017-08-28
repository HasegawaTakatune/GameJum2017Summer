using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atumori_button : MonoBehaviour {

	shuuzou Shuuzou;

	// Use this for initialization
	void Start () {
		Shuuzou = GameObject.Find ("shuuzou").GetComponent<shuuzou> ();
    }

  public void button_push(){
		Shuuzou.shuuzou_red ();
    }
}