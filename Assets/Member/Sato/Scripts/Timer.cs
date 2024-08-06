using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    /// <summary>
    /// �v���I���̃^�C�~���O�ŌĂ΂��R�[���o�b�N�B
    /// </summary>
    public event UnityAction OnTimerStop;

    // �V���O���g��
    static Timer Instance;

    [Header("��������")]
    [SerializeField] int _limit = 30;

    // �v�������ǂ����̃t���O
    bool _isPlaying;
    // �c�莞��
    float _time;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

    void Start()
    {
        _time = _limit;
    }

    void Update()
    {
        if (_isPlaying)
        {
            _time -= Time.deltaTime;
            _time = Mathf.Max(0, _time);

            // ���Ԃ�0�ɂȂ����ꍇ�͎~�߂ăR�[���o�b�N���ĂԁB
            if (Mathf.Approximately(_time, 0))
            {
                _isPlaying = false;
                OnTimerStop?.Invoke();
            }
        }
    }

    /// <summary>
    /// �v���J�n�B
    /// </summary>
    public static void Play()
    {
        Instance._isPlaying = true;
    }

    /// <summary>
    /// �v�����~�߂�B
    /// </summary>
    public static void Stop()
    {
        Instance._isPlaying = false;
    }

    /// <summary>
    /// �v���I�����̃R�[���o�b�N��o�^����B
    /// </summary>
    public static void RegisterOnTimerStop(UnityAction callback)
    {
        Instance.OnTimerStop += callback;
    }

    /// <summary>
    /// �v���I�����̃R�[���o�b�N����������B
    /// </summary>
    public static void ReleaseOnTimerStop(UnityAction callback)
    {
        Instance.OnTimerStop -= callback;
    }

    /// <summary>
    /// ���݂̎��Ԃ��擾�B
    /// </summary>
    public static float GetCurrentTime()
    {
        return Instance._time;
    }

    /// <summary>
    /// �c�莞�Ԃ𑝌�������B
    /// </summary>
    public static void IncreaseTime(float value)
    {
        Instance._time += value;
    }
}
