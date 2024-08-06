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
        }

        protected override void Exit()
        {
        }

        protected override void Stay()
        {
        }
    }
}