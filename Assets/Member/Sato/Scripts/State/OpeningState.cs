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
            Debug.Log("�I�[�v�j���O�I��");
        }

        protected override void Stay()
        {
            Debug.Log("�I�[�v�j���O��");

            TryChangeState(StateIdentifier.Playing);
        }
    }
}