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
            // �X�R�A�����Z�b�g�B
            ScoreManager.ResetScore();
        }

        protected override void Exit()
        {
            // ��Q�������J�n
            ObstacleGeneration obstacle = Object.FindAnyObjectByType<ObstacleGeneration>();
            obstacle.GenerateStart();

            // �v���C���[�s���J�n
            PlayerController player = Object.FindAnyObjectByType<PlayerController>();
            player.PlayerStart();
        }

        protected override void Stay()
        {
            Debug.Log("�I�[�v�j���O��");
            if (Input.GetKeyDown(KeyCode.G)) TryChangeState(StateIdentifier.Playing);
        }
    }
}