using System.Collections;
using UnityEngine;

/// <summary>
/// ��Q���𐶐����āA�������ɔ�΂�
/// �G�F�Q�|�C���g����
/// ��s�@�F�R�|�C���g����
/// �ɐ�������
/// �ŏ��͓����Ȃ��悤�ɂ���
/// </summary>
public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] GameObject _rangeUpper, _rangeLower;
    [SerializeField] GameObject[] _obstaclePrefabs;
    [SerializeField, Tooltip("�G�̐����C���^�[�o��")] float _crowInterval = 2;
    [SerializeField, Tooltip("��s�@�̐����C���^�[�o��")] float _airplaneInterval = 3;
    [SerializeField, Tooltip("�G�̐������n�߂�y���W")] float _crowHeight = 1;
    [SerializeField, Tooltip("��s�@�̐������n�߂�y���W")] float _airplaneHeight = 5;
    GameObject _playerObj;

    // Start is called before the first frame update
    void Start()
    {
        _playerObj = _rangeUpper.transform.parent.gameObject;
        GenerateStart();
    }

    public void GenerateStart() //�������J�n����Ƃ��ɌĂяo���Ăق������\�b�h
    {
        StartCoroutine(Generation());
    }

    void Positioning(int index) //����
    {
        float x = Random.Range(_rangeUpper.transform.position.x, _rangeLower.transform.position.x);
        float y = Random.Range(_rangeUpper.transform.position.y, _rangeLower.transform.position.y);
        float z = Random.Range(_rangeUpper.transform.position.z, _rangeLower.transform.position.z);

        Instantiate(_obstaclePrefabs[index], new Vector3(x, y, z), Quaternion.identity);
    }

    void ReversePositioning(int index) //�t��
    {
        float x = Random.Range(_rangeUpper.transform.position.x * -1, _rangeLower.transform.position.x * -1);
        float y = Random.Range(_rangeUpper.transform.position.y, _rangeLower.transform.position.y);
        float z = Random.Range(_rangeUpper.transform.position.z, _rangeLower.transform.position.z);

        Instantiate(_obstaclePrefabs[index], new Vector3(x, y, z), Quaternion.identity);
    }

    IEnumerator Generation()
    {
        yield return new WaitUntil(() => _playerObj.transform.position.y > _crowHeight);

        StartCoroutine(CrowGeneration());

        yield return new WaitUntil(() => _playerObj.transform.position.y > _airplaneHeight);

        StartCoroutine(AirplaneGeneration());
    }

    IEnumerator CrowGeneration()
    {
        int rand = (int)Random.Range(0, 2);
        if (rand == 0) Positioning(0);
        else ReversePositioning(0);

        yield return new WaitForSeconds(_crowInterval);

        StartCoroutine(CrowGeneration());
    }

    public IEnumerator AirplaneGeneration()
    {
        int rand = (int)Random.Range(0, 2);
        if (rand == 0) Positioning(1);
        else ReversePositioning(1);

        yield return new WaitForSeconds(_airplaneInterval);

        StartCoroutine(AirplaneGeneration());
    }
}
