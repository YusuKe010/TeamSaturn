using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class ResultState : State
    {
        // �d�����ăV�[����J�ڂ����Ȃ��悤���䂷��t���O�B
        bool _isSceneChangeRunning;

        public ResultState(IReadOnlyDictionary<StateIdentifier, State> states) : base(states)
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
            if (_isSceneChangeRunning) return;
            _isSceneChangeRunning = true;

            SceneLoader.ChangeScene("Result");
        }
    }
}