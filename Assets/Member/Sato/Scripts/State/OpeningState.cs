using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class OpeningState : State
    {
        public OpeningState(IReadOnlyDictionary<StateIdentifier, State> states) : base(states)
        {
        }

        protected override void Enter()
        {
            // スコアをリセット。
            ScoreManager.ResetScore(ScoreManager.Player.Player1);
            ScoreManager.ResetScore(ScoreManager.Player.Player2);
        }

        protected override void Exit()
        {
            // 障害物生成開始
            ObstacleGeneration obstacle = Object.FindAnyObjectByType<ObstacleGeneration>();
            obstacle.GenerateStart();

            // プレイヤー行動開始
            PlayerController player = Object.FindAnyObjectByType<PlayerController>();
            player.PlayerStart();
        }

        protected override void Stay()
        {
            Debug.Log("オープニング中。Gキーを押してスタート");
            if (Input.GetKeyDown(KeyCode.G)) TryChangeState(StateIdentifier.Playing);
        }
    }
}