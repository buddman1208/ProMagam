using UnityEngine;
using System.Collections;

public class backscroll : MonoBehaviour {


    public float ScrollSpeed = 1.5f;
    Material myMaterial;

	void Start () {
        myMaterial 
            = GetComponent<Renderer>().material;	
	}
	
	
	void Update () {
        float newOffsetY = myMaterial.mainTextureOffset.y + ScrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(0, newOffsetY);
        myMaterial.mainTextureOffset = newOffset;
	}
}
