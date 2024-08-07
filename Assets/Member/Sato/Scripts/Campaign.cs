using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Title
{
    public class Campaign : ButtonContent
    {
        [SerializeField] UnityEngine.UI.InputField _player1InputField;
        [SerializeField] UnityEngine.UI.InputField _player2InputField;

        // 重複して処理が呼ばれないようのフラグ
        bool _running;

        bool _player1Post;
        bool _player2Post;

        protected override void OnOpenButtonClick()
        {
            if (_running) return;
            _running = true;

            StartCoroutine(RunAsync());
        }

        IEnumerator RunAsync()
        {
            string p1Name = _player1InputField.text;
            string p2Name = _player2InputField.text;

            if (p1Name == string.Empty) p1Name = "プレイヤー1";
            if (p2Name == string.Empty) p2Name = "プレイヤー2";

            UserNameHolder.SetPlayerName(UserNameHolder.Player.Player1, p1Name);
            UserNameHolder.SetPlayerName(UserNameHolder.Player.Player2, p2Name);

            // 並列
            StartCoroutine(Player1Post(p1Name));
            StartCoroutine(Player2Post(p2Name));

            yield return new WaitUntil(() => _player1Post);
            yield return new WaitUntil(() => _player2Post);

            SceneLoader.ChangeScene("InGame");
        }

        IEnumerator Player1Post(string playerName)
        {
            Ranking ranking = FindAnyObjectByType<Ranking>();
            yield return ranking.PostDataAsync(playerName, 0, null);
            _player1Post = true;
        }

        IEnumerator Player2Post(string playerName)
        {
            Ranking ranking = FindAnyObjectByType<Ranking>();
            yield return ranking.PostDataAsync(playerName, 0, null);
            _player2Post = true;
        }
    }
}