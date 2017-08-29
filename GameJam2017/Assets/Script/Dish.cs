using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour {

	[SerializeField]List<GameObject> list = new List<GameObject>();

	Vector3 movement = new Vector3 (.3f, 0, 0);
	bool Escape = false;
	public enum MoveType
	{
		Stop,Escape,Return
	}
	MoveType moveType = MoveType.Stop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
		if (list.Count >= 5) {
			moveType = MoveType.Escape;
			StartCoroutine (Move ());
		}
		switch (moveType) {
		case MoveType.Stop:
			break;
		case MoveType.Escape:
			foreach (GameObject g in list) {
				g.transform.position -= movement;
			}
			transform.position -= movement;
			break;
		case MoveType.Return:
			foreach (GameObject g in list) {
				g.transform.position += movement;
			}
			transform.position += movement;
			break;
		}
	}

	IEnumerator Move(){
		yield return new WaitForSeconds (.5f);
		moveType = MoveType.Return;
		while(true){
			if (list.Count <= 0)
				break;
			Destroy (list [0]);
			list.RemoveAt (0);
		}
		StartCoroutine (ReturnTime ());
	}

	IEnumerator ReturnTime(){
		yield return new WaitForSeconds (.5f);
		moveType = MoveType.Stop;
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Food")
			list.Add (other.gameObject);
	}
}
