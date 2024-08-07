using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Title
{
    public class Campaign : ButtonContent
    {
        [SerializeField] UnityEngine.UI.InputField _player1InputField;
        [SerializeField] UnityEngine.UI.InputField _player2InputField;

        // �d�����ď������Ă΂�Ȃ��悤�̃t���O
        bool _running;

        protected override void OnOpenButtonClick()
        {
            if (_running) return;
            _running = true;

            StartCoroutine(RunAsync());
        }

        IEnumerator RunAsync()
        {
            Ranking ranking = FindAnyObjectByType<Ranking>();

            UserNameHolder.SetPlayerName(UserNameHolder.Player.Player1, "�v���C���[1");
            UserNameHolder.SetPlayerName(UserNameHolder.Player.Player2, "�v���C���[2");

            string p1Name = _player1InputField.text;
            string p2Name = _player2InputField.text;
            UserNameHolder.SetPlayerName(UserNameHolder.Player.Player1, p1Name);
            UserNameHolder.SetPlayerName(UserNameHolder.Player.Player2, p2Name);

            // ����ɂ���A���Ƃ܂킵
            yield return ranking.PostDataAsync(p1Name, 0, null);
            yield return ranking.PostDataAsync(p2Name, 0, null);

            SceneLoader.ChangeScene("InGame");
        }
    }
}