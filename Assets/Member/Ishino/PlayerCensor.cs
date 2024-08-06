using UnityEngine;

public class PlayerCensor : MonoBehaviour
{
    private GameObject player; // プレイヤーオブジェクト
    private Collider objectCollider; // このオブジェクトのコライダー

    void Start()
    {
        player = GameObject.Find("PlayerPos");

        // このオブジェクトのコライダーを取得
        objectCollider = GetComponent<Collider>();

        // 最初はコライダーを無効化
        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }
    }

    void Update()
    {
        

        // プレイヤーのY座標とこのオブジェクトのY座標を比較
        if (player.transform.position.y > transform.position.y)
        {
            // プレイヤーが上にある場合、コライダーを有効化
            if (objectCollider != null)
            {
                objectCollider.enabled = true;
            }
        }
        else
        {
            // プレイヤーが上にない場合、コライダーを無効化
            if (objectCollider != null)
            {
                objectCollider.enabled = false;
            }
        }
    }
}
