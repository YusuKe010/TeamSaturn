using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class ResultState : State
    {
        Ranking _ranking;

        // ランキングにスコアの送信が完了したフラグ。
        bool _isPlayer1Post;
        bool _isPlayer2Post;
        // 重複してシーンを遷移させないよう制御するフラグ。
        bool _isSceneChangeRunning;

        public ResultState(IReadOnlyDictionary<StateIdentifier, State> states) : base(states)
        {
            _ranking = Object.FindAnyObjectByType<Ranking>();
        }

        protected override void Enter()
        {
            // ランキングにスコアを送信。
            int player1Score = ScoreManager.GetScoreValue(ScoreManager.Player.Player1);
            int player2Score = ScoreManager.GetScoreValue(ScoreManager.Player.Player2);

            string pn1 = UserNameHolder.GetPlayerName(UserNameHolder.Player.Player1);
            string pn2 = UserNameHolder.GetPlayerName (UserNameHolder.Player.Player2);
            _ranking.PostData(pn1, player1Score, Player1PostScore);
            _ranking.PostData(pn2, player2Score, Player2PostScore);
        }

        protected override void Exit()
        {
        }

        protected override void Stay()
        {
            // スコア送信が完了するまで待つ。
            if (!_isPlayer1Post || !_isPlayer2Post) return;

            // リザルトシーンに遷移。
            if (!_isSceneChangeRunning)
            {
                _isSceneChangeRunning = true;
                SceneLoader.ChangeScene("Result");
            }
        }

        // スコアをランキングに登録完了フラグの操作する用途。
        void Player1PostScore() => _isPlayer1Post = true;
        void Player2PostScore() => _isPlayer2Post = true;
    }
}