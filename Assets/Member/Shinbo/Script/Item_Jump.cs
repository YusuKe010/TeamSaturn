using System.Collections;
using UnityEngine;

/// <summary>
/// ジャンプ力強化：ジャンプ力が1.5～2倍になる
/// </summary>
public class Item_Jump : ItemController
{
    GameObject _player;
    PlayerJump _playerJump;
    [SerializeField, Tooltip("ジャンプ力の倍率")] float _jumpForceMultiplier;
    [SerializeField] float _releaseSeconds = 3;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _playerJump = _player.GetComponent<PlayerJump>();
    }

    public override void ItemGet()
    {
        _playerJump.JumpPowerUp(_jumpForceMultiplier);
        AudioPlayer.PlaySE("Jump");
        Destroy(gameObject, 1);
        Debug.Log("ジャンプ力上昇中");
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(_releaseSeconds);

        _playerJump.JumpPowerReturn();
    }
}
