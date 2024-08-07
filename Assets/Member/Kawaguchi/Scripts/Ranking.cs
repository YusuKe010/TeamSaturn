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
    [SerializeField] private string accessKey;
    private List<Record> _ranking = new();
    public List<Record> GetRanking => _ranking;

    
    public void GetData(Action action)
    {
        StartCoroutine(GetDataAsync(action));
    }

    public IEnumerator GetDataAsync(Action action)
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
        action?.Invoke();
    }

    public void PostData(string userName, int score, Action action)
    {
        StartCoroutine(PostDataAsync(userName, score, action));
    }

    public IEnumerator PostDataAsync(string username, int score, Action action)
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
        action?.Invoke();
    }
}
