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
            Debug.Log("�N���A���o�J�n");
        }

        protected override void Exit()
        {
            Debug.Log("�N���A���o�I��");
        }

        protected override void Stay()
        {
            TryChangeState(StateIdentifier.Result);
        }
    }
}