using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] ScoreManager.Player _player;

    Text _userName;
    Text _value;

    void Awake()
    {
        // 子オブジェクトのテキストの名前が一致している前提。
        _value = transform.Find("Value").GetComponent<Text>();
        _userName = transform.Find("UserName").GetComponent<Text>();
    }

    void Update()
    {
        _value.text = ScoreManager.GetScoreValue(_player).ToString();
        _userName.text = ScoreManager.GetScoreName(_player);
    }
}
