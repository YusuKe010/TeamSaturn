using System.Collections;
using UnityEngine;

/// <summary>
/// 無敵：障害物に当たっても無効化する
/// </summary>
public class Item_Invincible : ItemController
{
    GameObject[] _obstacleObj;
    [SerializeField] float _releaseSeconds = 3;

    // Start is called before the first frame update
    void Start()
    {
        _obstacleObj = GameObject.FindGameObjectsWithTag("Respawn");
    }

    public override void ItemGet()
    {
        foreach (var obj in _obstacleObj)
        {
            Collider col = obj.GetComponent<Collider>();
            col.enabled = false;
            AudioPlayer.PlaySE("Invincible");
            StartCoroutine(Release());
        }
    }

    IEnumerator Release()
    {
        Debug.Log("入手");
        yield return new WaitForSeconds(_releaseSeconds);

        foreach (var obj in _obstacleObj)
        {
            Collider col = obj.GetComponent<Collider>();
            col.enabled = true;
        }
        Destroy(gameObject);
    }
}
