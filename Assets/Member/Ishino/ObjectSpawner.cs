using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("�R����")]
    public GameObject[] objectToSpawn;  // �I�u�W�F�N�g�v���n�u
    [Header("�_����")]
    public GameObject[] CloudSpawn;  // �I�u�W�F�N�g�v���n�u
    [Header("�A�C�e��")]
    public GameObject[] ItemPrefab;  // �I�u�W�F�N�g�v���n�u
    [Header("�A�C�e���o����")] [Range(0, 100)]
    public int ItemSpawnProbability;
    [Header("����̏c�̐����Ԋu")]
    public float verticalOffsetY = 5f; // �X�|�[������Ԋu
    float ItemOffsetY = 0f; // �A�C�e�����X�|�[������Ԋu
    [Header("����̉��̐����͈͍�")]
    public float verticalOffsetXLeft = -3f; // �X�|�[������Ԋu
    [Header("����̉��̐����͈͉E")]
    public float verticalOffsetXRight = 3f; // �X�|�[������Ԋu

    [Header("��x�ɐ��������⑫��̍ő吔")]
    public int SpownRocklargest = 2;
    [Header("��x�ɐ��������_����̍ő吔")]
    public int SpownCloudlargest = 1;
    int SpownCount;
    [Header("��ԍŏ��ɐݒu���鑫��̐�")]
    public int FastSpown = 5;
    [Header("�_���o����������")]
    public int CloudSpown = 10;
    [Header("�v���C���[�̃W�����v")]
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

        //Player���W�����v�����Ƃ��ɐ���
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
                // �X�|�[��position�쐬
                spawnPosition = SpawnPosition + new Vector3(0, verticalOffsetY, 0);
                spawnPosition.x = SpownPos;
            for (int i = 1; i <= SpownCount; i++)
            {
                // �I�u�W�F�N�g����
                Instantiate(objectToSpawn[SpawnObj], spawnPosition, Quaternion.identity);                

                // �X�|�[��position�̈ʒu�𒲐�
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

            // �X�|�[��position�쐬
            spawnPosition = SpawnPosition + new Vector3(SpownPos, verticalOffsetY, 0);
            spawnPosition.x = SpownPos;
            for (int i = 1; i <= SpownCount; i++)
            {
                

                // �I�u�W�F�N�g����
                Instantiate(CloudSpawn[SpawnObj], spawnPosition, Quaternion.identity);

                spawnPosition.x = Fastposition.x;

                // �X�|�[��position�̈ʒu�𒲐�
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

                // �X�|�[��position�쐬
                ItemSpawnPosition = SpawnPosition + new Vector3(0, ItemOffsetY, 0);
                //ItemSpawnPosition.x = ItemOffsetY;
                    // �I�u�W�F�N�g����
                    Instantiate(ItemPrefab[SpawnRnd], ItemSpawnPosition, Quaternion.identity);

                ItemSpawnPosition.x = Fastposition.x;
              
            }
        }

    }
}
