using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    Dictionary<StateIdentifier, State> _states;
    State _currentState;

    void Awake()
    {
        _states = new Dictionary<StateIdentifier, State>();
        _states.Add(StateIdentifier.Opening, new OpeningState(_states));
        _states.Add(StateIdentifier.Playing, new PlayingState(_states));
        _states.Add(StateIdentifier.Clear, new ClearState(_states));
        _states.Add(StateIdentifier.GameOver, new GameOverState(_states));
        _states.Add(StateIdentifier.Retry, new RetryState(_states));

        _currentState = _states[StateIdentifier.Opening];
    }

    void Update()
    {
        // ������Ԃ̃X�e�[�g��Enter���Ăԃ^�C�~���O��1�t���[���ڂ�Update�Ȃ̂�
        // �e�I�u�W�F�N�g��Awake��Start�ŏ����������ł���B
        _currentState = _currentState.Update();
    }
}