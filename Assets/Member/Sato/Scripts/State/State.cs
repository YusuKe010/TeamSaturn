using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    /// <summary>
    /// �X�e�[�g�̊Ǘ��A�e�X�e�[�g���J�ڐ�̎w��Ɏg�p����B
    /// </summary>
    public enum StateIdentifier { Opening, Playing, Clear, GameOver, Retry, Result }

    /// <summary>
    /// �e�X�e�[�g�͂��̃N���X���p������B
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
        /// 1�x�̌Ăяo���ŃX�e�[�g�̒i�K�ɉ�����Enter,Stay,Exit�̂����ǂꂩ1�����s�����B
        /// ���̌Ăяo���Ŏ��s�����X�e�[�g��Ԃ��B
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
        /// �Q�[���I�����ɃX�e�[�g��j������^�C�~���O�ŌĂԏ����B
        /// </summary>
        public virtual void Dispose() { }

        /// <summary>
        /// Enter()���Ă΂�Ă��A�X�e�[�g�̑J�ڏ������Ă�ł��Ȃ��ꍇ�̂ݑJ�ډ\�B
        /// </summary>
        public bool TryChangeState(StateIdentifier next)
        {
            if (_stage == Stage.Enter)
            {
                Debug.LogWarning($"Enter���Ă΂��O�ɃX�e�[�g��J�ڂ��邱�Ƃ͕s�\�B�J�ڐ�:{next}");
                return false;
            }
            else if (_stage == Stage.Exit)
            {
                Debug.LogWarning($"���ɕʂ̃X�e�[�g�ɑJ�ڂ��鏈�����Ă΂�Ă���B�J�ڐ�:{next}");
                return false;
            }

            _stage = Stage.Exit;
            _next = _states[next];

            return true;
        }
    }
}