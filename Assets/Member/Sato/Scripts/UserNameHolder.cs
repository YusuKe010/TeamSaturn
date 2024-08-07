using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserNameHolder : MonoBehaviour
{
    // �v���C���[���w�肷��񋓌^
    public enum Player { Player1, Player2 };

    // �V���O���g��
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
    /// �v���C���[�̖��O���擾����B
    /// </summary>
    public static string GetPlayerName(Player player)
    {
        if (Instance == null) return string.Empty;

        if (player == Player.Player1) return Instance._player1Name;
        else return Instance._player2Name;
    }

    /// <summary>
    /// �v���C���[�̖��O���Z�b�g����B
    /// </summary>
    public static void SetPlayerName(Player player, string name)
    {
        if (Instance == null) return;

        if (player == Player.Player1) Instance._player1Name = name;
        else Instance._player2Name = name;
    }
}
