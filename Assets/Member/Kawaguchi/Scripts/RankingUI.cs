using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingUI : MonoBehaviour
{
    
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private int _rankingCount = 5;
    [SerializeField] Ranking _rankings;

    public Action action;

    private void Start()
    {
        action += IndicateRanking;
    }

    private void IndicateRanking()
    {
        _rankings.GetRanking.Sort((x, y) => y.score - x.score);
        for (int i = 0; i < _rankingCount || i < _rankings.GetRanking.Count; i++)
        {
            _nameText.text += $"{i + 1}ˆÊ {_rankings.GetRanking[i].name}\n";
            _scoreText.text += $"Score:{_rankings.GetRanking[i].score}m\n";
            Debug.Log("Name:" + _rankings.GetRanking[i].name + "Score:" + _rankings.GetRanking[i].score);
        }
    }
}
