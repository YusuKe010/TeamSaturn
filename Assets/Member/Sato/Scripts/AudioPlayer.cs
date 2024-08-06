using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // シングルトン
    static AudioPlayer Instance;

    // 同時に再生できる数
    const int Concurrent = 10;

    [Header("再生するサウンド一覧")]
    [SerializeField] AudioTable[] _audioTable;

    Dictionary<string, AudioTable.Data> _table;
    AudioSource[] _sources = new AudioSource[Concurrent];

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

        // 複数のScriptableObject内のデータを辞書で一括管理する。
        _table = new Dictionary<string, AudioTable.Data>();
        foreach (AudioTable t in _audioTable)
        {
            foreach (AudioTable.Data d in t.All)
            {
                if (d == null) continue;
                else if (!_table.TryAdd(d.Key, d))
                {
                    Debug.LogWarning($"{nameof(AudioPlayer)}クラス、音のキーが重複:{d.Key}");
                }
            }
        }

        // 再生用のAudioSourceをいっぱいアタッチする。
        for (int i = 0; i < _sources.Length; i++)
        {
            _sources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
            _table = null;
            _sources = null;
        }
    }

    /// <summary>
    /// SEを再生する。
    /// </summary>
    public static void PlaySE(string key)
    {
        if (Instance == null) return;

        // 先頭はBGMが使用するので1つスキップする。
        AudioSource source = Instance._sources.Skip(1).Where(v => !v.isPlaying).FirstOrDefault();

        if (source != null && TryGetAudioData(key, out AudioTable.Data d))
        {
            source.clip = d.Clip;
            source.volume = d.Volume;
            source.loop = false;
            source.Play();
        }
    }

    /// <summary>
    /// BGMを再生する。
    /// </summary>
    public static void PlayBGM(string key)
    {
        if (Instance == null) return;

        if (TryGetAudioData(key, out AudioTable.Data d))
        {
            AudioSource source = Instance._sources[0];
            source.clip = d.Clip;
            source.volume = d.Volume;
            source.loop = true;
            source.Play();
        }
    }

    /// <summary>
    /// BGMを停止する。
    /// </summary>
    public static void StopBGM()
    {
        if (Instance == null) return;

        Instance._sources[0].Stop();
    }

    // 音が辞書に登録されているかをチェック＆取得。
    static bool TryGetAudioData(string key, out AudioTable.Data data)
    {
        if (Instance._table.TryGetValue(key, out data))
        {
            return true;
        }
        else
        {
            Debug.LogWarning($"{nameof(AudioPlayer)}クラスに音が登録されていないので再生不可能:{key}");
            return false;
        }
    }
}
