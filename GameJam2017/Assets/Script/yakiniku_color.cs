using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yakiniku_color : MonoBehaviour {
    //焼き加減、0から40生40から70生焼け70から90焼けてる100焦げ
    public float yakikagen = 0;

	private int yakiniku_ondo = 1;

	public Color color = new Color (1, 1, 1, 1);

	SpriteRenderer spriteRenderer;

	public bool put = false;

   // Use this for initialization
    void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
    }
	
	// Update is called once per frame
	void Update () {
		spriteRenderer.color = color;
        //修造の温度取得 
		yakiniku_ondo = shuuzou.ondo;
    }

	public IEnumerator Yakiniku()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            if (yakiniku_ondo > 70)
            {
				color.g -= 0.05f;
				color.b -= 0.1f;

                yakikagen += 14;
				if (yakikagen > 70) color.r -= 0.15f;
            }
            else if (yakiniku_ondo > 40)
            {
				color.g -= 0.025f;
				color.b -= 0.05f;

                yakikagen += 7;
				if (yakikagen > 70) color.r -= 0.075f;
            }
            else if (yakiniku_ondo > 10)
            {
				color.g -= 0.01f;
				color.b -= 0.02f;

                yakikagen += 2.8f;
				if (yakikagen > 70) color.r -= 0.03f;
            }
        }
    }

 }
