using UnityEngine;

/// <summary>
/// 障害物全般のController　継承して使います
/// 障害物にプレイヤーTagがついたオブジェクトが衝突したら、
/// </summary>
public class ObstacleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //タイムを減らすためのスクリプトを取得する
            ObstacleCollision();
        }
    }

    public virtual void ObstacleCollision()
    {
        //障害物に衝突した時の処理を書く
        Debug.Log("ObstacleCollision");
    }
}
