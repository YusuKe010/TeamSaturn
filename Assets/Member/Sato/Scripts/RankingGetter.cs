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
        yield return ranking.GetDataAsync(null);
    }
}
