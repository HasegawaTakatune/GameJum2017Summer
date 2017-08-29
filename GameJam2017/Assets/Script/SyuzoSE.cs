using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyuzoSE : MonoBehaviour {

    int score = TotalScore.score;

    /*private AudioSource sound;

    [SerializeField]AudioClip[] audioclip;*/

    private AudioSource[] sources;

	// Use this for initialization
	void Start () {
        sources = gameObject.GetComponents<AudioSource>();
        /*if (score >= 0 && score <= 1000){
            sound.PlayOneShot(audioclip[0]);
        }
        else if (score > 1000 && score <= 2000){
            sound.PlayOneShot(audioclip[1]);
        }
        else if (score > 2000 && score <= 3000){
            sound.PlayOneShot(audioclip[2]);
        }
        else if (score > 3000){
            sound.PlayOneShot(audioclip[3]);
        }*/
        if(score >= 0 && score <= 1000)
        {
            sources[0].Play();

        }
        if(score > 1000 && score <= 2000)
        {
            sources[1].Play();
        }
        if(score > 2000 && score <= 3000)
        {
            sources[2].Play();
        }
        if(score > 3000)
        {
            sources[3].Play();
        }
    }

    // Update is called once per frame
    void Update () {
        /*if (Input.GetKey(KeyCode.Space))
        {
            sources[1].Play();
        }*/
    }
}
