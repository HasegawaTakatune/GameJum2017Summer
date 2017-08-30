using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yakiniku_color : MonoBehaviour {
    //焼き加減、0から40生40から70生焼け70から90焼けてる100焦げ
	[SerializeField]  float _annealing = 0;
	public float annealing { get { return _annealing; }set { _annealing = value; } }

	private int yakiniku_ondo = 1;

	public bool put = false;
	public bool Bake = false;

	[SerializeField]  int _point = 0;
	public int point { get { return _point; } set { _point = value; } }

	public enum FoodType { Cow , Pig , Sausage , Vegetables }
	[SerializeField] FoodType _foodType;
	public FoodType foodType { get { return _foodType; }set { _foodType = value; } }
	int vegetableType = 0;

	SpriteRenderer spriteRenderer;
	[SerializeField]Sprite[] sprite;

	[SerializeField]Sprite[] GrilledMaterial = new Sprite[2];

   // Use this for initialization
    void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer> ();

		if (_foodType == FoodType.Vegetables) {
			vegetableType = Random.Range (0, sprite.Length);
			spriteRenderer.sprite = sprite [vegetableType];
		}
    }
	
	// Update is called once per frame
	void Update () {
		//修造の温度取得 
		yakiniku_ondo = shuuzou.ondo;
    }

	public IEnumerator Yakiniku(){
		while (true) {
			yield return new WaitForSeconds (1.0f);

			if (yakiniku_ondo > 70) {
				_annealing += 14;
			} else if (yakiniku_ondo > 40) {
				_annealing += 7;
			} else if (yakiniku_ondo > 10) {
				_annealing += 2.8f;
			}

			if (_foodType != FoodType.Vegetables) {
				if (_annealing > 90)
					spriteRenderer.sprite = GrilledMaterial [1];
				else if (_annealing > 20)
					spriteRenderer.sprite = GrilledMaterial [0];
			} else {
				if (_annealing > 90)
					spriteRenderer.sprite = GrilledMaterial [vegetableType * 2 + 1];
				else if (_annealing > 20)
					spriteRenderer.sprite = GrilledMaterial [vegetableType * 2];
			}
			if (!Bake)
				break;
		}
    }

 }
