using System.Collections;
using UnityEngine;

/// <summary>
/// 無敵：障害物に当たっても無効化する
/// </summary>
public class Item_Invincible : ItemController
{
    GameObject[] _obstacleObj;
    [SerializeField] float _releaseSeconds = 3;
    public bool _invincible;

    public override void ItemGet(Collider other)
    {
        AudioPlayer.PlaySE("Invincible");

        _invincible = true;
        StartCoroutine(Release());
        Destroy(gameObject, 1);
    }

    IEnumerator Release()
    {
        Debug.Log("入手");

        yield return new WaitForSeconds(_releaseSeconds);

        _obstacleObj = GameObject.FindGameObjectsWithTag("Respawn");
        if (_obstacleObj != null)
        {
            foreach (var obj in _obstacleObj)
            {
                Collider col = obj.GetComponent<Collider>();
                col.enabled = true;
            }
        }

        _invincible = false;
    }

    private void Update()
    {
        if (_invincible)
        {
            _obstacleObj = GameObject.FindGameObjectsWithTag("Respawn");
            if (_obstacleObj != null)
            {
                foreach (var obj in _obstacleObj)
                {
                    Collider col = obj.GetComponent<Collider>();
                    col.enabled = false;
                }
            }
            else
            {
                return;
            }
        }
    }
}
