using System.Collections;
using UnityEngine;

/// <summary>
/// 障害物を生成して、横方向に飛ばす
/// 烏：２ポイントおき
/// 飛行機：３ポイントおき
/// に生成する
/// 最初は動かないようにする
/// </summary>
public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] GameObject _rangeUpper, _rangeLower;
    [SerializeField] GameObject[] _obstaclePrefabs;
    [SerializeField, Tooltip("烏の生成インターバル")] float _crowInterval = 2;
    [SerializeField, Tooltip("飛行機の生成インターバル")] float _airplaneInterval = 3;
    [SerializeField, Tooltip("烏の生成を始めるy座標")] float _crowHeight = 1;
    [SerializeField, Tooltip("飛行機の生成を始めるy座標")] float _airplaneHeight = 5;
    GameObject _playerObj;

    // Start is called before the first frame update
    void Start()
    {
        _playerObj = _rangeUpper.transform.parent.gameObject;
        GenerateStart();
    }

    public void GenerateStart() //生成を開始するときに呼び出してほしいメソッド
    {
        StartCoroutine(Generation());
    }

    void Positioning(int index) //生成
    {
        float x = Random.Range(_rangeUpper.transform.position.x, _rangeLower.transform.position.x);
        float y = Random.Range(_rangeUpper.transform.position.y, _rangeLower.transform.position.y);
        float z = Random.Range(_rangeUpper.transform.position.z, _rangeLower.transform.position.z);

        Instantiate(_obstaclePrefabs[index], new Vector3(x, y, z), Quaternion.identity);
    }

    void ReversePositioning(int index) //逆側
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
