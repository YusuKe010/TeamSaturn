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
        // 初期状態のステートのEnterを呼ぶタイミングが1フレーム目のUpdateなので
        // 各オブジェクトがAwakeとStartで初期化処理できる。
        _currentState = _currentState.Update();
    }
}