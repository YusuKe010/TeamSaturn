using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("崖足場")]
    public GameObject[] objectToSpawn;  // オブジェクトプレハブ
    [Header("雲足場")]
    public GameObject[] CloudSpawn;  // オブジェクトプレハブ
    [Header("アイテム")]
    public GameObject[] ItemPrefab;  // オブジェクトプレハブ
    [Header("アイテム出現率")] [Range(0, 100)]
    public int ItemSpawnProbability;
    [Header("足場の縦の生成間隔")]
    public float verticalOffsetY = 5f; // スポーンする間隔
    float ItemOffsetY = 0f; // アイテムがスポーンする間隔
    [Header("足場の横の生成範囲左")]
    public float verticalOffsetXLeft = -3f; // スポーンする間隔
    [Header("足場の横の生成範囲右")]
    public float verticalOffsetXRight = 3f; // スポーンする間隔

    [Header("一度に生成される岩足場の最大数")]
    public int SpownRocklargest = 2;
    [Header("一度に生成される雲足場の最大数")]
    public int SpownCloudlargest = 1;
    int SpownCount;
    [Header("一番最初に設置する足場の数")]
    public int FastSpown = 5;
    [Header("雲が出現しだす数")]
    public int CloudSpown = 10;
    [Header("プレイヤーのジャンプ")]
    [SerializeField] KeyCode JumpKeyCode = KeyCode.Space;
    int SpawnRnd=1;
    float SpownPos;
    int SpawnObj;
    int Objectcount;
    private Vector3 SpawnPosition;
    private Vector3 Fastposition;

    void Start()
    {
        SpawnPosition = transform.position;
        Fastposition = transform.position;
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
       

        if (CloudSpown >= Objectcount)
        {

            SpownCount = Random.Range(1, SpownRocklargest+1);
            SpownPos = Random.Range(verticalOffsetXLeft,verticalOffsetXRight);
                SpawnObj = Random.Range(0, objectToSpawn.Length);
                // スポーンposition作成
                spawnPosition = SpawnPosition + new Vector3(0, verticalOffsetY, 0);
                spawnPosition.x = SpownPos;
            for (int i = 1; i <= SpownCount; i++)
            {
                // オブジェクト生成
                Instantiate(objectToSpawn[SpawnObj], spawnPosition, Quaternion.identity);                

                // スポーンpositionの位置を調整
                SpawnPosition = spawnPosition;                
                spawnPosition.x = Fastposition.x;
            }
            
            Objectcount += 1;
            SpawnItem();
        }
        else
        {
            SpownCount = Random.Range(1, SpownCloudlargest+1);
            SpownPos = Random.Range(verticalOffsetXLeft, verticalOffsetXRight);
            SpawnObj = Random.Range(0, CloudSpawn.Length);

            // スポーンposition作成
            spawnPosition = SpawnPosition + new Vector3(SpownPos, verticalOffsetY, 0);
            spawnPosition.x = SpownPos;
            for (int i = 1; i <= SpownCount; i++)
            {
                

                // オブジェクト生成
                Instantiate(CloudSpawn[SpawnObj], spawnPosition, Quaternion.identity);

                spawnPosition.x = Fastposition.x;

                // スポーンpositionの位置を調整
                SpawnPosition = spawnPosition;
            }
            Objectcount += 1;
            SpawnItem();
        }

        void SpawnItem()
        {
            Vector3 ItemSpawnPosition;
            SpawnRnd = Random.Range(0, ItemPrefab.Length);
            int ItemRand = Random.Range(1,101);
            ItemOffsetY = verticalOffsetY+ verticalOffsetY*0.5f;
            if (ItemSpawnProbability >= ItemRand)
            {

                //SpownCount = Random.Range(1, SpownRocklargest + 1);
                SpownPos = Random.Range(verticalOffsetXLeft, verticalOffsetXRight);

                // スポーンposition作成
                ItemSpawnPosition = SpawnPosition + new Vector3(0, ItemOffsetY, 0);
                //ItemSpawnPosition.x = ItemOffsetY;
                    // オブジェクト生成
                    Instantiate(ItemPrefab[SpawnRnd], ItemSpawnPosition, Quaternion.identity);

                ItemSpawnPosition.x = Fastposition.x;
              
            }
        }

    }
}
