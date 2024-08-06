using UnityEngine;

/// <summary>
/// ジャンプ力強化：ジャンプ力が1.5～2倍になる
/// </summary>
public class Item_Jump : ItemController
{
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    public override void ItemGet()
    {
        //PlayerController playerController = _player.GetComponent<PlayerController>();
        Debug.Log("Jump UP");
        //ジャンプ力を上げるメソッドを呼び出す
    }
}
