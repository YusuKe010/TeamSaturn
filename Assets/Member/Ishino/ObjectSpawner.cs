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
    [Header("足場の横の生成範囲")]
    public float verticalOffsetX = 50f; // スポーンする間隔
    [Header("一度に生成される岩足場の最大数")]
    public int SpownRocklargest = 2;
    [Header("一度に生成される雲足場の最大数")]
    public int SpownCloudlargest = 1;
    int SpownCount;
    [Header("一番最初に設置する足場の数")]
    public int FastSpown = 5;
    [Header("雲が出現しだす数")]
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

            SpownCount = Random.Range(1, SpownRocklargest+1);
            SpownPos = Random.Range(-verticalOffsetX, verticalOffsetX);
                SpawnObj = Random.Range(0, objectToSpawn.Length);
                // スポーンposition作成
                spawnPosition = SpawnPosition + new Vector3(SpownPos, verticalOffsetY, 0);
            for (int i = 1; i <= SpownCount; i++)
            {
                // オブジェクト生成
                Instantiate(objectToSpawn[SpawnObj], spawnPosition, Quaternion.identity);

                spawnPosition.x = 0;

                // スポーンpositionの位置を調整
                SpawnPosition = spawnPosition;
                
            }
            Objectcount += 1;
            SpawnItem();
        }
        else
        {
            SpownCount = Random.Range(1, SpownCloudlargest+1);
            SpownPos = Random.Range(-verticalOffsetX, verticalOffsetX);
            SpawnObj = Random.Range(0, CloudSpawn.Length);

            // スポーンposition作成
            spawnPosition = SpawnPosition + new Vector3(SpownPos, verticalOffsetY, 0);
            for (int i = 1; i <= SpownCount; i++)
            {
                

                // オブジェクト生成
                Instantiate(CloudSpawn[SpawnObj], spawnPosition, Quaternion.identity);

                spawnPosition.x = 0;

                // スポーンpositionの位置を調整
                SpawnPosition = spawnPosition;
            }
            Objectcount += 1;
            SpawnItem();
        }

        void SpawnItem()
        {
            Vector3 ItemSpawnPosition;
            int　SpawnItemRnd = Random.Range(1, ItemPrefab.Length);
            int ItemRand = Random.Range(1,101);
            ItemOffsetY = verticalOffsetY+ verticalOffsetY*0.5f;
            if (ItemSpawnProbability >= ItemRand)
            {

                //SpownCount = Random.Range(1, SpownRocklargest + 1);
                SpownPos = Random.Range(-verticalOffsetX, verticalOffsetX);

                // スポーンposition作成
                ItemSpawnPosition = SpawnPosition + new Vector3(SpownPos, ItemOffsetY, 0);
                    // オブジェクト生成
                    Instantiate(ItemPrefab[SpawnItemRnd], ItemSpawnPosition, Quaternion.identity);

                ItemSpawnPosition.x = 0;
              
            }
        }

    }
}
