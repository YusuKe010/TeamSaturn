using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScoreManagerクラスで扱うスコアのデータ。
/// </summary>
public class Score
{
    public int Value;
}

/// <summary>
/// スコアを管理する。
/// </summary>
public class ScoreManager : MonoBehaviour
{
    // シングルトン
    static ScoreManager Instance;

    // 1ゲームごとにスコアを管理する想定なので変数は1つで十分。
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
    /// 保持しているスコアをリセット。
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
            Debug.LogWarning($"{nameof(ScoreManager)}のインスタンスがシーン上に存在しないのでスコアをリセット不可能。");
        }
    }

    /// <summary>
    /// スコアを加算。
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
            Debug.LogWarning($"{nameof(ScoreManager)}のインスタンスがシーン上に存在しないのでスコアを加算不可能。");
        }
    }

    /// <summary>
    /// スコアを取得。
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
            Debug.LogWarning($"{nameof(ScoreManager)}のインスタンスがシーン上に存在しないのでスコアを取得不可能。");
            return -1;
        }
    }
}