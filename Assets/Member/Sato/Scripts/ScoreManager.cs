using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScoreManager�N���X�ň����X�R�A�̃f�[�^�B
/// </summary>
public class Score
{
    public int Value;
}

/// <summary>
/// �X�R�A���Ǘ�����B
/// </summary>
public class ScoreManager : MonoBehaviour
{
    // �V���O���g��
    static ScoreManager Instance;

    // 1�Q�[�����ƂɃX�R�A���Ǘ�����z��Ȃ̂ŕϐ���1�ŏ\���B
    Score _score;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (Instance != null) Instance = null;
    }

    /// <summary>
    /// �ێ����Ă���X�R�A�����Z�b�g�B
    /// </summary>
    public static void ResetScore()
    {
        if (Instance != null)
        {
            Instance._score ??= new Score();
            Instance._score.Value = 0;
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}�̃C���X�^���X���V�[����ɑ��݂��Ȃ��̂ŃX�R�A�����Z�b�g�s�\�B");
        }
    }

    /// <summary>
    /// �X�R�A�����Z�B
    /// </summary>
    public static void AddScore(int value)
    {
        if (Instance != null)
        {
            Instance._score ??= new Score();
            Instance._score.Value += value;
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}�̃C���X�^���X���V�[����ɑ��݂��Ȃ��̂ŃX�R�A�����Z�s�\�B");
        }
    }

    /// <summary>
    /// �X�R�A���擾�B
    /// </summary>
    public static int GetScoreValue()
    {
        if (Instance != null)
        {
            if (Instance._score == null) return 0;
            else return Instance._score.Value;
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}�̃C���X�^���X���V�[����ɑ��݂��Ȃ��̂ŃX�R�A���擾�s�\�B");
            return -1;
        }
    }
}