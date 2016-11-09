using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {
    public float moveSpeed = 0.45f;
	// Use this for initialization
	void Start () {
	
	}
    //화면에서 안보이면 자동으로 삭제해라 (메모리 관리 유용함)
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
	// Update is called once per frame
	void Update () {
        float moveY = moveSpeed * Time.deltaTime;
        transform.Translate(0, moveY, 0);
	}
}
