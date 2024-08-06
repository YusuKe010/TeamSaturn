using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[Serializable]
public class Records
{
    public Record[] records;
}

[Serializable]
public class Record
{
    public string name;
    public int score;
}

public class Ranking : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private string accessKey;
    [SerializeField] private int _rankingCount = 3;
    private List<Record> _ranking = new();
    public List<Record> GetRanking => _ranking;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(GetData());
        }
    }

    public void GetData(Action action)
    {
        StartCoroutine(GetData());
        action();
    }

    public IEnumerator GetData()
    {
        Debug.Log("データ受信開始・・・");
        var request = UnityWebRequest.Get("https://script.google.com/macros/s/" + accessKey + "/exec");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.responseCode == 200)
            {
                _ranking = JsonUtility.FromJson<Records>(request.downloadHandler.text).records.ToList();
                Debug.Log("データ受信成功！");
                _ranking.Sort((x, y) => y.score - x.score);
                for (int i = 0; i < _rankingCount; i++)
                {
                    _nameText.text += $"{i + 1}位 {_ranking[i].name}\n";
                    _scoreText.text += $"Score:{_ranking[i].score}\n";
                    Debug.Log("Name:" + _ranking[i].name + "Score:" + _ranking[i].score);
                }
            }
            else
            {
                Debug.LogError("データ受信失敗：" + request.responseCode);
            }
        }
        else
        {
            Debug.LogError("データ受信失敗" + request.result);
        }
    }

    public void PostData(string userName, int score, Action action)
    {
        StartCoroutine(PostData(userName, score));
        action();
    }

    private IEnumerator PostData(string username, int score)
    {
        Debug.Log("データ送信開始・・・");
        var form = new WWWForm();
        form.AddField("name", username);
        form.AddField("score", score);

        var request = UnityWebRequest.Post("https://script.google.com/macros/s/" + accessKey + "/exec", form);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.responseCode == 200)
            {
                var records = JsonUtility.FromJson<Records>(request.downloadHandler.text).records;
                Debug.Log("データ送信成功！");
            }
            else
            {
                Debug.LogError("データ送信失敗" + request.responseCode);
            }
        }
        else
        {
            Debug.Log("データ送信失敗" + request.result);
        }

    }
}
