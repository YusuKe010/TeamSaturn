using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class ResultState : State
    {
        Ranking _ranking;

        // �����L���O�ɃX�R�A�̑��M�����������t���O�B
        bool _isPlayer1Post;
        bool _isPlayer2Post;
        // �d�����ăV�[����J�ڂ����Ȃ��悤���䂷��t���O�B
        bool _isSceneChangeRunning;

        public ResultState(IReadOnlyDictionary<StateIdentifier, State> states) : base(states)
        {
            _ranking = Object.FindAnyObjectByType<Ranking>();
        }

        protected override void Enter()
        {
            // �����L���O�ɃX�R�A�𑗐M�B
            int player1Score = ScoreManager.GetScoreValue(ScoreManager.Player.Player1);
            int player2Score = ScoreManager.GetScoreValue(ScoreManager.Player.Player2);

            string pn1 = UserNameHolder.GetPlayerName(UserNameHolder.Player.Player1);
            string pn2 = UserNameHolder.GetPlayerName (UserNameHolder.Player.Player2);
            _ranking.PostData(pn1, player1Score, Player1PostScore);
            _ranking.PostData(pn2, player2Score, Player2PostScore);
        }

        protected override void Exit()
        {
        }

        protected override void Stay()
        {
            // �X�R�A���M����������܂ő҂B
            if (!_isPlayer1Post || !_isPlayer2Post) return;

            // ���U���g�V�[���ɑJ�ځB
            if (!_isSceneChangeRunning)
            {
                _isSceneChangeRunning = true;
                SceneLoader.ChangeScene("Result");
            }
        }

        // �X�R�A�������L���O�ɓo�^�����t���O�̑��삷��p�r�B
        void Player1PostScore() => _isPlayer1Post = true;
        void Player2PostScore() => _isPlayer2Post = true;
    }
}