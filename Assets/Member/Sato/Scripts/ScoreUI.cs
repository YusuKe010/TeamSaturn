using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    Text _value;

    void Awake()
    {
        // �q�I�u�W�F�N�g�̎��Ԃ�\������e�L�X�g�̖��O��Value�ɂȂ��Ă���O��B
        _value = transform.Find("Value").GetComponent<Text>();
    }

    void Update()
    {
        _value.text = ScoreManager.GetScoreValue().ToString();
    }
}
