using UnityEngine;

/// <summary>
/// 障害物を生成して、横方向に飛ばす
/// 烏：２ポイントおき
/// 飛行機：３ポイントおき
/// に生成する
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

    public void Positioning() //生成
    {
        float x = Random.Range(_rangeUpper.transform.position.x, _rangeLower.transform.position.x);
        float y = Random.Range(_rangeUpper.transform.position.y, _rangeLower.transform.position.y);
        float z = Random.Range(_rangeUpper.transform.position.z, _rangeLower.transform.position.z);

        Instantiate(_obstaclePrefabs[0], new Vector3(x, y, z), Quaternion.identity);
    }

    public void ReversePositioning() //逆側
    {
        float x = Random.Range(_rangeUpper.transform.position.x * -1, _rangeLower.transform.position.x * -1);
        float y = Random.Range(_rangeUpper.transform.position.y, _rangeLower.transform.position.y);
        float z = Random.Range(_rangeUpper.transform.position.z, _rangeLower.transform.position.z);

        Instantiate(_obstaclePrefabs[0], new Vector3(x, y, z), Quaternion.identity);
    }
}
