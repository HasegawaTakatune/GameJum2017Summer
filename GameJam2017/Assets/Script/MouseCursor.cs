using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour {
	bool GamePlay = false;

	[SerializeField]
	RaycastHit2D isMouse;

	[SerializeField]
	GameObject item;
	yakiniku_color yakiniku;

	// ワールド座標
	Vector3 worldPos;

	Vector3 originalPos = Vector3.zero;

	bool doOnce = false;

	[SerializeField]
	AudioClip[] audioClip;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		StartCoroutine ("GameStart");
	}

	// Update is called once per frame
	void Update () {
		MousePosition ();
		transform.position = worldPos;
		if (GamePlay) {
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
	}

	void MouseClick(){
		if (item == null) {
			isMouse = Physics2D.Raycast (worldPos, Vector3.back, -1, 1 << LayerMask.NameToLayer ("Food"));
			if (isMouse) {
				item = isMouse.collider.gameObject;
				yakiniku = item.GetComponent<yakiniku_color> ();
				if (!doOnce && !yakiniku.put) {
					Instantiate (item, item.transform.position, Quaternion.identity);
					yakiniku.put = true;
				}
				originalPos = item.transform.position - worldPos;
				doOnce = true;		
				yakiniku.Bake = false;
			}
		}
	}

	void MouseUp(){
		RaycastHit2D isNet = Physics2D.Raycast (worldPos, Vector3.back, -1, 1 << LayerMask.NameToLayer ("Net"));
		RaycastHit2D isDish = Physics2D.Raycast (worldPos, Vector3.back, -1, 1 << LayerMask.NameToLayer ("BBQdish"));
		if (isNet) {
			StartCoroutine (yakiniku.Yakiniku());
			yakiniku.Bake = true;
		}
		else if(isDish){
			float annealing = yakiniku.annealing;
			if (annealing > 20 && annealing <= 90) {
				GameMaster.score += yakiniku.point;
			}
			int i = Random.Range (0, audioClip.Length);
			audioSource.PlayOneShot (audioClip [i]);
		} else {
			
		}
		item = null;
		yakiniku = null;
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

	IEnumerator GameStart(){
		yield return new WaitForSeconds (3f);
		GamePlay = true;
	}

}
