using UnityEngine;

/// <summary>
/// アイテム全般のController　継承して使います
/// アイテムにプレイヤーTagがついたオブジェクトが衝突したら、
/// </summary>
public class ItemController : MonoBehaviour
{
    bool _itemGet;
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_itemGet)
        {
            ItemGet(other);
            _animator.SetBool("Get", true);
            _itemGet = true;
        }
    }

    public virtual void ItemGet(Collider other)
    {
        //アイテムをゲットした時の処理を書く
        Debug.Log("ItemGet");
    }
}
