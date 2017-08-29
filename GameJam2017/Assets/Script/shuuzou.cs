using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuuzou : MonoBehaviour {

    //修造の温度 100からー100まで
    public static int ondo;

   //色
	[SerializeField]Color color;

	SpriteRenderer spriteRenderer;

	public enum TurnType
	{
		None,Rught,Left
	}
	TurnType turnType = TurnType.None;
	float zz = 0;
	bool call = false;

	// Use this for initialization
	void Start () {
		ondo = 0;
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
		StartCoroutine ("shuuzou_blue");
    }
	
	// Update is called once per frame
	void Update () {
		spriteRenderer.color = color;

		switch (turnType) {
		case TurnType.None:
			break;
		case TurnType.Rught:
			zz -= .1f;
			transform.Rotate (0, 0, zz);
			break;
		case TurnType.Left:
			zz += .1f;
			transform.Rotate (0, 0, zz);
			break;
		}
    }



	public void shuuzou_red()
    {
		if (gameObject.transform.localScale.x <= 2) {
			gameObject.transform.localScale = new Vector3 (
				gameObject.transform.localScale.x + 0.08f,
				gameObject.transform.localScale.y + 0.08f,
				gameObject.transform.localScale.z
			);
		}

        //温度が0以下ならグリーンとレッドカラーを1に戻す
        if (ondo < 0)
        {
			color = new Color (color.r + .1f, color.g + .1f, color.b);
        }
        else
        {
            //赤くする
			color = new Color (color.r, color.g - .05f, color.b - .05f);
        }
        if(ondo < 99) ondo += 15;

		if (!call) {
			call = true;
			StartCoroutine (Rota ());
		}
    }

	IEnumerator Rota(){
		zz = 0;
		turnType = TurnType.Left;
		yield return new WaitForSeconds (.5f);
		zz = 0;
		turnType = TurnType.Rught;
		yield return new WaitForSeconds (1f);
		zz = 0;
		turnType = TurnType.Left;
		yield return new WaitForSeconds (1f);
		zz = 0;
		turnType = TurnType.Rught;
		yield return new WaitForSeconds (.5f);
		zz = 0;
		turnType = TurnType.None;
		call = false;
	}

  

	IEnumerator shuuzou_blue()
    {
		float time = 5f;
		while (true) {
			if (gameObject.transform.localScale.x > 1) {
				gameObject.transform.localScale = new Vector3 (
					gameObject.transform.localScale.x - 0.01f,
					gameObject.transform.localScale.y - 0.01f,
					gameObject.transform.localScale.z);
			}

			//温度が0以下ならグリーンとブルーカラーを1に戻す
			if (ondo > 0) {
				color = new Color (color.r, color.g + .1f, color.b - .1f);
			} else {
				//青くする
				color = new Color (color.r-.1f, color.g + .1f, color.b);
			}

			if (ondo > -99)
				ondo -= 10;
			
			yield return new WaitForSeconds (time);
			time = 3f;
		}
    }
}