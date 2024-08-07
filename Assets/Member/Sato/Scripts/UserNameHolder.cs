using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserNameHolder : MonoBehaviour
{
    // プレイヤーを指定する列挙型
    public enum Player { Player1, Player2 };

    // シングルトン
    static UserNameHolder Instance;

    string _player1Name;
    string _player2Name;

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
            return;
        }
    }

    void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    /// <summary>
    /// プレイヤーの名前を取得する。
    /// </summary>
    public static string GetPlayerName(Player player)
    {
        if (Instance == null) return string.Empty;

        if (player == Player.Player1) return Instance._player1Name;
        else return Instance._player2Name;
    }

    /// <summary>
    /// プレイヤーの名前をセットする。
    /// </summary>
    public static void SetPlayerName(Player player, string name)
    {
        if (Instance == null) return;

        if (player == Player.Player1) Instance._player1Name = name;
        else Instance._player2Name = name;
    }
}
