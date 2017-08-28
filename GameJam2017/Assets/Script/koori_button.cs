using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koori_button : MonoBehaviour {

    GameObject refobj;

    // Use this for initialization
    void Start () {
        refobj = GameObject.Find("shuuzou");
    }
	
	// Update is called once per frame
	void Update () {
       

    }

   public void push_button()
    {

        shuuzou color = refobj.GetComponent<shuuzou>();
        //color.shuuzou_blue();

    }
}
