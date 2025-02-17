﻿using UnityEngine;

/// <summary>
/// 障害物全般のController　継承して使います
/// 障害物にプレイヤーTagがついたオブジェクトが衝突したら、
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class ObstacleController : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    [SerializeField] LayerMask _layerMask;

    private void Start()
    {
        gameObject.layer = _layerMask;
        //生成されたとき、横方向にとんでいく
        Rigidbody rb = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player.transform.position.x > transform.position.x) rb.velocity = Vector3.right * _speed;
        else rb.velocity = Vector3.left * _speed;

        Destroy(gameObject, 4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ObstacleCollision();
        }
    }

    public virtual void ObstacleCollision()
    {
        //障害物に衝突した時の処理を書く
        Debug.Log("ObstacleCollision");
    }
}
