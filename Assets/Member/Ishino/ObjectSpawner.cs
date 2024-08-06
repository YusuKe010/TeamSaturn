using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("�n��t�߂Ő�������I�u�W�F�N�g")]
    public GameObject[] objectToSpawn;  // �I�u�W�F�N�g�v���n�u
    [Header("�󒆂Ő�������I�u�W�F�N�g")]
    public GameObject[] CloudSpawn;  // �I�u�W�F�N�g�v���n�u
    [Header("�c�̐����Ԋu")]
    public float verticalOffsetY = 5f; // �X�|�[������Ԋu
    [Header("���̐������a")]
    public float verticalOffsetX = 50f; // �X�|�[������Ԋu
    [Header("��ԍŏ��ɐݒu���鐔")]
    public int FastSpown = 5;
    [Header("�v���C���[�̃v���n�u")]
    [SerializeField] GameObject PlayerPrefab;
    [Header("�v���C���[�̃W�����v")]
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
        SpawnObj = Random.Range(0,objectToSpawn.Length);
        if (SpawnRnd == 1)
        {
            // �X�|�[��position�쐬
            spawnPosition = SpawnPosition + new Vector3(verticalOffsetX, verticalOffsetY, 0);

            // �I�u�W�F�N�g����
            Instantiate(objectToSpawn[SpawnObj], spawnPosition, Quaternion.identity);

            spawnPosition.x = 0;

            // �X�|�[��position�̈ʒu�𒲐�
            SpawnPosition = spawnPosition;
        }
        else if(SpawnRnd == 2)
        {
            // �X�|�[��position�쐬
            spawnPosition = SpawnPosition + new Vector3(-verticalOffsetX, verticalOffsetY, 0);

            // �I�u�W�F�N�g����
            Instantiate(objectToSpawn[SpawnObj], spawnPosition, Quaternion.identity);

            spawnPosition.x = 0;
            // �X�|�[��position�̈ʒu�𒲐�
            SpawnPosition = spawnPosition;
        }

    }
}
