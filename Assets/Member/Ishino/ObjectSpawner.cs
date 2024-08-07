using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("�R����")]
    public GameObject[] objectToSpawn;  // �I�u�W�F�N�g�v���n�u
    [Header("�_����")]
    public GameObject[] CloudSpawn;  // �I�u�W�F�N�g�v���n�u
    [Header("�A�C�e��")]
    public GameObject[] ItemSpawn;  // �I�u�W�F�N�g�v���n�u
    [Header("����̏c�̐����Ԋu")]
    public float verticalOffsetY = 5f; // �X�|�[������Ԋu
    [Header("����̉��̐����͈�")]
    public float verticalOffsetX = 50f; // �X�|�[������Ԋu
    [Header("��x�ɐ�������鑫��̐�")]
    public int SpownCount = 1;
    [Header("��ԍŏ��ɐݒu���鑫��̐�")]
    public int FastSpown = 5;
    [Header("�󒆂Ɣ��f���鐔")]
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
            for(int i = 0;i <= SpownCount; i++)
            {
                SpownPos = Random.Range(-verticalOffsetX, verticalOffsetX);
                SpawnObj = Random.Range(0, objectToSpawn.Length);
                // �X�|�[��position�쐬
                spawnPosition = SpawnPosition + new Vector3(SpownPos, verticalOffsetY, 0);

                // �I�u�W�F�N�g����
                Instantiate(objectToSpawn[SpawnObj], spawnPosition, Quaternion.identity);

                spawnPosition.x = 0;

                // �X�|�[��position�̈ʒu�𒲐�
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
                // �X�|�[��position�쐬
                spawnPosition = SpawnPosition + new Vector3(SpownPos, verticalOffsetY, 0);

                // �I�u�W�F�N�g����
                Instantiate(CloudSpawn[SpawnObj], spawnPosition, Quaternion.identity);

                spawnPosition.x = 0;

                // �X�|�[��position�̈ʒu�𒲐�
                SpawnPosition = spawnPosition;
            }
        }

    }
}
