using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class PlayingState : State
    {
        // 時間切れ直前のSEを再生する残り時間。
        const float TimeupSePlayTime = 2.0f;

        // 時間切れ直前のSEを再生中かのフラグ。
        bool _isTimeupSePlaying;
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
        }

        protected override void Stay()
        {
            // 時間切れ直前のSE再生。
            if (Timer.GetCurrentTime() < TimeupSePlayTime && !_isTimeupSePlaying)
            {
                _isTimeupSePlaying = true;
                AudioPlayer.PlaySE("SE_Timeup");
            }

            // 時間切れでクリア状態に遷移。
            if (_isTimerEnd) TryChangeState(StateIdentifier.Clear);
        }

        // タイマーのコールバックにフラグの操作を登録する用途。
        void TimerEnd() => _isTimerEnd = true;
    }
}