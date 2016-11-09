using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
    public Text scoreText;
    public static gameManager instance;
    GameObject player;
    int score = 0;

    void Awake()
    {
        if (gameManager.instance == null)
            gameManager.instance = this;
    }

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        Invoke("StartGame", 3f);
	}
    //사용자 정의 함수
    void StartGame()
    {
        player.GetComponent<player>().canShoot = true;
        spawnManager.instance.isSpawn = true;
    }
    public void AddScore(int enemyScore)
    {
        score += enemyScore;
        print(score);
        scoreText.text = "Score : " + score;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
