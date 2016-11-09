using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public float moveSpeed = 0.5f;
    public GameObject explosionPrefab;
    public GameObject laserPrefab;
    public bool canShoot = false;
    float shootDelay = 0.3f;
    double shootTimer = 0;

	// Use this for initialization
	void Start () {

	}
    void ShootControl(){
        if (canShoot == true)
        {
            if (Input.GetKey(KeyCode.Z) == true)
            {
                if (shootTimer > shootDelay)
                {
                    Instantiate(laserPrefab, transform.position, Quaternion.identity);
                    shootTimer = 0.2;
                }
                shootTimer += Time.deltaTime;
            }
        }
    }

    //충돌하는 순간에 나타나는 효과
	void OnTriggerEnter2D(Collider2D col)
	{
		//print (col.gameObject.name);
		if (col.gameObject.tag == "Enemy")
		{
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            soundManager.instance.PlaySound();
			Destroy (col.gameObject);
			Destroy (this.gameObject);
		}
	}
	void MoveControl(){
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        // float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.Translate(moveX, 0, 0);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        //print(viewPos);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
        //print(Input.GetAxis("Horizontal"));


    }
	// Update is called once per frame
	void Update () {
        MoveControl();
        ShootControl();
	}
}
