using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuuzou : MonoBehaviour {

    //修造の温度 100からー100まで
    public static int ondo;

   //色
    public float red_color;
    public float green_color;
    public float blue_color ;
    public float alpha = 1.0f;

	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        ondo = 0;
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
		StartCoroutine ("shuuzou_blue");
    }
	
	// Update is called once per frame
	void Update () {
		spriteRenderer.color = new Color(red_color, green_color, blue_color, alpha);
    }



    public float shuuzou_red()
    {
        //温度が0以下ならグリーンとレッドカラーを1に戻す
        if (ondo < 0)
        {
            green_color += 0.1f;
            red_color += 0.1f;
        }
        else
        {
            //赤くする
            green_color -= 0.05f;
            blue_color -= 0.05f;
        }
        if(ondo < 99) ondo += 10;
        return 0f;
    }

  

	IEnumerator shuuzou_blue()
    {
		while (true) {
			//温度が0以下ならグリーンとブルーカラーを1に戻す
			if (ondo > 0) {
				green_color += 0.1f;
				blue_color += 0.1f;
			} else {
				//青くする
				green_color -= 0.1f;
				red_color -= 0.1f;
			}

			if (ondo > -99)
				ondo -= 10;
			
			yield return new WaitForSeconds (3f);
		}
    }
}