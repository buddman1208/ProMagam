using UnityEngine;
using System.Collections;

public class soundManager : MonoBehaviour {
    public AudioClip soundExplosion;
    AudioSource myAudio;
    public static soundManager instance;
	// Use this for initialization

    //start보다 더 일찍 호출되는 함수
    void Awake(){
        if (soundManager.instance == null)
            soundManager.instance = this;
    }

	void Start () {
        myAudio = GetComponent<AudioSource>();
	}
    public void PlaySound(){
        myAudio.PlayOneShot(soundExplosion);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
