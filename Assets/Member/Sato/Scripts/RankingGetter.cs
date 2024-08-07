using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingGetter : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RunAsync());
    }

    IEnumerator RunAsync()
    {
        Ranking ranking = FindAnyObjectByType<Ranking>();
        RankingUI rankingUI = FindAnyObjectByType<RankingUI>();

        yield return ranking.GetDataAsync(rankingUI.action);
    }
}
