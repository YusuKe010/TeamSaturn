using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("崖足場")]
    public GameObject[] objectToSpawn;  // オブジェクトプレハブ
    [Header("雲足場")]
    public GameObject[] CloudSpawn;  // オブジェクトプレハブ
    [Header("アイテム")]
    public GameObject[] ItemSpawn;  // オブジェクトプレハブ
    [Header("足場の縦の生成間隔")]
    public float verticalOffsetY = 5f; // スポーンする間隔
    [Header("足場の横の生成範囲")]
    public float verticalOffsetX = 50f; // スポーンする間隔
    [Header("一度に生成される足場の数")]
    public int SpownCount = 1;
    [Header("一番最初に設置する足場の数")]
    public int FastSpown = 5;
    [Header("空中と判断する数")]
    public int CloudSpown = 10;
    [Header("プレイヤーのプレハブ")]
    [SerializeField] GameObject PlayerPrefab;
    [Header("プレイヤーのジャンプ")]
    [SerializeField] KeyCode JumpKeyCode = KeyCode.Space;
    int SpawnRnd=1;
    float SpownPos;
    int SpawnObj;
    int Objectcount;
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

        if (CloudSpown >= Objectcount)
        {
            for(int i = 0;i <= SpownCount; i++)
            {
                SpownPos = Random.Range(-verticalOffsetX, verticalOffsetX);
                SpawnObj = Random.Range(0, objectToSpawn.Length);
                // スポーンposition作成
                spawnPosition = SpawnPosition + new Vector3(SpownPos, verticalOffsetY, 0);

                // オブジェクト生成
                Instantiate(objectToSpawn[SpawnObj], spawnPosition, Quaternion.identity);

                spawnPosition.x = 0;

                // スポーンpositionの位置を調整
                SpawnPosition = spawnPosition;
                Objectcount += 1;
            }

        }
        else
        {
            for (int i = 0; i <= SpownCount; i++)
            {
                SpownPos = Random.Range(-verticalOffsetX, verticalOffsetX);
                SpawnObj = Random.Range(0, CloudSpawn.Length);
                // スポーンposition作成
                spawnPosition = SpawnPosition + new Vector3(SpownPos, verticalOffsetY, 0);

                // オブジェクト生成
                Instantiate(CloudSpawn[SpawnObj], spawnPosition, Quaternion.identity);

                spawnPosition.x = 0;

                // スポーンpositionの位置を調整
                SpawnPosition = spawnPosition;
            }
        }

    }
}
