using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObjectで音データを設定し、AudioPlayer側で読み込んで再生する。
/// </summary>
[CreateAssetMenu(fileName = "AudioTable_")]
public class AudioTable : ScriptableObject
{
    [System.Serializable]
    public class Data
    {
        public string Key;
        public AudioClip Clip;
        [Range(0, 1)]
        public float Volume = 1;
    }

    [SerializeField] Data[] _all;

    public IEnumerable<Data> All => _all;
}
