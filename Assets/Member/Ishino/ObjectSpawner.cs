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
    [Header("����̉��̐����͈�")]
    public float verticalOffsetX = 50f; // �X�|�[������Ԋu
    [Header("��x�ɐ��������⑫��̍ő吔")]
    public int SpownRocklargest = 2;
    [Header("��x�ɐ��������_����̍ő吔")]
    public int SpownCloudlargest = 1;
    int SpownCount;
    [Header("��ԍŏ��ɐݒu���鑫��̐�")]
    public int FastSpown = 5;
    [Header("�_���o����������")]
    public int CloudSpown = 10;
    [Header("�v���C���[�̃v���n�u")]
    [SerializeField] GameObject PlayerPrefab;
    [Header("�v���C���[�̃W�����v")]
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

        //Player���W�����v�����Ƃ��ɐ���
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
                // �X�|�[��position�쐬
                spawnPosition = SpawnPosition + new Vector3(SpownPos, verticalOffsetY, 0);
            for (int i = 1; i <= SpownCount; i++)
            {
                // �I�u�W�F�N�g����
                Instantiate(objectToSpawn[SpawnObj], spawnPosition, Quaternion.identity);

                spawnPosition.x = 0;

                // �X�|�[��position�̈ʒu�𒲐�
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

            // �X�|�[��position�쐬
            spawnPosition = SpawnPosition + new Vector3(SpownPos, verticalOffsetY, 0);
            for (int i = 1; i <= SpownCount; i++)
            {
                

                // �I�u�W�F�N�g����
                Instantiate(CloudSpawn[SpawnObj], spawnPosition, Quaternion.identity);

                spawnPosition.x = 0;

                // �X�|�[��position�̈ʒu�𒲐�
                SpawnPosition = spawnPosition;
            }
            Objectcount += 1;
            SpawnItem();
        }

        void SpawnItem()
        {
            Vector3 ItemSpawnPosition;
            int�@SpawnItemRnd = Random.Range(1, ItemPrefab.Length);
            int ItemRand = Random.Range(1,101);
            ItemOffsetY = verticalOffsetY+ verticalOffsetY*0.5f;
            if (ItemSpawnProbability >= ItemRand)
            {

                //SpownCount = Random.Range(1, SpownRocklargest + 1);
                SpownPos = Random.Range(-verticalOffsetX, verticalOffsetX);

                // �X�|�[��position�쐬
                ItemSpawnPosition = SpawnPosition + new Vector3(SpownPos, ItemOffsetY, 0);
                    // �I�u�W�F�N�g����
                    Instantiate(ItemPrefab[SpawnItemRnd], ItemSpawnPosition, Quaternion.identity);

                ItemSpawnPosition.x = 0;
              
            }
        }

    }
}
