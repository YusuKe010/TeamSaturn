using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    /// <summary>
    /// 計測終了のタイミングで呼ばれるコールバック。
    /// </summary>
    public event UnityAction OnTimerStop;

    // シングルトン
    static Timer Instance;

    [Header("制限時間")]
    [SerializeField] int _limit = 30;

    // 計測中かどうかのフラグ
    bool _isPlaying;
    // 残り時間
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

            // 時間が0になった場合は止めてコールバックを呼ぶ。
            if (Mathf.Approximately(_time, 0))
            {
                _isPlaying = false;
                OnTimerStop?.Invoke();
            }
        }
    }

    /// <summary>
    /// 計測開始。
    /// </summary>
    public static void Play()
    {
        Instance._isPlaying = true;
    }

    /// <summary>
    /// 計測を止める。
    /// </summary>
    public static void Stop()
    {
        Instance._isPlaying = false;
    }

    /// <summary>
    /// 計測終了時のコールバックを登録する。
    /// </summary>
    public static void RegisterOnTimerStop(UnityAction callback)
    {
        Instance.OnTimerStop += callback;
    }

    /// <summary>
    /// 計測終了時のコールバックを解除する。
    /// </summary>
    public static void ReleaseOnTimerStop(UnityAction callback)
    {
        Instance.OnTimerStop -= callback;
    }

    /// <summary>
    /// 現在の時間を取得。
    /// </summary>
    public static float GetCurrentTime()
    {
        return Instance._time;
    }

    /// <summary>
    /// 残り時間を増減させる。
    /// </summary>
    public static void IncreaseTime(float value)
    {
        Instance._time += value;
    }
}
