using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] GameObject _rangeUpper, _rangeLower;
    [SerializeField] GameObject[] _obstaclePrefabs;
    // Start is called before the first frame update
    void Start()
    {
        Positioning();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Positioning() //ê∂ê¨
    {
        float x = Random.Range(_rangeUpper.transform.position.x, _rangeLower.transform.position.x);
        float y = Random.Range(_rangeUpper.transform.position.y, _rangeLower.transform.position.y);
        float z = Random.Range(_rangeUpper.transform.position.z, _rangeLower.transform.position.z);

        Instantiate(_obstaclePrefabs[0], new Vector3(x, y, z), Quaternion.identity);
    }
}
