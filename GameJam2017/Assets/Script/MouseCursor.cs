using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour {

	[SerializeField]
	RaycastHit2D isMouse;

	[SerializeField]
	GameObject item;
	yakiniku_color yakiniku;

	// ワールド座標
	Vector3 worldPos;

	Vector3 originalPos = Vector3.zero;

	bool doOnce = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		MousePosition ();
		transform.position = worldPos;
		if (Input.GetMouseButton (0)) {
			MouseClick ();
		}
		if (Input.GetMouseButtonUp (0) && item != null) {
			MouseUp ();
		}
		if (item != null) {
			item.transform.position = worldPos + originalPos;
		}
	}

	void MouseClick(){
		if (item == null) {
			isMouse = Physics2D.Raycast (worldPos, Vector3.back, -1, 1 << LayerMask.NameToLayer ("Food"));
			if (isMouse) {
				item = isMouse.collider.gameObject;
				yakiniku = item.GetComponent<yakiniku_color> ();
				if (!doOnce) {
					if (!yakiniku.put) {
						Instantiate (item, item.transform.position, Quaternion.identity);
						yakiniku.put = true;
					}
					originalPos = item.transform.position - worldPos;
					doOnce = true;
				}
			}
		}
	}

	void MouseUp(){
		isMouse = Physics2D.Raycast (worldPos, Vector3.back, -1, 1 << LayerMask.NameToLayer ("Net"));
		if (isMouse) {
		} else {
			Destroy (item);
		}
		StartCoroutine (item.GetComponent<yakiniku_color> ().Yakiniku());
		item = null;
		doOnce = false;
	}

	void MousePosition(){
		// クリック座標
		Vector3 clickPos;
		// クリック座標
		clickPos = Input.mousePosition;
		clickPos.z = 10;
		// ワールド座標に変換
		worldPos = Camera.main.ScreenToWorldPoint (clickPos);
	}

}
