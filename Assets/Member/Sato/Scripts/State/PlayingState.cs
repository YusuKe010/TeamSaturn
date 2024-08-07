using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class PlayingState : State
    {
        // ���Ԑ؂꒼�O��SE���Đ�����c�莞�ԁB
        const float TimeupSePlayTime = 2.0f;

        // ���Ԑ؂꒼�O��SE���Đ������̃t���O�B
        bool _isTimeupSePlaying;
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
        }

        protected override void Stay()
        {
            // ���Ԑ؂꒼�O��SE�Đ��B
            if (Timer.GetCurrentTime() < TimeupSePlayTime && !_isTimeupSePlaying)
            {
                _isTimeupSePlaying = true;
                AudioPlayer.PlaySE("SE_Timeup");
            }

            // ���Ԑ؂�ŃN���A��ԂɑJ�ځB
            if (_isTimerEnd) TryChangeState(StateIdentifier.Clear);
        }

        // �^�C�}�[�̃R�[���o�b�N�Ƀt���O�̑����o�^����p�r�B
        void TimerEnd() => _isTimerEnd = true;
    }
}