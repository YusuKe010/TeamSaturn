using UnityEngine;

/// <summary>
/// ��Q���𐶐����āA�������ɔ�΂�
/// �G�F�Q�|�C���g����
/// ��s�@�F�R�|�C���g����
/// �ɐ�������
/// </summary>
public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] GameObject _rangeUpper, _rangeLower;
    [SerializeField] GameObject[] _obstaclePrefabs;

    // Start is called before the first frame update
    void Start()
    {
       // Positioning();
        ReversePositioning();
    }

    public void Positioning() //����
    {
        float x = Random.Range(_rangeUpper.transform.position.x, _rangeLower.transform.position.x);
        float y = Random.Range(_rangeUpper.transform.position.y, _rangeLower.transform.position.y);
        float z = Random.Range(_rangeUpper.transform.position.z, _rangeLower.transform.position.z);

        Instantiate(_obstaclePrefabs[0], new Vector3(x, y, z), Quaternion.identity);
    }

    public void ReversePositioning() //�t��
    {
        float x = Random.Range(_rangeUpper.transform.position.x * -1, _rangeLower.transform.position.x * -1);
        float y = Random.Range(_rangeUpper.transform.position.y, _rangeLower.transform.position.y);
        float z = Random.Range(_rangeUpper.transform.position.z, _rangeLower.transform.position.z);

        Instantiate(_obstaclePrefabs[0], new Vector3(x, y, z), Quaternion.identity);
    }
}
