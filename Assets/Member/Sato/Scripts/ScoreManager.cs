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
    // �v���C���[���w�肷��p�̗񋓌^
    public enum Player { Player1, Player2 };

    // �V���O���g��
    static ScoreManager Instance;

    // 1�Q�[�����ƂɃX�R�A���Ǘ�����z��Ȃ̂ŕϐ���1�ŏ\���B
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
    /// �ێ����Ă���X�R�A�����Z�b�g�B
    /// </summary>
    public static void ResetScore(Player player)
    {
        if (Instance != null)
        {
            PlayerScore(player).Value = 0;
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}�̃C���X�^���X���V�[����ɑ��݂��Ȃ��̂ŃX�R�A�����Z�b�g�s�\�B");
        }
    }

    /// <summary>
    /// �X�R�A�����Z�B
    /// </summary>
    public static void AddScore(Player player, int value)
    {
        if (Instance != null)
        {
            PlayerScore(player).Value += value;
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}�̃C���X�^���X���V�[����ɑ��݂��Ȃ��̂ŃX�R�A�����Z�s�\�B");
        }
    }

    /// <summary>
    /// �X�R�A���Z�b�g�B
    /// </summary>
    public static void SetScore(Player player, int value)
    {
        Debug.Log(value + "���Z�b�g");

        if (Instance != null)
        {
            PlayerScore(player).Value = Mathf.Max(0, value);
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}�̃C���X�^���X���V�[����ɑ��݂��Ȃ��̂ŃX�R�A���Z�b�g�s�\�B");
        }
    }

    /// <summary>
    /// �X�R�A���擾�B
    /// </summary>
    public static int GetScoreValue(Player player)
    {
        if (Instance != null)
        {
            return PlayerScore(player).Value;
        }
        else
        {
            Debug.LogWarning($"{nameof(ScoreManager)}�̃C���X�^���X���V�[����ɑ��݂��Ȃ��̂ŃX�R�A���擾�s�\�B");
            return -1;
        }
    }

    // �v���C���[���Ƃ̃X�R�A���擾
    static Score PlayerScore(Player player)
    {
        if (Instance == null) return null;

        if (player == Player.Player1) return Instance._player1Score;
        else return Instance._player2Score;
    }
}