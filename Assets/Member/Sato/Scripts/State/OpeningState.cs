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
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in players)
            {
                p.GetComponent<PlayerController>().PlayerStart();
            }
        }

        protected override void Stay()
        {
            TryChangeState(StateIdentifier.Playing);
        }
    }
}