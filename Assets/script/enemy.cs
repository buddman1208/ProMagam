using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
    public int killScore = 100;
	public float moveSpeed = 1.5f;
    public GameObject explosionPrefab;
    public GameObject laserPrefab;
	// Use this for initialization
	void Start () {
	
	}
    //충돌하는 순간에 나타나는 효과
    void OnTriggerEnter2D(Collider2D col)
    {
        //print (col.gameObject.name);
        if (col.gameObject.tag == "Laser")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            soundManager.instance.PlaySound();
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            gameManager.instance.AddScore(killScore);
        }
    }
	void moveControl()
	{
		float yMove = moveSpeed * Time.deltaTime;
		transform.Translate (0, -yMove, 0);
	}
	// Update is called once per frame
	void Update () {
		moveControl ();
	}
}
