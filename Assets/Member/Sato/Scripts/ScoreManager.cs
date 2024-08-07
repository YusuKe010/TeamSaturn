using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScoreManagerクラスで扱うスコアのデータ。
/// </summary>
public class Score
{
    public int Value;
    public string Name;
}

/// <summary>
/// スコアを管理する。
/// </summary>
public class ScoreManager : MonoBehaviour
{
    // プレイヤーを指定する用の列挙型
    public enum Player { Player1, Player2 };

    // シングルトン
    static ScoreManager Instance;

    // 1ゲームごとにスコアを管理する想定なので変数は1つで十分。
    Score _player1Score;
    Score _player2Score;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            _player1Score = new Score();
            _player2Score = new Score();
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
    public static void ResetScore(Player player)
    {
        if (Instance != null)
        {
            PlayerScore(player).Value = 0;
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}のインスタンスがシーン上に存在しないのでスコアをリセット不可能。");
        }
    }

    /// <summary>
    /// スコアを加算。
    /// </summary>
    public static void AddScore(Player player, int value)
    {
        if (Instance != null)
        {
            PlayerScore(player).Value += value;
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}のインスタンスがシーン上に存在しないのでスコアを加算不可能。");
        }
    }

    /// <summary>
    /// スコアをセット。
    /// </summary>
    public static void SetScore(Player player, int value)
    {
        if (Instance != null)
        {
            PlayerScore(player).Value = Mathf.Max(0, value);
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}のインスタンスがシーン上に存在しないのでスコアをセット不可能。");
        }
    }

    /// <summary>
    /// スコアネームをセット。
    /// </summary>
    public static void SetScoreName(Player player, string scoreName)
    {
        if (Instance != null)
        {
            PlayerScore(player).Name = scoreName;
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}のインスタンスがシーン上に存在しないのでスコアネームをセット不可能。");
        }
    }

    /// <summary>
    /// スコアを取得。
    /// </summary>
    public static int GetScoreValue(Player player)
    {
        if (Instance != null)
        {
            return PlayerScore(player).Value;
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}のインスタンスがシーン上に存在しないのでスコアを取得不可能。");
            return -1;
        }
    }

    /// <summary>
    /// スコアネームを取得。
    /// </summary>
    public static string GetScoreName(Player player)
    {
        if (Instance != null)
        {
            return PlayerScore(player).Name;
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}のインスタンスがシーン上に存在しないのでスコアネームを取得不可能。");
            return "ぷれいや";
        }
    }

    // プレイヤーごとのスコアを取得
    static Score PlayerScore(Player player)
    {
        if (Instance == null) return null;

        if (player == Player.Player1) return Instance._player1Score;
        else return Instance._player2Score;
    }
}