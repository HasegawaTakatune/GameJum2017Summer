using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	static int _score;
	static public int score{ get { return _score; } set { _score = value; } }
}
