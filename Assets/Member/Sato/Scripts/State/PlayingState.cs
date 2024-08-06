using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class PlayingState : State
    {
        // �^�C�}�[�̎��Ԃ̌v�����I�������t���O�B
        bool _isTimerEnd;

        public PlayingState(IReadOnlyDictionary<StateIdentifier, State> states) : base(states)
        {
        }

        protected override void Enter()
        {
            Timer.RegisterOnTimerStop(TimerEnd);
            Timer.Play();
        }

        protected override void Exit()
        {
            Timer.Stop();
            Timer.ReleaseOnTimerStop(TimerEnd);
            Debug.Log("�I��肾�悱�̃X�e�[�g");
        }

        protected override void Stay()
        {
            if (_isTimerEnd) TryChangeState(StateIdentifier.Clear);
        }

        // �^�C�}�[�̃R�[���o�b�N�Ƀt���O�̑����o�^����p�r�B
        void TimerEnd() => _isTimerEnd = true;
    }
}