using UnityEngine;

/// <summary>
/// アイテム全般のController　継承して使います
/// アイテムにプレイヤーTagがついたオブジェクトが衝突したら、
/// </summary>
public class ItemController : MonoBehaviour
{
    bool _itemGet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_itemGet)
        {
            ItemGet();
            _itemGet = true;
        }
    }

    public virtual void ItemGet()
    {
        //アイテムをゲットした時の処理を書く
        Debug.Log("ItemGet");
    }
}
