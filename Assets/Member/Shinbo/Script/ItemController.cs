using UnityEngine;

/// <summary>
/// アイテム全般のController　継承して使います
/// アイテムにプレイヤーTagがついたオブジェクトが衝突したら、
/// </summary>
public class ItemController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ItemGet();
        }
    }

    public virtual void ItemGet()
    {
        //アイテムをゲットした時の処理を書く
        Debug.Log("ItemGet");
    }
}
