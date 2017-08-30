using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

	void Start() {
		this.GetComponent<Text>().text = "合計金額 : " + GameMaster.score + "円";
	}

}
