using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class order : MonoBehaviour {

    // Use this for initialization

    public enum FoodType { Cow, Pig, Sausage, Vegetables }
    [SerializeField]  FoodType _foodType;

    SpriteRenderer spriteRenderer;
    [SerializeField]Sprite[] sprite;


    int vegetableType = 0;
    void Start () {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        StartCoroutine("Order");
    }
	
	// Update is called once per frame
	void Update () {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    IEnumerator Order()
    {       
        while (true)
        { 
            vegetableType = Random.Range(0, sprite.Length);
            spriteRenderer.sprite = sprite[vegetableType];
            yield return new WaitForSeconds(5f);
        }
    }
}
