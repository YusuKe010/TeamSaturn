using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBGM : MonoBehaviour
{
    [SerializeField] string _bgmName;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        AudioPlayer.PlayBGM(_bgmName);
    }

    void OnSceneLoaded(Scene _, LoadSceneMode __)
    {
        AudioPlayer.StopBGM();
    }
}
