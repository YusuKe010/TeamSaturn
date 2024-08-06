using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class PlayingState : State
    {
        // タイマーの時間の計測が終了したフラグ。
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
            Debug.Log("終わりだよこのステート");
        }

        protected override void Stay()
        {
            if (_isTimerEnd) TryChangeState(StateIdentifier.Clear);
        }

        // タイマーのコールバックにフラグの操作を登録する用途。
        void TimerEnd() => _isTimerEnd = true;
    }
}