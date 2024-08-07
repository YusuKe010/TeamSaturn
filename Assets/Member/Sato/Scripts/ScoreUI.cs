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
        // �q�I�u�W�F�N�g�̃e�L�X�g�̖��O����v���Ă���O��B
        _value = transform.Find("Value").GetComponent<Text>();
        _userName = transform.Find("UserName").GetComponent<Text>();
    }

    void Update()
    {
        _value.text = ScoreManager.GetScoreValue(_player).ToString();
        _userName.text = ScoreManager.GetScoreName(_player);
    }
}
