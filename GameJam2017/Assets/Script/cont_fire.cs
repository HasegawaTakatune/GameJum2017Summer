using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cont_fire : MonoBehaviour {

    public GameObject[] fire_obj;

    //public GameObject fire_kijun;
    //ひを消すか消さないか
   public bool[] fire_flg = { false, false, false, false, false, false, false, false };
    //温度が何度以上になったらの何度
    int[] ondo_flg = {20, 30, 40, 50, 60, 70, 80, 90};
    //xとy座標
     public float[] x;
    //private float[] y = { -2.5f, -4, -5.5f, -4, -2.5f, -1, 0.5f, 1.5f};

    // Use this for initialization
    void Start () {
		for(int i = 0; i < 8; i++)
        {
            x[i] = fire_obj[i].transform.position.x;
            fire_obj[i].transform.position = new Vector3(50, fire_obj[i].transform.position.y, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {

       

        for(int i = 0; i < 8; i++)
        {
            //温度が基準以上になったら火をだす
            if (shuuzou.ondo >= ondo_flg[i] && fire_flg[i] == false)
            {
                fire_obj[i].transform.position = new Vector3(x[i], fire_obj[i].transform.position.y, 0);
                fire_flg[i] = true;
            }
            //基準以下で消す
            else if (shuuzou.ondo <= ondo_flg[i] && fire_flg[i] == true)
            {
                //Destroy(fire_obj[i]);
                fire_obj[i].transform.position = new Vector3(50, fire_obj[i].transform.position.y, 0);
                fire_flg[i] = false;
            }   
               
        }

	}
}
