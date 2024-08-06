using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("地上付近で生成するオブジェクト")]
    public GameObject[] objectToSpawn;  // オブジェクトプレハブ
    [Header("空中で生成するオブジェクト")]
    public GameObject[] CloudSpawn;  // オブジェクトプレハブ
    [Header("縦の生成間隔")]
    public float verticalOffsetY = 5f; // スポーンする間隔
    [Header("横の生成半径")]
    public float verticalOffsetX = 50f; // スポーンする間隔
    [Header("一番最初に設置する数")]
    public int FastSpown = 5;
    [Header("プレイヤーのプレハブ")]
    [SerializeField] GameObject PlayerPrefab;
    [Header("プレイヤーのジャンプ")]
    [SerializeField] KeyCode JumpKeyCode = KeyCode.Space;
    int SpawnRnd=1;
    int SpawnObj;
    private Vector3 SpawnPosition;

    void Start()
    {
        SpawnPosition = transform.position;

        for (int i = 0; i <= FastSpown; i++)
        {
            SpawnObject();
        }
    }

    void Update()
    {

        //Playerがジャンプしたときに生成
        if(Input.GetKeyDown(JumpKeyCode))
        {
            SpawnObject();
        }
            

    }

    void SpawnObject()
    {
        Vector3 spawnPosition;
        SpawnRnd = Random.Range(1, 3);   
        SpawnObj = Random.Range(0,objectToSpawn.Length);
        if (SpawnRnd == 1)
        {
            // スポーンposition作成
            spawnPosition = SpawnPosition + new Vector3(verticalOffsetX, verticalOffsetY, 0);

            // オブジェクト生成
            Instantiate(objectToSpawn[SpawnObj], spawnPosition, Quaternion.identity);

            spawnPosition.x = 0;

            // スポーンpositionの位置を調整
            SpawnPosition = spawnPosition;
        }
        else if(SpawnRnd == 2)
        {
            // スポーンposition作成
            spawnPosition = SpawnPosition + new Vector3(-verticalOffsetX, verticalOffsetY, 0);

            // オブジェクト生成
            Instantiate(objectToSpawn[SpawnObj], spawnPosition, Quaternion.identity);

            spawnPosition.x = 0;
            // スポーンpositionの位置を調整
            SpawnPosition = spawnPosition;
        }

    }
}
