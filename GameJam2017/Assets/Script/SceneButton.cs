using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour {
	[SerializeField]string NextSceneName;
	public void OnClickNextScene(){
		SceneManager.LoadScene (NextSceneName);
	}
}