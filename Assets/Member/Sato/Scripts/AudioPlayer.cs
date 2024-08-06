using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // �V���O���g��
    static AudioPlayer Instance;

    // �����ɍĐ��ł��鐔
    const int Concurrent = 10;

    [Header("�Đ�����T�E���h�ꗗ")]
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

        // ������ScriptableObject���̃f�[�^�������ňꊇ�Ǘ�����B
        _table = new Dictionary<string, AudioTable.Data>();
        foreach (AudioTable t in _audioTable)
        {
            foreach (AudioTable.Data d in t.All)
            {
                if (d == null) continue;
                else if (!_table.TryAdd(d.Key, d))
                {
                    Debug.LogWarning($"{nameof(AudioPlayer)}�N���X�A���̃L�[���d��:{d.Key}");
                }
            }
        }

        // �Đ��p��AudioSource�������ς��A�^�b�`����B
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
    /// SE���Đ�����B
    /// </summary>
    public static void PlaySE(string key)
    {
        if (Instance == null) return;

        // �擪��BGM���g�p����̂�1�X�L�b�v����B
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
    /// BGM���Đ�����B
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
    /// BGM���~����B
    /// </summary>
    public static void StopBGM()
    {
        if (Instance == null) return;

        Instance._sources[0].Stop();
    }

    // ���������ɓo�^����Ă��邩���`�F�b�N���擾�B
    static bool TryGetAudioData(string key, out AudioTable.Data data)
    {
        if (Instance._table.TryGetValue(key, out data))
        {
            return true;
        }
        else
        {
            Debug.LogWarning($"{nameof(AudioPlayer)}�N���X�ɉ����o�^����Ă��Ȃ��̂ōĐ��s�\:{key}");
            return false;
        }
    }
}
