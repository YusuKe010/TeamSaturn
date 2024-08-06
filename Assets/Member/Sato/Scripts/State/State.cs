using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    /// <summary>
    /// ステートの管理、各ステートが遷移先の指定に使用する。
    /// </summary>
    public enum StateIdentifier { Opening, Playing, Clear, GameOver, Retry, Result }

    /// <summary>
    /// 各ステートはこのクラスを継承する。
    /// </summary>
    public abstract class State
    {
        enum Stage { Enter, Stay, Exit }

        IReadOnlyDictionary<StateIdentifier, State> _states;
        Stage _stage;
        State _next;

        public State(IReadOnlyDictionary<StateIdentifier, State> states)
        {
            _states = states;
        }

        /// <summary>
        /// 1度の呼び出しでステートの段階に応じてEnter,Stay,Exitのうちどれか1つが実行される。
        /// 次の呼び出しで実行されるステートを返す。
        /// </summary>
        public State Update()
        {
            if (_stage == Stage.Enter)
            {
                Enter();
                _stage = Stage.Stay;
            }
            else if (_stage == Stage.Stay)
            {
                Stay();
            }
            else if (_stage == Stage.Exit)
            {
                Exit();
                _stage = Stage.Enter;

                return _next;
            }

            return this;
        }

        protected abstract void Enter();
        protected abstract void Stay();
        protected abstract void Exit();

        /// <summary>
        /// ゲーム終了時にステートを破棄するタイミングで呼ぶ処理。
        /// </summary>
        public virtual void Dispose() { }

        /// <summary>
        /// Enter()が呼ばれてかつ、ステートの遷移処理を呼んでいない場合のみ遷移可能。
        /// </summary>
        public bool TryChangeState(StateIdentifier next)
        {
            if (_stage == Stage.Enter)
            {
                Debug.LogWarning($"Enterが呼ばれる前にステートを遷移することは不可能。遷移先:{next}");
                return false;
            }
            else if (_stage == Stage.Exit)
            {
                Debug.LogWarning($"既に別のステートに遷移する処理が呼ばれている。遷移先:{next}");
                return false;
            }

            _stage = Stage.Exit;
            _next = _states[next];

            return true;
        }
    }
}