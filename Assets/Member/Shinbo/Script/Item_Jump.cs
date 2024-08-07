using System.Collections;
using UnityEngine;

/// <summary>
/// ジャンプ力強化：ジャンプ力が1.5～2倍になる
/// </summary>
public class Item_Jump : ItemController
{
    GameObject[] _player;
    PlayerJump[] _playerJump;
    [SerializeField, Tooltip("ジャンプ力の倍率")] float _jumpForceMultiplier = 1.5f;
    [SerializeField] float _releaseSeconds = 3;
    Collider _collider;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < 2; i++)
        {
            _playerJump[i] = _player[i].GetComponent<PlayerJump>();
        }
    }

    public override void ItemGet(Collider other)
    {
        PlayerJump a = other.gameObject.GetComponent<PlayerJump>();
        for (int i = 0; i < 2; i++)
        {
            if (a == _playerJump[i])
            {
                _collider = other;
                _playerJump[i].JumpPowerUp(_jumpForceMultiplier);
                AudioPlayer.PlaySE("Jump");
                Destroy(gameObject, 1);
                Debug.Log("ジャンプ力上昇中");
                StartCoroutine(Release());
            }
        }
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(_releaseSeconds);

        for (int i = 0; i < 2; i++)
        {
            if (_playerJump[i] == _collider.gameObject.GetComponent<PlayerJump>())
            {
                _playerJump[i].JumpPowerReturn();
            }
            
        }
    }
}
