using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStoker : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 ThisPosition;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        playerPos = player.transform.position;
        ThisPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        this.transform.position = new Vector3(0,playerPos.y + 0.5f, 0);
        //ThisPosition.y = playerPos.y;

        //// オブジェクトの座標を変数 pos に格納
        //Vector3 pos = transform.position;
        //// ターゲットオブジェクトのY座標に変数 offset のオフセット値を加えて
        //// 変数 posのY座標に代入
        //pos.y = playerPos.y + offset;
        //// 変数 pos の値をオブジェクト座標に格納
        //transform.position = pos;
    }
}
