using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 0.8f);
        //0.8초 뒤에 사라져라 0.8안쓰면 바로사라짐
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
