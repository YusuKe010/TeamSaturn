using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    Text _value;

    void Awake()
    {
        // 子オブジェクトの時間を表示するテキストの名前がValueになっている前提。
        _value = transform.Find("Value").GetComponent<Text>();
    }

    void Update()
    {
        _value.text = Timer.GetCurrentTime().ToString("F2");
    }
}
