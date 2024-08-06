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
            Debug.Log("オープニング開始");
        }

        protected override void Exit()
        {
            Debug.Log("オープニング終了");
        }

        protected override void Stay()
        {
            Debug.Log("オープニング中");

            if (Input.GetKeyDown(KeyCode.Space)) TryChangeState(StateIdentifier.Playing);
        }
    }
}