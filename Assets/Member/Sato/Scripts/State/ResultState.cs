using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class ResultState : State
    {
        Ranking _ranking;

        // �����L���O�ɃX�R�A�̑��M�����������t���O�B
        bool _isPostScoreRankingCompleted;
        // �d�����ăV�[����J�ڂ����Ȃ��悤���䂷��t���O�B
        bool _isSceneChangeRunning;

        public ResultState(IReadOnlyDictionary<StateIdentifier, State> states) : base(states)
        {
            _ranking = Object.FindAnyObjectByType<Ranking>();
        }

        protected override void Enter()
        {
            // �����L���O�ɃX�R�A�𑗐M�B
            int score = ScoreManager.GetScoreValue();
            _ranking.PostData("�e�X�g���[�U�[", score, PostScoreRankingCoplete);
        }

        protected override void Exit()
        {
        }

        protected override void Stay()
        {
            // �X�R�A���M����������܂ő҂B
            if (!_isPostScoreRankingCompleted) return;

            // ���U���g�V�[���ɑJ�ځB
            if (!_isSceneChangeRunning)
            {
                _isSceneChangeRunning = true;
                SceneLoader.ChangeScene("Result");
            }
        }

        // �X�R�A�������L���O�ɓo�^�����t���O�̑��삷��p�r�B
        void PostScoreRankingCoplete() => _isPostScoreRankingCompleted = true;
    }
}