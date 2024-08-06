using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class ClearState : State
    {
        public ClearState(IReadOnlyDictionary<StateIdentifier, State> states) : base(states)
        {
        }

        protected override void Enter()
        {
            Debug.Log("クリア演出開始");
        }

        protected override void Exit()
        {
            Debug.Log("クリア演出終了");
        }

        protected override void Stay()
        {
            TryChangeState(StateIdentifier.Result);
        }
    }
}