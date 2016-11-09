using UnityEngine;
using System.Collections;

public class spawnManager : MonoBehaviour {
    Vector3[] positions = new Vector3[5];

    public GameObject enemyPrefab;

    public bool isSpawn = false;
    public float spawnDelay = 1.5f;
    float spawnTimer = 0f;
    public static spawnManager instance;

    void Awake()
    {
        if (spawnManager.instance == null)
            spawnManager.instance = this;
    }

	// Use this for initialization
	void Start () {
        CreatePositions();
	}

    void SpawnEnemy()
    {
        if (isSpawn == true)
        { //참일경우에만 적을 생성 
            if (spawnTimer > spawnDelay)
            { //타이머에 의한 조건 추가
                //for (int i = 0; i < positions.Length; i++)
                //{
                int rand = Random.Range(0, positions.Length); //Random.Range(시작,끝)
                Instantiate(enemyPrefab, positions[rand], Quaternion.identity);
                    //Instantiate(enemyPrefab, positions[i], Quaternion.identity);
                    //생성위치는 positions라는 배열에 들어있으므로, 첫번째 위치에 생성함.
                //}
                spawnTimer = 0f; //spawnTimer를 0으로 초기화
            }
            spawnTimer += Time.deltaTime; // 루프를 빠져나와서 spawn Timer를 증가함
        }
    }
	// Update is called once per frame
	void Update () {
        SpawnEnemy();
	}

    void CreatePositions()
    {
        float viewPosY = 1.2f;
        float viewPosX = 0f;
        float gapX = 1f / 6f;

        for (int i = 0; i < positions.Length; i++)
        {
            viewPosX = gapX + gapX * i;
            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            worldPos.z = 0f;
            positions[i] = worldPos;
            print(worldPos);
        }
    }
}
