using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class ResultState : State
    {
        Ranking _ranking;

        // ランキングにスコアの送信が完了したフラグ。
        bool _isPostScoreRankingCompleted;
        // 重複してシーンを遷移させないよう制御するフラグ。
        bool _isSceneChangeRunning;

        public ResultState(IReadOnlyDictionary<StateIdentifier, State> states) : base(states)
        {
            _ranking = Object.FindAnyObjectByType<Ranking>();
        }

        protected override void Enter()
        {
            // ランキングにスコアを送信。
            int score = ScoreManager.GetScoreValue();
            _ranking.PostData("テストユーザー", score, PostScoreRankingCoplete);
        }

        protected override void Exit()
        {
        }

        protected override void Stay()
        {
            // スコア送信が完了するまで待つ。
            if (!_isPostScoreRankingCompleted) return;

            // リザルトシーンに遷移。
            if (!_isSceneChangeRunning)
            {
                _isSceneChangeRunning = true;
                SceneLoader.ChangeScene("Result");
            }
        }

        // スコアをランキングに登録完了フラグの操作する用途。
        void PostScoreRankingCoplete() => _isPostScoreRankingCompleted = true;
    }
}